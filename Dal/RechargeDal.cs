using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletContracts.Comm;
using WalletContracts.Entity;
using WalletMiddleware.Apis.Utils;
using WalletMiddleware.Apis.Wcf;
using WalletMiddleware.ApisJava.vo;
using WalletMiddleware.Comm;


namespace WalletMiddleware.Dal
{
    /// <summary>
    /// 充值 Dal
    /// </summary>
    public class RechargeDal : DbBaseRiskCheck<TableModels.Recharge>
    {
        public static readonly RechargeDal Instane = new RechargeDal();
        /// <summary>
        /// 更新本地确认数
        /// </summary>
        /// <param name="Id">主键</param>
        /// <param name="Confirm">确认数</param>
        /// <param name="Version">版本号</param>
        public void UpdateConfirmByVersion(long Id, int Confirm, int Version)
        {
            using (var connection = GetConn)
            {
                string sql = string.Format("update recharge set Confirm={0},Version=Version+1 where Id={1} AND Version={2};", Confirm, Id, Version);
                int rz = connection.Execute(sql);
                if (rz == 0)
                {
                    XS.Core.Log.InfoLog.InfoFormat("充值记录{0}无法更新确认数，发生版本冲突！", Id);
                }
            }
        }
        /// <summary>
        /// yhl 2019-8-21
        /// 从钱包取到充值的数据，加入到中间件的库中，状态为未发送。
        /// 添加时，要防止重复添加。
        /// </summary>
        /// <param name="data">钱包取到充值的数据</param>
        /// <returns>是否成功</returns>
        public (bool isok, string err) AddRecharge(List<WalletTransaction> data)
        {
            bool isucces = false;
            string sErrInfo = string.Empty;

            using (var connection = GetConn)
            {
                var tran = connection.BeginTransaction();
                try
                {
                    foreach (var model in data)
                    {
                        //if (IsHaveWalletDataId(model.Id))
                        if (IsHaveWalletDataId2(model.Hash,model.CoinType))
                            {
                            string sInfo = string.Format("发现有重复的充值记录Id:{0}", model.Id);
                            XS.Core.Log.InfoLog.Info(sInfo);
                            //2020-8-16  先注释
                            //2020-8-17  打开
                            Dal.SendMsgsDal.Instane.SendEmailAndMobiles(sInfo, sInfo);
                            //向钱包系统通知已经完成的记录
                            //8-16 yhl  添加
                            Wcf.Instance.UpdateTransactionRecord(model.Id.ToString());
                            continue;
                        }

                        TableModels.Recharge mdRecharge = new TableModels.Recharge();
                        var amount = model.AmountDecimal.ToString("0.########");
                        mdRecharge.AddTime = DateTime.Now;
                        mdRecharge.Amount = decimal.Parse(amount); //model.AmountDecimal;
                        mdRecharge.CoinType = model.CoinType;
                        mdRecharge.Fee = model.FeeDecimal;
                        //mdRecharge.EbChangeUserId = model.
                        mdRecharge.FromAddr = model.FromAddr;
                        mdRecharge.ToAddr = model.ToAddr;
                        mdRecharge.TxId = model.Hash;
                        mdRecharge.States = 0;
                        mdRecharge.TransTime = XS.Core.SqlDateTimeInt.GetSecond(model.TransTime);
                        mdRecharge.FromUserId = model.FromUserId;
                        mdRecharge.ToUserId = model.ToUserId;
                        mdRecharge.WalletDataId = model.Id;
                        //mdRecharge.IsBackSucess = false;

                        //2019-8-21 yhl
                        mdRecharge.Tag = 0;
                        if (mdRecharge.Amount > 0)
                        {
                            mdRecharge.Hash = mdRecharge.GetMdwu();
                            //写入之前做txid校验，防止重复写拉
                            Add(mdRecharge, tran, connection);
                            sErrInfo = string.Format("币种:{0},数量:{1},时间:{2}", mdRecharge.CoinType, mdRecharge.Amount, mdRecharge.AddTime);

                        }
                        else
                        {
                            //string sInfo = string.Format("充值记录Id{0}金额小于0无法入库", model.Id);
                            //XS.Core.Log.InfoLog.InfoFormat(sInfo);

                            //Dal.SendMsgsDal.Instane.SendEmailAndMobiles(sInfo, sInfo);
                        }
                    }
                    tran.Commit();
                    isucces = true;
                }
                catch (Exception ex)
                {
                    string sInfo = string.Format("充值入库失败:{0}", ex.Message);
                    XS.Core.Log.ErrorLog.Error(sInfo);
                    Dal.SendMsgsDal.Instane.SendEmails(sInfo, sInfo);
                    isucces = false;
                    sErrInfo = ex.Message;
                    tran.Rollback();
                }
            }
            return (isucces, sErrInfo);
        }

