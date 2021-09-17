using System;
using XS.DataProfile.Dapper.Contrib;

namespace WalletMiddleware.TableModels
{
    /// <summary>
    /// withdrawlist 提现记录表  发币记录
    /// 作用：是记录已经发过的，不要重复发送。 2019-8-16
    /// </summary>
    [Table("withdrawlist")]
    public class WithdrawList
    {
        [Key]
        public long Id { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 币种Id
        /// </summary>
        public int CoinTypeId { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 手续费
        /// </summary>
        public decimal Fees { get; set; }
        /// <summary>
        /// 提现地址
        /// </summary>
        public string WithdrawAddress { get; set; }
        /// <summary>
        /// 交易Id
        /// </summary>
        public string TxId { get; set; } 
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 发币的热钱包
        /// </summary>
        public string FromAddress { get; set; }
        /// <summary>
        /// 提币记录的id，交易所提现表 id
        /// </summary>
        public int VirtualcaptualoperationId { get; set; }
        /// <summary>
        /// 状态，是否已经发币 
        /// 0.未   1.接收wcf成功的结果   2.调用wcf返回失败结果【需要手动 查看原因，并改为 0 或 4】   3.已发送到交易所   4.地址写错【用户原因】 
        /// 5.只要发送给钱包就设置为 5
        /// 1和4 需要通知交易所
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int Version { get; set; }
        /// <summary>
        /// 是否已经发送过错误报告
        /// </summary>
        public int IsErrReport { get; set; }

        /// <summary>
        /// 增加字段 Tag
        ///枚举- 0:从交易所采集下  1：wcf服务已处理  2：已发送到交易所  3:异常 【需要手动 查看原因，并改为 1或4】 4.地址写错【用户原因】
        ///Tag=0：去发币，写txid  ffee，Tag=1；
        ///Tag=1：调api接口，通知交易所更新txid,ffees后    ,修改 Tag=2
        /// </summary>
       //public int Tag { get; set; }

    }

   
}