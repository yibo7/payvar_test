using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XS.DataProfile.Dapper.Contrib;

namespace WalletMiddleware.TableModels
{
    /// <summary>
    ///  walletaddrecore  钱包的地址内核关联表(同一个内核可以使用相同的地址，如eth及以下的代币可以使用相同的地址)
    ///  钱包内核表
    /// </summary>
    [Table("walletaddrecore")]
    public class walletaddrecore
    {
        [Key]
        public int Id { get; set; }
        public string WalletName { get; set; }
        /// <summary>
        /// 此变量不是表字段
        /// </summary>
        public string Symbol { get; set; }
        public int MinNum { get; set; }
        public DateTime AddTime { get; set; }
        public int ConfirmNum { get; set; }
        /// <summary>
        /// 最后提醒时间，半小时提醒一次,此变量不是表字段，为静态变量
        /// </summary>
        public DateTime? LastTipsTime { get; set; }
        public int NeedAddAddress { get; set; }        
    }
}
