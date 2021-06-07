//using System;
//using XS.DataProfile.Dapper.Contrib;

//namespace WalletMiddleware.TableModels
//{



//    //[Table("fund_cointype")]
//    //public class fund_cointype
//    //{
//    //    [Key]
//    //    public int id { get; set; }
//    //    public int walletType { get; set; }
//    //    public int coinTypeId { get; set; }
//    //    /// <summary>
//    //    /// 名称
//    //    /// </summary>
//    //    public string coinTypeName { get; set; }
//    //    /// <summary>
//    //    /// 简称  对应钱包中的币种类型
//    //    /// </summary>
//    //    public string coinShortName { get; set; }
//    //    /// <summary>
//    //    /// 描述
//    //    /// </summary>
//    //    public string furl { get; set; }
//    //    /// <summary>
//    //    /// 创建时间
//    //    /// </summary>
//    //    public DateTime fAddTime { get; set; }
//    //    /// <summary>
//    //    /// 描述
//    //    /// </summary>
//    //    public string fDesc { get; set; }
//    //    public int fstatus { get; set; }
//    //    public int istrade { get; set; }
//    //    public int maxdecimalplace { get; set; }
//    //    public decimal trademinamount { get; set; }
//    //    public decimal trademaxamount { get; set; }
//    //    public int isrecharge { get; set; }
//    //    public int iswithdrawal { get; set; }
//    //}

//    /// <summary>
//    /// fvirtualcointype 币种表  虚拟货币类型表
//    /// </summary>
//    //[Table("fvirtualcointype")]
//    public class virtualcointype 
//	{
//	    [Key]
//        public int fid { get; set; }  
//		/// <summary>
//		/// 名称
//		/// </summary>
//		public string fName { get; set; }
//        /// <summary>
//        /// 简称  对应钱包中的币种类型
//        /// </summary>
//        public string fShortName { get; set; }
//        /// <summary>
//        /// 描述
//        /// </summary>
//        public string fDescription { get; set; }
//        /// <summary>
//        /// 创建时间
//        /// </summary>
//        public DateTime fAddTime { get; set; }
//        /// <summary>
//        /// 状态:1正常,2禁用
//        /// </summary>
//        public int fstatus { get; set; }
//        /// <summary>
//        /// 
//        /// </summary>
//        public int version { get; set; }
//        /// <summary>
//        /// 
//        /// </summary>
//        public string fbackground { get; set; }
//        /// <summary>
//        /// 符号
//        /// </summary>
//        public string fSymbol { get; set; }
//        /// <summary>
//        /// 
//        /// </summary>
//        public string faccess_key { get; set; }
//        /// <summary>
//        /// 
//        /// </summary>
//        public string fsecrt_key { get; set; }
//        /// <summary>
//        /// ip地址
//        /// </summary>
//        public string fip { get; set; }
//        /// <summary>
//        /// 端口号
//        /// </summary>
//        public string fport { get; set; }
//        /// <summary>
//        /// 是否可以提现
//        /// </summary>
//        public int FIsWithDraw { get; set; }
//        /// <summary>
//        /// 
//        /// </summary>
//        public string furl { get; set; }
//        /// <summary>
//        /// 
//        /// </summary>
//        public string fweburl { get; set; }
//        /// <summary>
//        /// 虚拟币类型，是否法币：0是,2否
//        /// </summary>
//        public int ftype { get; set; }
//        /// <summary>
//        /// 充值是否可以到帐
//        /// </summary>
//        public int fisauto { get; set; }
//        /// <summary>
//        /// 是否可以充值
//        /// </summary>
//        public int fisrecharge { get; set; }
//        /// <summary>
//        /// 
//        /// </summary>
//        public decimal fmaxqty { get; set; }
//        /// <summary>
//        /// 
//        /// </summary>
//        public decimal fminqty { get; set; }
//        /// <summary>
//        /// 
//        /// </summary>
//        public int isEth { get; set; }
//        /// <summary>
//        /// 
//        /// </summary>
//        public string mainAddr { get; set; }
//        /// <summary>
//        /// 
//        /// </summary>
//        public int startBlockId { get; set; }
//        /// <summary>
//        /// 
//        /// </summary>
//        public int fispush { get; set; }
//        /// <summary>
//        /// 
//        /// </summary>
//        public decimal fpushRate { get; set; }
//        /// <summary>
//        /// 
//        /// </summary>
//        public decimal fpushMaxQty { get; set; }
//        /// <summary>
//        /// 
//        /// </summary>
//        public decimal fpushMinQty { get; set; }
//        /// <summary>
//        /// 
//        /// </summary>
//        public decimal fpushMaxPrice { get; set; }
//        /// <summary>
//        /// 
//        /// </summary>
//        public decimal fpushMinPrice { get; set; }
//        /// <summary>
//        /// 
//        /// </summary>
//        public int fisetp { get; set; }
//        /// <summary>
//        /// 
//        /// </summary>
//        public int fisautosend { get; set; }
//        /// <summary>
//        /// 
//        /// </summary>
//        public string fpassword { get; set; }
//        ///// <summary>
//        ///// 
//        ///// </summary>
//        //public int fconfirm { get; set; }
//        /// <summary>
//        /// 
//        /// </summary>
//        public int faddressCount { get; set; }
//        /// <summary>
//        /// 币种的最小单位后面0的个数(钱包交互需要)
//        /// </summary>
//        public int decimals { get; set; }
//        /// <summary>
//        /// 排序
//        /// </summary>
//        public int weight { get; set; }
//        /// <summary>
//        /// 当前这个币种的提现手续费，由钱包api定时更新(慢)
//        /// </summary>
//        public decimal feesA { get; set; }
//        /// <summary>
//        /// 当前这个币种的提现手续费，由钱包api定时更新(中)
//        /// </summary>
//	    public decimal feesB { get; set; }
//        /// <summary>
//        /// 当前这个币种的提现手续费，由钱包api定时更新(快)
//        /// </summary>
//	    public decimal feesC { get; set; }
//        /// <summary>
//        /// 钱包的地址内核关联表Id（有些钱包地址是共用一个核心的）
//        /// </summary>
//        public int walletaddrecoreid { get; set; }
//        [Computed]
//	    public int ConfirmNum { get; set; }

//        /// <summary>
//        /// 是否刷新手续费
//        /// </summary>
//        public int isFlushFees { get; set; }
//    }
//}

