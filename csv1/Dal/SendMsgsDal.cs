using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using WalletMiddleware.Comm;
using WalletMiddleware.TableModels;
using WalletContracts.Comm;
using WalletContracts.Entity;

namespace WalletMiddleware.Dal
{
    public class SendMsgsDal : DbBaseRiskCheck<TableModels.SendMsgs>
    {
        public static readonly SendMsgsDal Instane = new SendMsgsDal();
        /// <summary>
        /// 这个是用来检查重新的邮件短信内容的，相同的内容一天内发送一次，所以这个集合是一天清理一次
        /// </summary>
        private List<string> lstSendMdWu = new List<string>();
        private DateTime lastDateTime;

        public SendMsgsDal()
        {
            lastDateTime = DateTime.Now;
            System.Timers.Timer t = new System.Timers.Timer(1000*60*10);
            t.Elapsed += ToSendContent;
            t.Start();

        }
        private string LockKey = "getmsgtosend";
        public bool GetLock()
        {
            bool key = ApplicationLockDal.Instane.GetLock(LockKey, "获取短信或email并发送", 30);
            return key;
        }
        private bool CleanLock()
        {
            bool key = ApplicationLockDal.Instane.DelLock(LockKey);
            return key;
        }
        private void ToSendContent(object sender, System.Timers.ElapsedEventArgs e)
        {//获得锁
            var lock_ = GetLock();

            if (lock_)
            {
                var lst = GetList("IsSend=0");
                foreach (var model in lst)
                {
                    model.IsSend = 1;
                    model.Version = model.Version + 1;
                    model.SendTime = DateTime.Now;
                    bool isok = Update(model);//以后可以优化检查版本
                    if (isok)
                    {
                        if (model.MsgType == 0)
                        {
                            EmailSender.Send(model.ToTarget, model.Title, model.Msg);
                        }
                        else if (model.MsgType == 1)
                        {
                            MobileSender.Send(model.Msg, model.ToTarget, "");
                        }
                    }
                }

                //释放锁
                CleanLock(); 
            }
            

            if (XS.Core.DateUtils.DateDiff("day", lastDateTime, DateTime.Now) > 1)
            {
                lastDateTime = DateTime.Now;
                lstSendMdWu.Clear();
            }
        }

        public void SendEmailAndMobiles(string sTitle, string sContent)
        {
            SendMobiles(sContent);
            SendEmails(sTitle, sContent);
        }

        public void SendEmails(string sTitle, string sContent)
        {
           string sEmails =  Settings.Instance.RepertEmails;

            if (!string.IsNullOrEmpty(sEmails))
            {
                string[] aEmail = sEmails.Split(',');
                foreach (var em in aEmail)
                {
                    SendEmail(em, sTitle, sContent);
                }
            }
        }
        public void SendEmail(string emailAddr,string sTitle,string sContent)
        {
            SendMsgs model = new SendMsgs();
            model.Title = sTitle;
            model.Msg = sContent;
            model.MsgType = 0;//email类型
            model.IsSend = 0; //未发送
            model.ToTarget = emailAddr;
            model.Version = 0;
            model.AddTime = DateTime.Now;
            AddMsg(model);
        }

        private void AddMsg(SendMsgs model)
        {
            if (Settings.Instance.IsAddReport == 1)
            {
                if (!lstSendMdWu.Contains(model.GetMdwu()))
                {
                    lstSendMdWu.Add(model.GetMdwu());
                    Add(model);
                    
                }
            }
        }
        public void SendMobiles(string sContent)
        {
            string sEmails = Settings.Instance.ReperMobiles;

            if (!string.IsNullOrEmpty(sEmails))
            {
                string[] aEmail = sEmails.Split(',');
                foreach (var em in aEmail)
                {
                    SendMobile(em,  sContent);
                }
            }
        }
        public void SendMobile(string mobileNumber,string msg)
        {
            SendMsgs model = new SendMsgs(); 
            model.Msg = msg;
            model.MsgType = 1;//mobile类型
            model.IsSend = 0; //未发送
            model.ToTarget = mobileNumber;
            model.Version = 0;
            model.AddTime = DateTime.Now;
            AddMsg(model);
        }
    }
}
