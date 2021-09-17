//using System;
//using System.Collections.Generic;
//using System.Data;
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
//    public class AmountSnapshopDal : DbBaseRiskCheck<TableModels.amountsnapshot>
//    {
//        public static readonly AmountSnapshopDal Instane = new AmountSnapshopDal();
//        private IDbConnection GetConn => DbUtils.GetConnForEbChange();

//        public AmountSnapshopDal()
//        {
//        }
//        public string AddSnapshot()
//        {
//            string coinTypes = "";
//            foreach (var model in AppStaticData.CoinTypes)
//            {
//                string cointype = model.Value.fShortName.Trim();
//                coinTypes += "'" + cointype + "'"+",";
//            }
//            if (!string.IsNullOrEmpty(coinTypes))
//            {
//                coinTypes = coinTypes.Substring(0, coinTypes.Length - 1);
//            }

//            if (!string.IsNullOrEmpty(coinTypes))
//            {
//                DateTime addTime = DateTime.Now;
//                string sql = "select CoinType as 'CoinType',Amount as 'HotAmount',ColdAmount as 'ColdAmount' ,Amount+ColdAmount as 'AmountSum' from hotwallet where CoinType in (" + coinTypes + ")";
//                //List<ReportTem> rpData = connection.Query<ReportTem>(string.Format("select fcountrys.countryname as Title ,count(fuser.fId) as CountNum  from fuser,fcountrys where fuser.countryid = fcountrys.fid AND date_format(fRegisterTime,'%Y-%m-%d')={0}  GROUP BY countryid;", sWhere)).ToList();
//                //List<AmountSnapshopDal> list = 
//                using (var connection = GetConn)
//                {
//                    List<amountsnapshot> list = connection.Query<amountsnapshot>(sql).ToList();
//                    if (list != null && list.Count > 0)
//                    {
//                        foreach (var item in list)
//                        {
//                            TableModels.amountsnapshot amount = new amountsnapshot();
//                            amount.CoinType = item.CoinType;
//                            amount.HotAmount = item.HotAmount;
//                            amount.ColdAmount = item.ColdAmount;
//                            amount.AmountSum = item.AmountSum;
//                            amount.AddTime = addTime;
//                            //mdWallet.MdWu =XS.Core.Md5Helper.MD5(mdWallet.CoinType);
//                            Add(amount);
//                        }
//                    }
//                }
//            }
            
            
//            return "";
//        }
//    }
//}
