using System;
using WalletContracts.Comm;
using XS.DataProfile.Dapper.Contrib;
namespace WalletMiddleware.TableModels
{
    [Table("applicationlock")]
    public class ApplicationLock
    {
        [Key]
        public int id { get; set; }
        /// <summary>
        /// job 的标实
        /// 【更新热钱包的金额 】HotWalletCoinBig    10分钟
        /// 【包地址并更新】UpdateAddrPoolCoinBig    3小时
        /// 【充值记录 】RechargeInDataCoinBig       10分钟   【更新确认数】RechargeConfirmCoinBig  10分钟 
        /// 【提币】SendTransactionCoinBig           10分钟 
        /// </summary>
        public string lockkey { get; set; }
        /// <summary>
        /// job 的说明
        /// </summary>
        public string info { get; set; }
        /// <summary>
        /// 记录每个job的过期时间，单位秒。
        /// 若时间到了，要删除这条记录。
        /// </summary>
        public int timeoutvalue { get; set; }



    }
}
