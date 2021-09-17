//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using WalletMiddleware.CheckData;
//using WalletMiddleware.Comm;
//using WalletMiddleware.TableModels;
//using WalletContracts.Comm;
//using WalletContracts.Entity;
//using WalletMiddleware.Apis.Wcf;

//namespace WalletMiddleware.Dal
//{
//    /// <summary>
//    /// 充值提币业务,目前本系统只有提币用到
//    /// </summary>
//    public class virtualcaptualoperation //: DbBaseRiskCheck<TableModels.virtualcaptualoperation>
//    {
//        public static readonly virtualcaptualoperation Instane = new virtualcaptualoperation();

//        private string SendTran(List<WithdrawList> withdrawList)
//        {
//            StringBuilder sbr = new StringBuilder();


//            foreach (var item in withdrawList)
//            {
//                Thread.Sleep(1000);
//                string coinType = AppStaticData.CoinTypes[item.CoinTypeId].fShortName;
//                DataReturn<TransactionResult> rzData = Wcf.Instance.SendTransaction(item.Amount, coinType, item.Fees,item.FromAddress,item.WithdrawAddress);

//                if (rzData.IsSucess) //api调用成功
//                {
//                    if (rzData.Data.IsSuccess)//发币成功
//                    {
//                        string sRzInfo = string.Format("成功发送一笔热提币,用户Id:{0},币种:{1},金额:{2},手续费{3},目标地址:{4},发送地址:{5}",
//                            item.UserId, coinType, item.Amount, item.Fees, item.WithdrawAddress, item.FromAddress);
//                        XS.Core.Log.InfoLog.Info(sRzInfo);
//                        sbr.AppendFormat("成功发送一笔热提币:{0}", DateTime.Now);
//                        item.State = 1;
//                        item.TxId = rzData.Data.Hash;
//                        item.Fees = rzData.Data.Fee;
//                        WithdrawListDal.Instance.Update(item);


//                        string emailTitle = string.Format("成功发送一笔热提币:{0}", DateTime.Now);
//                        Dal.SendMsgsDal.Instane.SendEmails(emailTitle, sRzInfo);
//                    }
//                    else
//                    {
//                        item.State = 2;
//                        WithdrawListDal.Instance.Update(item);
//                        sbr.AppendFormat("热提币发币失败:{0}", rzData.Msg);

//                        Dal.SendMsgsDal.Instane.SendEmails("热提币发币失败!", rzData.Msg);
//                    }
//                }
//                else
//                {
//                    sbr.AppendFormat("热发币调用失败:{0}", rzData.Msg);

//                    Dal.SendMsgsDal.Instane.SendEmails("有提现记录，但热发币调用失败!", rzData.Msg);
//                }
//            }

//            return "";
//        }

//        public (bool isok, string rzinfo) SendTransaction()
//        {
//            bool isucces = false;
//            StringBuilder sbRZ = new StringBuilder();


//            //查询是否存在代发数据
//            var notSendList = WithdrawListDal.Instance.GetList("state = 0");
//            if (notSendList.Any())
//            {
//                //是 直接发送至结束
//                string sendResult = this.SendTran(notSendList);
//                sbRZ.Append(sendResult);
//            }
//            else
//            {
//                //否  向交易所获取待处理提现记录
//                var withdraw = Apis.Api.Instance.GetWithdrawList();

//                if (withdraw.Any())
//                {
//                    foreach (var x in withdraw)
//                    {
//                        if (AppStaticData.CoinTypes.ContainsKey(x.fVi_fId2) && AppStaticData.HotWallets.ContainsKey(x.fVi_fId2))
//                        {
//                            //btc usdt类的交易验证
//                            var canSend = CheckCoinTxState.Current.CanSend(x.fVi_fId2, x.withdraw_virtual_address);
//                            if (!canSend) continue;

//                            //hash验证
//                            if (x.CheckMdwu())
//                            {
//                                //string coinType = AppStaticData.CoinTypes[x.fVi_fId2].fShortName;

