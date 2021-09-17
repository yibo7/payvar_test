using System;
using WalletContracts.Comm;
using XS.DataProfile.Dapper.Contrib;

namespace WalletMiddleware.TableModels
{
    /// <summary>
    /// fpool 地址池表 
    /// 
    /// </summary>
    [Table("fpool")] 
    [Serializable]
    public class pooladdr
	{
	    [Key]
        public int fid { get; set; }
	    /// <summary>
	    /// 法币外键表id
	    /// </summary>
	    public int fvi_type { get; set; }
        /// <summary>
        /// 虚拟货币地址
        /// </summary>
        public string faddress { get; set; }
        /// <summary>
        /// 使用状态：０未使用，１已使用
        /// </summary>
        public int fstatus { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>
        public int version { get; set; }
        /// <summary>
        /// 钱包传来的数字签名
        /// </summary>
        public string faddressaes { get; set; }
        /// <summary>
        /// 本站自己的数字签名
        /// </summary>
        public string faddressver { get; set; }
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 币种类型名称
        /// </summary>
        public string CoinTypeName { get; set; }

        public string GetMdwu()
	    {
            //本条记录的哈希值（faddress+fvi_type+密钥的小写32位md5）
            return HashHelper.GetHashStr(string.Format("{0}{1}", faddress, fvi_type));
	    }
        /// <summary>
        /// 标记 0：不发送 1：已发送
        /// </summary>
        public int IsSend { get; set; }

    }

    

    
}

