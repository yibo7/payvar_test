//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Dapper;
//using WalletMiddleware.Comm;
//using WalletMiddleware.TableModels;
//using WalletContracts.Comm;
//using WalletContracts.Entity;

//namespace WalletMiddleware.Dal
//{
//    //class Game_HotWalletDal
//    //{
//    //}

//    public class Game_HotWalletDal : DbBaseEbChange<TableModels.Game_HotWallet>
//    {
//        public static readonly Game_HotWalletDal Instane = new Game_HotWalletDal();
//        //private List<TableModels.virtualcointype> lstCoinTypes;
//        public Game_HotWalletDal()
//        {
//            //lstCoinTypes = virtualcointypeDal.Instane.GetList("fstatus=1 and ftype=2");
//        }

//        public string UpdateConfirm()
//        {
//            foreach (var mdType in AppStaticData.Game_CoinTypes)
//            {
//                var lstRecharge = Game_Recharge.Instane.GetList(string.Format("Confirm<{0} and  CoinType='{1}' ", mdType.Value.ConfirmNum, mdType.Value.fShortName));

//                foreach (var recharge in lstRecharge)
//                {
//                    string sMdWu = HashHelper.GetHashStr(string.Format("coinType={0}&hash={1}", recharge.CoinType, recharge.TxId));
//                    //string coinType, string hash,
//                    DataReturn<int> rzData = WcfInst.Instance.GetTransactionConfirmByHash(recharge.CoinType, recharge.TxId, sMdWu);
//                    if (rzData.IsSucess)
//                    {
//                        recharge.Confirm = rzData.Data;
//                        Game_Recharge.Instane.UpdateConfirmByVersion(recharge.Id, recharge.Confirm, recharge.Version);
//                    }
//                }
//            }
//            return "确认数更新完成！";
//        }
//        /// <summary>
//        /// 添加新的币种热钱包地址
//        /// </summary>
//        /// <returns></returns>
//        public string InitHotWallet()
//        {
//            foreach (var model in AppStaticData.Game_CoinTypes)
//            {

//                if (!IsHaveCoinType(model.Key)) //if (!IsHaveCoinType(model.Value.fShortName.Trim()))
//                {
//                    TableModels.Game_HotWallet mdWallet = new Game_HotWallet();
//                    mdWallet.CoinName = model.Value.fName;
//                    mdWallet.CoinId = model.Value.fid;
//                    mdWallet.CreateTime = DateTime.Now;
//                    mdWallet.CoinType = model.Value.fShortName.Trim();
//                    mdWallet.Status = 0;
//                    mdWallet.LastCalcTipTime = DateTime.MinValue;
//                    //mdWallet.MdWu =XS.Core.Md5Helper.MD5(mdWallet.CoinType);
//                    Add(mdWallet);

//                }
//                //model.fShortName  跟钱包那边的cointype是对应的


//            }
//            return "热钱包初始化完成";
//        }
//        /// <summary>
//        /// 创建新的币种钱包地址
//        /// </summary>
//        /// <returns></returns>
//        public string CreatWalletAddress()
//        {
//            StringBuilder sbRz = new StringBuilder();
//            List<Game_HotWallet> lst = GetList("Status=0");
//            int iIdex = 0;
//            foreach (var model in lst)
//            {
//                string sUserId = Settings.Instance.Game_WcfUserId;
//                string sMdwu = HashHelper.GetHashStr(string.Format("coinType={0}&userid={1}", model.CoinType, sUserId));
//                DataReturn<Addresses> sAddr = WcfInst.Instance.CreateAddress(sUserId, model.CoinType, sMdwu);
//                if (!Equals(sAddr, null) && sAddr.IsSucess)
//                {
//                    if (sAddr.Data.IsSuccess)
//                    {
//                        model.Address = sAddr.Data.Addr;
//                        model.MdWu = model.GetMdWu(model.MdWu);
//                        model.Status = 1;
//                        Update(model);
//                    }
//                    else
//                    {
//                        sbRz.AppendFormat("第{0}个创建地址返回失败结果", iIdex);
//                        //Dal.SendMsgsDal.Instane.SendEmails(sbRz.ToString(), sbRz.ToString());
//                    }

//                }
//                else
//                {
//                    sbRz.AppendFormat("第{0}个创建地址返回null结果;", iIdex);
//                    //Dal.SendMsgsDal.Instane.SendEmails(sbRz.ToString(), sbRz.ToString());
//                }


//                iIdex++;
//            }
//            return sbRz.ToString();

//        }

//        public string UpdateMoney()
//        {
//            StringBuilder sbRz = new StringBuilder();
//            List<Game_HotWallet> lst = GetList("Status=1");
//            int iIdex = 0;
//            foreach (var model in lst)
//            {


//                //string sUserId = Settings.Instance.WcfUserId;
//                string sMdwu =
//                    HashHelper.GetHashStr(string.Format("addr={0}&coinType={1}&cold={2}", model.Address, model.CoinType, false));

//                #region 更新热钱包余额

//                //string coinType, string addr, bool cold, string signature)
//                var moneyHot = WcfInst.Instance.GetBalance(model.CoinType, model.Address, false, sMdwu);
//                bool isHaveData = false;
//                if (!Equals(moneyHot, null) && moneyHot.IsSucess)
//                {
//                    model.Amount = decimal.Parse(moneyHot.Data.ToString());
//                    isHaveData = true;

//                }
//                else
//                {
//                    sbRz.AppendFormat("获取热钱包第{0}个地址更新金额返回失败结果;", iIdex);

//                    //Dal.SendMsgsDal.Instane.SendEmails(sbRz.ToString(), sbRz.ToString());
//                }

//                string sMdwuCold =
//                    HashHelper.GetHashStr(string.Format("addr={0}&coinType={1}&cold={2}", "", model.CoinType, true));
//                var moneyCold = WcfInst.Instance.GetBalance(model.CoinType, "", true, sMdwuCold);

//                if (!Equals(moneyCold, null) && moneyCold.IsSucess)
//                {
//                    model.ColdAmount = decimal.Parse(moneyCold.Data.ToString());
//                    isHaveData = true;

//                }
//                else
//                {
//                    sbRz.AppendFormat("获取冷钱包第{0}个地址更新金额返回失败结果;", iIdex);
//                }

//                if (isHaveData)
//                {
//                    Update(model);

//                }

//                if (model.CalcTips != 0
//                    && model.Amount < model.CalcTips
//                    && (model.LastCalcTipTime == DateTime.MinValue || model.LastCalcTipTime == DateTime.MaxValue ||
//                        model.LastCalcTipTime.AddHours(1) < DateTime.Now))
//                {
//                    //报警，当前的余额低于设定值
//                    Dal.SendMsgsDal.Instane.SendEmails("热地址里没钱啦，快看看吧",
//                        model.CoinType + "币当前余额：" + model.Amount + "，小于设定值：" + model.CalcTips);
//                    model.LastCalcTipTime = DateTime.Now;
//                    Update(model);
//                }

//                #endregion

//                #region 更新热钱包余额

//                #endregion


//                iIdex++;
//            }

//            return sbRz.ToString();
//        }

//        public bool IsHaveCoinType(int CoinTypeId)
//        {
//            return Exists(string.Format("CoinId={0}", CoinTypeId));
//            //return Exists(string.Format("CoinType='{0}'", CoinType));
//        }
//    }
//}
