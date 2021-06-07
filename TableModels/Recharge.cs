using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletContracts.Comm;
using XS.DataProfile.Dapper.Contrib;

namespace WalletMiddleware.TableModels
{
    /// <summary>
    /// recharge 充值记录表
    /// </summary>
    [Serializable]
    [Table("recharge")]
    public class Recharge
    {
        [Key]
        public long Id { get; set; }

        //币种
        public String CoinType { get; set; }
        //本条记录的哈希值（FromAddr+ToAddr+Amount+Fee+CoinType+TxId+密钥的小写32位md5）
        public String Hash { get; set; }
        //交易时间
        public long TransTime { get; set; }
        //来自的地址
        public String FromAddr { get; set; }
        //充值地址
        public String ToAddr { get; set; }
        //充值数量
        public decimal Amount { get; set; }
        //矿工费
        public decimal Fee { get; set; }
        //来自的用户id
        public Guid FromUserId { get; set; }
        //用户id
        public Guid ToUserId { get; set; }
        /// <summary>
        /// 交易所用户的Id
        /// </summary>
        public int EbChangeUserId { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 状态,0未提交，1.已经成功更新到主站表,2.找不到用户 3.失败，4.md5校验失败 
        /// </summary>
        public int States { get; set; }
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int Version { get; set; }
        /// <summary>
        /// 确认数
        /// </summary>
        public int Confirm { get; set; } 
        /// <summary>
        /// 交易Id
        /// </summary>
        public string TxId { get; set; }
        /// <summary>
        /// 钱包方的数据id 可以用来与钱包方数据对接
        /// </summary>
        public long WalletDataId { get; set; }

        /// <summary>
        /// false:正在充值的路上。
        /// true:已经告诉 钱包，成功充值到交易所。
        /// 是否，已经通过钱包方 已经成功。
        /// </summary>
        //public bool IsBackSucess { get; set; }

        public string GetMdwu()
        {
            //本条记录的哈希值（FromAddr+ToAddr+Amount+Fee+CoinType+TxId+密钥的小写32位md5）
            //return HashHelper.GetHashStr(string.Format("{0}{1}{2}{3}{4}{5}", FromAddr, ToAddr, Amount.ToString("0.########"), Fee.ToString("0.########"), CoinType, TxId));
            return HashHelper.GetHashStr(string.Format("{0}{1}{2}{3}{4}", FromAddr, ToAddr, Amount.ToString("0.########"),  CoinType, TxId));
        }
        /// <summary>
        /// 从wcf 得到的sign
        /// 作用：交易所去验证 数据是否被篡改
        /// </summary>
        //public string wcfMdwu { get; set; }

        /// <summary>
        ///  0:没有发送给交易所  1:已发送交易所  2.已经告诉钱包 【只有是2的，才可以得到更新确认数】  --3:已达到确认数【不用】 
        ///  2020-4-10 Tag 4 :标记成交易所已存在的数据，需要人工核实处理。
        /// 2019-11-28  新的说明如下：
        ///  0:没有发送给交易所  1:已发送交易所  【因为从java api取到的用户充值 已经达到设置的确认数了。不用再从新获得了。】
        /// </summary>
        public int Tag { get; set; }
    }

   /// <summary>
   /// 组织数据 
   /// </summary>
    public class RechargeTemp
    {
        public long Id { get; set; }
        public String Hash { get; set; }
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int Version { get; set; }
        /// <summary>
        /// 确认数
        /// </summary>
        public int Confirm { get; set; }

    }
}
