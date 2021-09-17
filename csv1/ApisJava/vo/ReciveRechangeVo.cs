using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletMiddleware.ApisJava.vo
{
    /// <summary>
    /// 接收用户充值实体对象
    /// </summary>
    public class ReciveRechangeVo
    {

        /// <summary>
        /// 币种名称
        /// </summary>
        public string coinType { get; set; }

        /// <summary>
        /// 交易时间
        /// </summary>
        public DateTime transTime { get; set; }
        /// <summary>
        /// 来源
        /// </summary>
        public string fromAddr { get; set; }
        /// <summary>
        /// 目标
        /// </summary>
        public string toAddr { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal amountDecimal { get; set; }

        /// <summary>
        /// 手续费
        /// </summary>
        public decimal feeDecimal { get; set; }


        /// <summary>
        /// 提币记录的id，交易所提现表 id  txid
        /// </summary>
        public string txid { get; set; }

        /// <summary>
        /// sqlserver ID
        /// </summary>
        public long walletDataId { get; set; }

        /// <summary>
        /// 确认数
        /// </summary>
        public int corfirm { get; set; }
        /// <summary>
        ///  用户GID+币种名称+收币地址+金额【8位小数】+用户私钥 +延值
        /// </summary>
        public string mdwu { get; set; }
    }
}
