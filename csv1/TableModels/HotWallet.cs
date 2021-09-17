using System;
using WalletContracts.Comm;
using XS.DataProfile.Dapper.Contrib;

namespace WalletMiddleware.TableModels
{
    /// <summary>
    /// hotwallet热钱包表，内存中存储。
    /// </summary>
    public class HotWallet
    {
        /// <summary>
        /// 自增id
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 钱包地址
        /// </summary>
        public string Address{ get; set; }
      
        /// <summary>
        /// 热钱包数量
        /// </summary>
        public decimal Amount{ get; set; }
        /// <summary>
        /// 冷钱包字段
        /// </summary>
        public decimal ColdAmount { get; set; }
        /// <summary>
        /// 币种id
        /// </summary>
        public int CoinId{ get; set; }
        /// <summary>
        /// 币种名称
        /// </summary>
        public string CoinName{ get; set; }


        /// <summary>
        /// 状态  0.新建 1.启用 
        /// </summary>
        public int Status{ get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MdWu { get; set; }
        /// <summary>
        /// 币名称
        /// </summary>
        public string CoinType { get; set; }
        /// <summary>
        /// 热钱包最低金额
        /// </summary>
		public decimal CalcTips { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public DateTime LastCalcTipTime { get; set; }
       

        /// <summary>
        /// 是否修改
        /// 包括：新的地址，金额发生改变的。
        /// </summary>
        public bool IsChange { get; set; }


        public string GetMdWu(string str)
        {
            return HashHelper.GetHashStr(str);
        }
    }

   
}