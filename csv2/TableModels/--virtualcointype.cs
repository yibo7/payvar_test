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
//    //    /// ����
//    //    /// </summary>
//    //    public string coinTypeName { get; set; }
//    //    /// <summary>
//    //    /// ���  ��ӦǮ���еı�������
//    //    /// </summary>
//    //    public string coinShortName { get; set; }
//    //    /// <summary>
//    //    /// ����
//    //    /// </summary>
//    //    public string furl { get; set; }
//    //    /// <summary>
//    //    /// ����ʱ��
//    //    /// </summary>
//    //    public DateTime fAddTime { get; set; }
//    //    /// <summary>
//    //    /// ����
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
//    /// fvirtualcointype ���ֱ�  ����������ͱ�
//    /// </summary>
//    //[Table("fvirtualcointype")]
//    public class virtualcointype 
//	{
//	    [Key]
//        public int fid { get; set; }  
//		/// <summary>
//		/// ����
//		/// </summary>
//		public string fName { get; set; }
//        /// <summary>
//        /// ���  ��ӦǮ���еı�������
//        /// </summary>
//        public string fShortName { get; set; }
//        /// <summary>
//        /// ����
//        /// </summary>
//        public string fDescription { get; set; }
//        /// <summary>
//        /// ����ʱ��
//        /// </summary>
//        public DateTime fAddTime { get; set; }
//        /// <summary>
//        /// ״̬:1����,2����
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
//        /// ����
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
//        /// ip��ַ
//        /// </summary>
//        public string fip { get; set; }
//        /// <summary>
//        /// �˿ں�
//        /// </summary>
//        public string fport { get; set; }
//        /// <summary>
//        /// �Ƿ��������
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
//        /// ��������ͣ��Ƿ񷨱ң�0��,2��
//        /// </summary>
//        public int ftype { get; set; }
//        /// <summary>
//        /// ��ֵ�Ƿ���Ե���
//        /// </summary>
//        public int fisauto { get; set; }
//        /// <summary>
//        /// �Ƿ���Գ�ֵ
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
//        /// ���ֵ���С��λ����0�ĸ���(Ǯ��������Ҫ)
//        /// </summary>
//        public int decimals { get; set; }
//        /// <summary>
//        /// ����
//        /// </summary>
//        public int weight { get; set; }
//        /// <summary>
//        /// ��ǰ������ֵ����������ѣ���Ǯ��api��ʱ����(��)
//        /// </summary>
//        public decimal feesA { get; set; }
//        /// <summary>
//        /// ��ǰ������ֵ����������ѣ���Ǯ��api��ʱ����(��)
//        /// </summary>
//	    public decimal feesB { get; set; }
//        /// <summary>
//        /// ��ǰ������ֵ����������ѣ���Ǯ��api��ʱ����(��)
//        /// </summary>
//	    public decimal feesC { get; set; }
//        /// <summary>
//        /// Ǯ���ĵ�ַ�ں˹�����Id����ЩǮ����ַ�ǹ���һ�����ĵģ�
//        /// </summary>
//        public int walletaddrecoreid { get; set; }
//        [Computed]
//	    public int ConfirmNum { get; set; }

//        /// <summary>
//        /// �Ƿ�ˢ��������
//        /// </summary>
//        public int isFlushFees { get; set; }
//    }
//}

