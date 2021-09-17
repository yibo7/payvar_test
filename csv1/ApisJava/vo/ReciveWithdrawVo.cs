using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletMiddleware.ApisJava.vo
{
    /// <summary>
    /// 接收用户提现的结果
    /// </summary>
   public class ReciveWithdrawVo
    {
        /// <summary>
        /// 币名称        
        /// </summary>
        public string coinName { get; set; }
       /// <summary>
       /// txid
       /// </summary>
        public string blockHash { get; set; }
        /// <summary>
        /// 手续费-decimal 类型
        /// </summary>
        public decimal freeDecimal { get; set; }
        /// <summary>
        ///  用户gid
        /// </summary>
        public string userGid { get; set; }

        /// <summary>
        /// 0:处理中， 1：成功 2：失败
        /// </summary>
        public int states { get; set; }
        /// <summary>
        /// 交易所的id
        /// </summary>
        public string orderId { get; set; }

        /// <summary>
        /// mdwu  用户GID+txid+orderId 用户私钥 +延值
        /// </summary>
        public string mdwu { get; set; }
    }
}