//                                //判断是否存在待处理提现记录
//                                if (!WithdrawListDal.Instance.IsHave(x.fId))
//                                {
//                                    // 添加到本地待处理提现记录
//                                    WithdrawList mdWithdraw = new WithdrawList();
//                                    mdWithdraw.AddTime = DateTime.Now;
//                                    mdWithdraw.Amount = x.fAmountPay;
//                                    mdWithdraw.CoinTypeId = x.fVi_fId2;
//                                    mdWithdraw.Fees = x.ffees;
//                                    mdWithdraw.UserId = x.FUs_fId2;
//                                    mdWithdraw.WithdrawAddress = x.withdraw_virtual_address;
//                                    mdWithdraw.FromAddress = AppStaticData.HotWallets[x.fVi_fId2].Address;
//                                    mdWithdraw.VirtualcaptualoperationId = x.fId;
//                                    mdWithdraw.State = 0;
//                                    WithdrawListDal.Instance.Add(mdWithdraw);
//                                }
//                                else
//                                {
//                                    // 预警
//                                    if (!WithdrawListDal.Instance.IsSendMobiles(x.fId))
//                                    {
//                                        string msg = string.Format("请注意,有重复提现的订单,ID为{0}提币已经发送", x.fId);
//                                        SendMsgsDal.Instane.SendEmails("请注意,有重复提现的订单", msg);
//                                        XS.Core.Log.InfoLog.Info(msg);
//                                        sbRZ.AppendFormat("请注意,ID为{0}提币已经发送", x.fId);

//                                        //TODO 报警
//                                        Dal.SendMsgsDal.Instane.SendEmailAndMobiles("请注意，有提币记录偿试重复发送!", sbRZ.ToString());

//                                        var withEntity = WithdrawListDal.Instance.GetEntityByWhere(string.Format("VirtualcaptualoperationId={0}", x.fId));
//                                        WithdrawListDal.Instance.SetHaveSendMobiles(x.fId, withEntity.Version);
//                                    }
//                                }
//                            }
//                            else
//                            {
//                                string sInfo = string.Format("有提币记录，但hash验证错误,记录Id:{0},提币地址:{1}", x.fId,
//                                    x.withdraw_virtual_address);
//                                XS.Core.Log.InfoLog.Error(sInfo);

//                                Dal.SendMsgsDal.Instane.SendEmailAndMobiles("有提币记录，但hash验证错误!", sInfo);

//                                sbRZ.Append("有提币记录，但hash验证错误!");
//                            }
//                        }
//                    }

//                    while (true)
//                    {
//                        //查询待提现记录
//                        //查询等待提交的地址
//                        var readySend = WithdrawListDal.Instance.GetList("state = 0");
//                        if (readySend.Any())
//                        {
//                            string sendResult = this.SendTran(readySend);
//                            sbRZ.Append(sendResult);
//                        }
//                        else
//                        {
//                            break;
//                        }

//                    }

//                }
//            }
//            return (isucces, sbRZ.ToString());
//        }
//        // public (bool isok, string rzinfo) SendTransaction()
//        // {
//        //     bool isucces = false; 
//        //     StringBuilder sbRZ = new StringBuilder();
//        //     //查找提币(fType=2)记录下的状态是等待发币(fStatus=5)的记录
//        //     List<TableModels.virtualcaptualoperation> lst = GetList("fType=2 and (fStatus=5 or fStatus=51) ");

//        //     #region 临时代码
//        //     //List<TableModels.virtualcaptualoperation> lst = GetList("fType=2 and fStatus=5 and fVi_fId2=1 ");
//        //     //lst = lst.Where(w => w.withdraw_virtual_address == "1FGhzci9A7KddwPHhLRwZSu5Ykp5mkpG9c").ToList();
//        //     //lst = lst.Where(w => w.fVi_fId2 == 13).ToList();
//        //     //lst = lst.Take(22).ToList();
//        //     #endregion

//        //     int iIndex = 0;

//        //     foreach (var model in lst)
//        //     {
//        //         int CoinTypeId = model.fVi_fId2;
//        //         if (AppStaticData.CoinTypes.ContainsKey(CoinTypeId)&& AppStaticData.HotWallets.ContainsKey(CoinTypeId))
//        //         {
//        //             //btc usdt类的交易验证
//        //             var canSend = CheckCoinTxState.Current.CanSend(CoinTypeId, model.withdraw_virtual_address);
//        //             if (!canSend) continue;

//        //             //hash验证
//        //             if (model.CheckMdwu())
//        //             {                       
//        //                 decimal amount = model.fAmountPay;
//        //                 string coinType = AppStaticData.CoinTypes[CoinTypeId].fShortName;
//        //                 decimal fee = model.ffees;
//        //                 string from = AppStaticData.HotWallets[CoinTypeId].Address;
//        //                 //string from = "1kPx1H5HTgocSzigbTokBjtodFoGjvZMZ";
//        //                 string to = model.withdraw_virtual_address;
//        //                 string password = Settings.Instance.WcfUserPass;
//        //                 string userid = Settings.Instance.WcfUserId;

