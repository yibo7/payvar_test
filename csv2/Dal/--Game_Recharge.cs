//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Dapper;
//using WalletMiddleware.Comm;
//using WalletContracts.Comm;
//using WalletContracts.Entity;
//using XS.Core;

//namespace WalletMiddleware.Dal
//{
//    public class Game_Recharge : DbBaseEbChange<TableModels.Game_Recharge>
//    {
//        public static readonly Game_Recharge Instane = new Game_Recharge();

//        public void UpdateConfirmByVersion(long Id, int Confirm, int Version)
//        {

//            using (var connection = GetConn)
//            {
//                string sql = string.Format("update game_recharge set Confirm={0},Version=Version+1 where Id={1} AND Version={2};", Confirm, Id, Version);
//                int rz = connection.Execute(sql);
//                if (rz == 0)
//                {
//                    XS.Core.Log.InfoLog.InfoFormat("充值记录{0}无法更新确认数，发生版本冲突！", Id);
//                }
//            }
//        }
//        public (bool isok, string err) AddRecharge(List<WalletTransaction> data)
//        {
//            bool isucces = false;
//            string sErrInfo = string.Empty;

//            using (var connection = GetConn)
//            {
//                var tran = connection.BeginTransaction();
//                try
//                {
//                    foreach (var model in data)
//                    {

//                        if (IsHaveWalletDataId(model.Id))
//                        {
//                            string sInfo = string.Format("发现有重复的充值记录Id:{0}", model.Id);
//                            XS.Core.Log.InfoLog.Info(sInfo);
//                            Dal.SendMsgsDal.Instane.SendEmailAndMobiles(sInfo, sInfo);
//                            continue;
//                        }

//                        TableModels.Game_Recharge mdRecharge = new TableModels.Game_Recharge();
//                        var amount = model.AmountDecimal.ToString("0.########");
//                        mdRecharge.AddTime = DateTime.Now;
//                        mdRecharge.Amount = decimal.Parse(amount); //model.AmountDecimal;
//                        mdRecharge.CoinType = model.CoinType;
//                        mdRecharge.Fee = model.FeeDecimal;
//                        //mdRecharge.EbChangeUserId = model.
//                        mdRecharge.FromAddr = model.FromAddr;
//                        mdRecharge.ToAddr = model.ToAddr;
//                        mdRecharge.TxId = model.Hash;
//                        mdRecharge.States = 0;
//                        mdRecharge.TransTime = XS.Core.SqlDateTimeInt.GetSecond(model.TransTime);
//                        mdRecharge.FromUserId = model.FromUserId;
//                        mdRecharge.ToUserId = model.ToUserId;
//                        mdRecharge.WalletDataId = model.Id;
//                        mdRecharge.IsBackSucess = false;

//                        if (mdRecharge.Amount > 0)
//                        {
//                            mdRecharge.Hash = mdRecharge.GetMdwu();
//                            //写入之前做txid校验，防止重复写拉
//                            Add(mdRecharge, tran, connection);
//                            sErrInfo = string.Format("币种:{0},数量:{1},时间:{2}", mdRecharge.CoinType, mdRecharge.Amount, mdRecharge.AddTime);

//                        }
//                        else
//                        {
//                            //string sInfo = string.Format("充值记录Id{0}金额小于0无法入库", model.Id);
//                            //XS.Core.Log.InfoLog.InfoFormat(sInfo);

//                            //Dal.SendMsgsDal.Instane.SendEmailAndMobiles(sInfo, sInfo);
//                        }
//                    }
//                    tran.Commit();
//                    isucces = true;
//                }
//                catch (Exception ex)
//                {
//                    string sInfo = string.Format("充值入库失败:{0}", ex.Message);
//                    XS.Core.Log.ErrorLog.Error(sInfo);
//                    Dal.SendMsgsDal.Instane.SendEmails(sInfo, sInfo);
//                    isucces = false;
//                    sErrInfo = ex.Message;
//                    tran.Rollback();
//                }
//            }
//            return (isucces, sErrInfo);
//        }
//        /// <summary>
//        /// 获取还没有入库的数据
//        /// </summary>
//        /// <returns></returns>
//        public List<TableModels.Game_Recharge> GetRechargeNoInDb()
//        {
//            return GetList("States=0");
//        }

//        public bool IsHaveWalletDataId(long dataid)
//        {
//            return Exists(string.Format("WalletDataId={0}", dataid));
//        }
//        /// <summary>
//        /// 向钱包系统通知已经完成的记录
//        /// </summary>
//        public void UpdateSucess()
//        {
//            var lst = GetList("IsBackSucess=false");
//            StringBuilder sbIds = new StringBuilder();
//            foreach (var model in lst)
//            {
//                sbIds.Append(model.WalletDataId);
//                sbIds.Append(",");
//            }

//            if (sbIds.Length > 0)
//            {
//                sbIds.Remove(sbIds.Length - 1, 1);
//                try
//                {
//                    string ids = sbIds.ToString();
//                    string sMdWu = HashHelper.GetHashStr(string.Format("ids={0}", ids));
//                    var data = WcfInst.Instance.UpdateTransactionRecord(ids, sMdWu);
//                    if (data.IsSucess && data.Data)
//                    {
//                        foreach (var model in lst)
//                        {
//                            model.IsBackSucess = true;

//                            using (var connection = GetConn)
//                            {
//                                string sql = string.Format("update game_recharge set IsBackSucess=1 where Id={0} ;", model.Id);
//                                int rz = connection.Execute(sql);
//                                if (rz == 0)
//                                {
//                                    XS.Core.Log.InfoLog.InfoFormat("充值记录{0}无法更新确认数，发生版本冲突！", model.Id);
//                                    Dal.SendMsgsDal.Instane.SendEmails("试图更改recharge表已经更新过的数据，更改失败", "recharge表ID：" + model.Id.ToString());
//                                }
//                            }

//                            //Update(model);
//                        }
//                    }
//                }
//                catch (Exception e)
//                {
//                    //XS.Core.Log.InfoLog.InfoFormat("向钱包服务通知成功的充值记录失败:{0}", e.Message);
//                    string sInfo = string.Format("向钱包服务通知成功的充值记录失败:{0}", e.Message);
//                    XS.Core.Log.ErrorLog.Error(sInfo);
//                    Dal.SendMsgsDal.Instane.SendEmails(sInfo, sInfo);
//                }

//            }

//        }

//    }
//}
