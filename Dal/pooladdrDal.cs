using Dapper;
using MySql.Data.MySqlClient;

namespace WalletMiddleware.Dal
{
    /// <summary>
    /// 地址
    /// </summary>
    public class pooladdrDal: DbBaseRiskCheck<TableModels.pooladdr>
    {
        public static readonly pooladdrDal Instane = new pooladdrDal();

        public bool IsHave(string mdwu)
        {
           return Exists(string.Format("faddressaes='{0}'", mdwu));
        }

        public bool BatchUpdate(string ids)
        {
            using (var connection = GetConn)
            {
                string sql = $"update fpool set IsSend = 1 where fid in ({ids})";

                int rz = connection.Execute(sql);
                if (rz == 0)
                {
                    XS.Core.Log.InfoLog.InfoFormat("修改{0}充值记录发送状态失败", ids);
                    return false;                    
                }
                return true;
            }                
        }
    }
}