//        //                 if (!WithdrawListDal.Instance.IsHave(model.fId))
//        //                 {
//        //                     WithdrawList mdWithdraw = new WithdrawList();
//        //                     mdWithdraw.AddTime = DateTime.Now;
//        //                     mdWithdraw.Amount = amount;
//        //                     mdWithdraw.CoinTypeId = CoinTypeId;
//        //                     mdWithdraw.Fees = fee;
//        //                     mdWithdraw.UserId = model.FUs_fId2;
//        //                     mdWithdraw.WithdrawAddress = to;
//        //                     mdWithdraw.FromAddress = from;
//        //                     mdWithdraw.VirtualcaptualoperationId = model.fId;
//        //                     mdWithdraw.State = 0;
//        //                     long Id = WithdrawListDal.Instance.Add(mdWithdraw);
//        //                     mdWithdraw.Id = Id;
//        //                     string mdwu = HashHelper.GetHashStr(
//        //                         $"amount={amount}&coinType={coinType}&fee={fee}&from={from}&outtype={0}&password={password}&to={to}&userid={userid}");
//        //                     Thread.Sleep(1000);
//        //                     DataReturn<TransactionResult> rzData = WcfInst.Instance.SendTransaction(userid, coinType, from, to, amount, fee, password, mdwu,0);

//        //                     if (rzData.IsSucess) //api调用成功
//        //                     {
//        //                         if (rzData.Data.IsSuccess)//发币成功
//        //                         {
//        //                             string sRzInfo = string.Format("成功发送一笔热提币,用户Id:{0},币种:{1},金额:{2},手续费{3},目标地址:{4},发送地址:{5}",
//        //                                 model.FUs_fId2, coinType,amount,fee, to, from);
//        //                             XS.Core.Log.InfoLog.Info(sRzInfo);
//        //                             sbRZ.AppendFormat("成功发送一笔热提币:{0}", DateTime.Now);
//        //                             mdWithdraw.State = 1;
//        //                             mdWithdraw.TxId = rzData.Data.Hash;
//        //                             WithdrawListDal.Instance.Update(mdWithdraw);

//        //                             model.fStatus = 6;
//        //                             model.ftradeUniqueNumber = rzData.Data.Hash;
//        //                             Update(model);
//        //                             string emailTitle = string.Format("成功发送一笔热提币:{0}", DateTime.Now);
//        //                             Dal.SendMsgsDal.Instane.SendEmails(emailTitle, sRzInfo);
//        //                             isucces = true;
//        //                         }
//        //                         else
//        //                         {
//        //                             mdWithdraw.State = 2;
//        //                             WithdrawListDal.Instance.Update(mdWithdraw);
//        //                             sbRZ.AppendFormat("热提币发币失败:{0}", rzData.Msg);

//        //                             Dal.SendMsgsDal.Instane.SendEmails("热提币发币失败!", sbRZ.ToString());
//        //                         }
//        //                     }
//        //                     else
//        //                     {
//        //                         sbRZ.AppendFormat("热发币调用失败:{0}", rzData.Msg);

//        //                         Dal.SendMsgsDal.Instane.SendEmails("有提现记录，但热发币调用失败!", sbRZ.ToString());
//        //                     }
//        //                 }
//        //                 else
//        //                 {
//        //if (!WithdrawListDal.Instance.IsSendMobiles(model.fId))
//        //{
//        //	//EmailSender.Send("", "请注意","请注意,ID为{0}提币已经发送", model.fId);
//        //	string msg = string.Format("请注意,有重复提现的订单,ID为{0}提币已经发送", model.fId);
//        //	SendMsgsDal.Instane.SendEmails("请注意,有重复提现的订单", msg);
//        //	XS.Core.Log.InfoLog.Info(msg);
//        //	sbRZ.AppendFormat("请注意,ID为{0}提币已经发送", model.fId);

//        //	Dal.SendMsgsDal.Instane.SendEmailAndMobiles("请注意，有提币记录偿试重复发送!", sbRZ.ToString());

//        //	var withEntity = WithdrawListDal.Instance.GetEntityByWhere(string.Format("VirtualcaptualoperationId={0}", model.fId));
//        //	WithdrawListDal.Instance.SetHaveSendMobiles(model.fId, withEntity.Version);
//        //}
//        //                 }
//        //             }
//        //             else
//        //             {
//        //                 string sInfo = string.Format("有提币记录，但hash验证错误,记录Id:{0},提币地址:{1}", model.fId,
//        //                     model.withdraw_virtual_address);
//        //                 XS.Core.Log.InfoLog.Error(sInfo);

//        //                 Dal.SendMsgsDal.Instane.SendEmailAndMobiles("有提币记录，但hash验证错误!", sInfo);

//        //                 sbRZ.Append("有提币记录，但hash验证错误!");
//        //             }

//        //         }

//        //         iIndex++;
//        //     }

//        //     return (isucces, sbRZ.ToString());
//        // }

//    }
//}