        /// <summary>
        /// 2019-11-28 
        /// 新版的  用户充值 添加到库中
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public (bool isok, string err) AddRecharge_New(List<ReciveRechangeVo> data)
        {
            bool isucces = false;
            string sErrInfo = string.Empty;

            using (var connection = GetConn)
            {
                var tran = connection.BeginTransaction();
                try
                {
                    foreach (var model in data)
                    {
                        if (IsHaveWalletDataId(model.walletDataId))
                        {
                            string sInfo = string.Format("发现有重复的充值记录Id:{0}", model.walletDataId);
                            XS.Core.Log.InfoLog.Info(sInfo);
                            Dal.SendMsgsDal.Instane.SendEmailAndMobiles(sInfo, sInfo);
                            continue;
                        }

                        //2019-12-16 验证数据是否窜改
                        //用户GID+币种名称+收币地址+金额【8位小数】+用户私钥 +延值
                        string userGid = Settings.Instance.WcfUserId;
                        string _mdwu= Md5Utils.ToMd5AndExtend($"{userGid}{model.coinType}{model.toAddr}{model.amountDecimal.ToString("0.########")}{Settings.Instance.PrivateKey}");
                        if (_mdwu == model.mdwu)
                        {
                            TableModels.Recharge mdRecharge = new TableModels.Recharge();
                            var amount = model.amountDecimal.ToString("0.########");
                            mdRecharge.AddTime = DateTime.Now;
                            mdRecharge.Amount = decimal.Parse(amount); //model.AmountDecimal;
                            mdRecharge.CoinType = model.coinType;
                            mdRecharge.Fee = model.feeDecimal;
                            //mdRecharge.EbChangeUserId = model.
                            mdRecharge.FromAddr = model.fromAddr;
                            mdRecharge.ToAddr = model.toAddr;
                            mdRecharge.TxId = model.txid;
                            mdRecharge.States = 0;
                            mdRecharge.TransTime = XS.Core.SqlDateTimeInt.GetSecond(model.transTime);
                            mdRecharge.FromUserId = Guid.Empty;
                            mdRecharge.ToUserId = Guid.Empty;
                            mdRecharge.WalletDataId = model.walletDataId;
                            mdRecharge.Confirm = model.corfirm;
                            //mdRecharge.IsBackSucess = false;

                            //2019-8-21 yhl
                            mdRecharge.Tag = 0;
                            if (mdRecharge.Amount > 0)
                            {
                                mdRecharge.Hash = mdRecharge.GetMdwu();
                                //写入之前做txid校验，防止重复写拉
                                Add(mdRecharge, tran, connection);
                                sErrInfo = string.Format("币种:{0},数量:{1},时间:{2}", mdRecharge.CoinType, mdRecharge.Amount, mdRecharge.AddTime);

                            }
                            else
                            {
                                //string sInfo = string.Format("充值记录Id{0}金额小于0无法入库", model.Id);
                                //XS.Core.Log.InfoLog.InfoFormat(sInfo);

                                //Dal.SendMsgsDal.Instane.SendEmailAndMobiles(sInfo, sInfo);
                            }
                        }
                    }
                    tran.Commit();
                    isucces = true;
                }
                catch (Exception ex)
                {
                    string sInfo = string.Format("充值入库失败:{0}", ex.Message);
                    XS.Core.Log.ErrorLog.Error(sInfo);
                    Dal.SendMsgsDal.Instane.SendEmails(sInfo, sInfo);
                    isucces = false;
                    sErrInfo = ex.Message;
                    tran.Rollback();
                }
            }
            return (isucces, sErrInfo);
        }
        /// <summary>
        /// yhl 2019-8-21 
        /// 获取 没有通知交易所 充值的数据 10条
        /// </summary>
        /// <returns></returns>
        public List<TableModels.Recharge> GetRechargeNoInDb()
        {
            return GetList("tag=0 limit 10");
        }
        /// <summary>
        /// 通过Hash，把Tag改为4
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
       public bool UpdateTagByHash(string hash)
        {
            bool key = false;
            if(!string.IsNullOrEmpty(hash))
            {
                List<TableModels.Recharge> errorLs= GetList("tag=0 and hash='"+ hash + "' limit 1");
                if (errorLs.Count>0)
                {
                    errorLs[0].Tag = 4;
                    key= Update(errorLs[0]);
                }
            }
            return key;
            
        }

        /// <summary>
        /// yhl 2019-8-22 
        /// 获取 没有通知交易所 没有达到确认数的数据 10条
        /// </summary>
        /// <returns></returns>
        //public List<TableModels.Recharge> GetRechargeNoComfirmDb()
        //{
        //    return GetList("tag=2 limit 10");
        //}
        /// <summary>
        /// 2019-8-22
        /// 很重要 检测是否有重复的充值记录。
        /// </summary>
        /// <param name="dataid">SqlID</param>
        /// <returns></returns>
        public bool IsHaveWalletDataId(long dataid)
        {
            return Exists(string.Format("WalletDataId={0}", dataid));
        }
       //2020-9-7 
        public bool IsHaveWalletDataId2(string hash,string cointype)
        {
            return Exists(string.Format("TxId='{0}' and CoinType='{1}'", hash,cointype));
        }
        /// <summary>
        /// 2019-8-21
        /// 更新tag 为1
        /// </summary>
        /// <param name=""></param>
        public void UpdateTag(List<TableModels.Recharge> result)
        {

            if (result.Count > 0)
            {
                string sbIds = string.Join(",", result.Select(i => i.Id));

                try
                {
                    using (var connection = GetConn)
                    {

                        string sql = string.Format("update recharge set tag=1 where Id in ({0})", sbIds);
                        int rz = connection.Execute(sql);
                        if (rz == 0)
                        {
                            XS.Core.Log.InfoLog.InfoFormat("充值记录无法更新告诉交易所，发生错误！");

                        }
                    }
                }
                catch (Exception e)
                {
                    string sInfo = string.Format("充值记录无法更新告诉交易所，发生错误:{0}", e.Message);
                    XS.Core.Log.ErrorLog.Error(sInfo);
                }

            }
        }
        /// <summary>
        /// 2019-8-21
        /// 向钱包系统通知已经完成的记录
        /// </summary>
        public void UpdateSucess()
        {
            //var lst = GetList("IsBackSucess=false");
            var lst = GetList("tag=1");
            StringBuilder sbIds = new StringBuilder();
            foreach (var model in lst)
            {
                sbIds.Append(model.WalletDataId);
                sbIds.Append(",");
            }

            if (sbIds.Length > 0)
            {
                sbIds.Remove(sbIds.Length - 1, 1);
                try
                {
                    string ids = sbIds.ToString();
                    //string sMdWu = HashHelper.GetHashStr(string.Format("ids={0}", ids));
                    //var data = WcfInst.Instance.UpdateTransactionRecord(ids, sMdWu);

                    //向钱包系统通知已经完成的记录
                    var data = Wcf.Instance.UpdateTransactionRecord(ids);
                    if (data.IsSucess && data.Data)
                    {
                        foreach (var model in lst)
                        {
                            //model.IsBackSucess = true;
                            //model.Tag = 2;.

                            using (var connection = GetConn)
                            {
                                //string sql = string.Format("update recharge set IsBackSucess=1 where Id={0} ;",  model.Id);
                                string sql = string.Format("update recharge set tag=2 where Id={0} ;", model.Id);
                                int rz = connection.Execute(sql);
                                if (rz == 0)
                                {
                                    XS.Core.Log.InfoLog.InfoFormat("充值记录{0}无法更新确认数，发生版本冲突！", model.Id);
                                    Dal.SendMsgsDal.Instane.SendEmails("试图更改recharge表已经更新过的数据，更改失败", "recharge表ID：" + model.Id.ToString());
                                }
                            }

                            //Update(model);
                        }
                    }
                }
                catch (Exception e)
                {
                    //XS.Core.Log.InfoLog.InfoFormat("向钱包服务通知成功的充值记录失败:{0}", e.Message);
                    string sInfo = string.Format("向钱包服务通知成功的充值记录失败:{0}", e.Message);
                    XS.Core.Log.ErrorLog.Error(sInfo);
                    Dal.SendMsgsDal.Instane.SendEmails(sInfo, sInfo);
                }

            }

        }


        //public string UpdateConfirm()
        //{
        //    foreach (var mdType in AppStaticData.CoinTypes)
        //    {
        //        var lstRecharge = RechargeDal.Instane.GetList(string.Format("Confirm<{0} and  CoinType='{1}' ", mdType.Value.ConfirmNum, mdType.Value.fShortName));

        //        foreach (var recharge in lstRecharge)
        //        {
        //            string sMdWu = HashHelper.GetHashStr(string.Format("coinType={0}&hash={1}", recharge.CoinType, recharge.TxId));
        //            //string coinType, string hash,
        //            DataReturn<int> rzData = WcfInst.Instance.GetTransactionConfirmByHash(recharge.CoinType, recharge.TxId, sMdWu);

        //            if (rzData.IsSucess)
        //            {



        //                recharge.Confirm = rzData.Data;
        //                RechargeDal.Instane.UpdateConfirmByVersion(recharge.Id, recharge.Confirm, recharge.Version);
        //            }
        //        }
        //    }
        //    return "确认数更新完成！";
        //}
    }
}
