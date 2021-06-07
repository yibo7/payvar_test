//using System;
//using WalletContracts.Comm;
//using XS.DataProfile.Dapper.Contrib;

//namespace WalletMiddleware.TableModels
//{
//    /// <summary>
//    /// 提币表,目前本系统只有提币用到 
//    /// </summary>
//    public class virtualcaptualoperation 
//	{
//        /// <summary>
//        /// 记录主键
//        /// </summary>
//        [Key]
//        public int fId { get; set; }
//        /// <summary>
//        /// 用户id
//        /// </summary>
//        public int FUs_fId2 { get; set; }
//		/// <summary>
//		/// 货币类型id
//		/// </summary>
//		public int fVi_fId2 { get; set; }
//        /// <summary>
//        /// 创建日期
//        /// </summary>
//        public DateTime fCreateTime { get; set; }
//        /// <summary>
//        /// 数量
//        /// </summary>
//        public decimal fAmount { get; set; }
//        /// <summary>
//        /// 手续费
//        /// </summary>
//        public decimal ffees { get; set; }
//        /// <summary>
//        /// 类型:1虚拟币充值,2虚拟币提现
//        /// </summary>
//        public int fType { get; set; }
//        /// <summary>
//        /// 状态
//        /// 充值:0.等待确认,1.已确认  
//	    /// 提现:1.申请提现 2.邮件确认，3.等待一级审核 4.等待二级审核 5.等待发币 6.发币完成 7.减持冻结资金
//        /// </summary>
//        public int fStatus { get; set; }
//        /// <summary>
//        /// 版本号
//        /// </summary>
//        public int version { get; set; }
//        /// <summary>
//        /// 提现地址
//        /// </summary>
//        public string withdraw_virtual_address { get; set; }
//        /// <summary>
//        /// 充值地址
//        /// </summary>
//        public string recharge_virtual_address { get; set; }
//        /// <summary>
//        /// 钱包交易订单号(交易的hash)
//        /// </summary>
//        public string ftradeUniqueNumber { get; set; }
//        /// <summary>
//        /// 确认数
//        /// </summary>
//        public int fconfirmations { get; set; }
//        /// <summary>
//        /// 这个地址是否有主人
//        /// </summary>
//        public int fhasOwner { get; set; }
//        /// <summary>
//        /// 交易所校验的md5值
//        /// </summary>
//        public string mdwu { get; set; }
//        /// <summary>
//        /// 本系统验证的md5值,此值在状态为5以下时为空,交易所只有在将状态更改成5时才需要写入此值
//        /// (用户id+"-"+货币类型id+"-"+数量+"-"+手续费+"-"+fType"-"+提现地址+"-"+"fStatus"+WalletContracts私钥)的md5值
//        /// </summary>
//	    public string riskmdwu { get; set; }
//        /// <summary>
//        /// 实际到账金额 fAmount-ffees
//        /// </summary>
//        public decimal fAmountPay { get; set; }


//        public bool CheckMdwu()
//	    {
//            var famount = fAmount.ToString("0.##################");
//            var fee = ffees.ToString("0.##################");

//           string str = string.Format("{0}-{1}-{2}-{3}-{4}-{5}-{6}",
//	           FUs_fId2, fVi_fId2, famount, fee, fType, withdraw_virtual_address, fStatus
//               );
//	       return HashHelper.CheckHashStr(str, riskmdwu);
//	    }
       
//    }

    
    
//}

