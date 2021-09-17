using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletMiddleware.Apis.Models
{
    public class HotWalletUpdateRequest
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 币种名称
        /// </summary>
        public string CoinName { get; set; }
        /// <summary>
        /// 钱包地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Md5
        /// </summary>
        public string MdWu { get; set; }
        /// <summary>
        /// 冷钱包余额
        /// </summary>
        public decimal ColdAmount { get; set; }
        /// <summary>
        /// 热钱包余额
        /// </summary>
        public decimal Amount { get; set; }

        public int CurrId { get; set; }
    }
}
