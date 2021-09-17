using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletMiddleware.ApisJava.vo
{
    /// <summary>
    /// 接收 热钱包对象
    /// </summary>
    public class ReciveHotWalletVo
    {

        /// <summary>
        /// 币的ID。作用：用户发起提币和取到提币结果时用到。
        /// </summary>
        public long CoinTypeId { get; set; }

        /**
         * 热地址
        */
        public string Addr { get; set; }

        /**
         * 币种名称
         */
        public string CoinType { get; set; }

        /**
         * 热金额
         */
        public decimal HotSum { get; set; }

        /**
         * 冷金额
         */
        public decimal CoolSum { get; set; }

        /**
         * mdwu  币种+热地址+用户ID+热金额+冷金额 + 用户私钥 +延值  md5 1次
         */
        public string MdWu { get; set; }
    }
}
