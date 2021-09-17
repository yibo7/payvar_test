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
//    /// <summary>
//    /// 
//    /// </summary>
//    public class TransactionModelDal : DbBaseRiskCheck<TransactionReport>
//    {
//        public static readonly TransactionModelDal Instane = new TransactionModelDal();

//        public string SendReport()
//        { 
//            var lst = GetList("IsReport=0");
//            StringBuilder sbInfo = new StringBuilder();
//            foreach (var model in lst)
//            {
//                sbInfo.AppendFormat("有归总记录(币种:{0},数量:{1},手续费:{2},是否成功:{3})", model.CoinType, model.AmountDecimal, model.FeeDecimal,model.States==3?"成功":"失败");
//                model.IsReport = 1;
//                Update(model);
//            }
//            return sbInfo.ToString();
//        }
         
//    }
//}
