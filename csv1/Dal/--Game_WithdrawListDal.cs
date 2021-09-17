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
//    public class Game_WithdrawListDal : DbBaseRiskCheck<TableModels.Game_WithdrawList>
//    {
//        public static readonly Game_WithdrawListDal Instance = new Game_WithdrawListDal();

//        public bool IsHave(int vid)
//        {
//            return Exists(string.Format("VirtualcaptualoperationId={0}", vid));
//        }

//        public bool IsSendMobiles(int vid)
//        {
//            return Exists(string.Format("VirtualcaptualoperationId={0} and IsErrReport={1}", vid, 1));
//        }

//        public void SetHaveSendMobiles(int vid, int Version)
//        {
//            using (var connection = GetConn)
//            {
//                string sql = string.Format("update game_withdrawlist set IsErrReport={0} where VirtualcaptualoperationId={1} ;", 1, vid);
//                int rz = connection.Execute(sql);
//                if (rz == 0)
//                {
//                    XS.Core.Log.InfoLog.InfoFormat("数据表：game_withdrawlist，VirtualcaptualoperationId:{0} 无法更新状态，发生版本冲突！", vid);
//                }
//            }
//        }
//    }
//}