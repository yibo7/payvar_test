using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletMiddleware.Apis.Models
{
    public class VirtualCoinType
    {
        /// <summary>
        /// 币种id
        /// </summary>
        public int fid { get; set; }
        /// <summary>
        /// 币种简称
        /// </summary>
        public string fShortName { get; set; }
        /// <summary>
        /// 钱包的地址内核关联表Id（有些钱包地址是共用一个核心的）
        /// </summary>
        public int walletaddrecoreid { get; set; }
        /// <summary>
        /// 确认数
        /// </summary>
        public int ConfirmNum { get; set; }
    }
}
