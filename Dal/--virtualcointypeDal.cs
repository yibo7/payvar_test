//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Dapper;
//using WalletMiddleware.Comm;
//using WalletContracts.Comm;
//using WalletContracts.Entity;

//namespace WalletMiddleware.Dal
//{
//    public class virtualcointypeDal: DbBaseRiskCheck<TableModels.virtualcointype>
//    {
//        public static readonly virtualcointypeDal Inst = new virtualcointypeDal();

//		public void UpdateFee(long Id,decimal feeA,decimal feeB,decimal feeC)
//		{

//			using (var connection = GetConn)
//			{
//				string sql = string.Format("update fvirtualcointype set feesA={0},feesB={1},feesC={2} where fId={3}", feeA,feeB,feeC,Id);
				
//				int rz = connection.Execute(sql);
//				if (rz == 0)
//				{
//					XS.Core.Log.InfoLog.InfoFormat("充值记录{0}无法更新确认数，发生版本冲突！", Id);
//				}
//			}
//		}

//		//public List<int> GetCoinIdList()
//		//{
//		//    string addrSql = $"SELECT fid FROM fvirtualcointype WHERE fstatus ={1}";
//		//    var addresses = virtualcointype.Instane.GetList(addrSql);
//		//}

//		//protected override string Analysis()
//		//{
//		//    //查询币种下面的冷地址
//		//    //<1000增加10000W个
//		//    string addrSql = $"SELECT fid FROM fvirtualcointype WHERE fstatus ={1}";
//		//    var addresses = virtualcointype.Instane.GetList(addrSql);
//		//    foreach (var item in addresses)
//		//    {
//		//        string poolSql = $"SELECT COUNT(1) FROM fpool WHERE fvi_type={item.fip}";
//		//    }


//		//    return "ffffff";
//		//}
//	}
//}
