//using System;
//using WalletContracts.Comm;
//using XS.DataProfile.Dapper.Contrib;

//namespace WalletMiddleware.TableModels
//{
//    /// <summary>
//    /// ��ұ�,Ŀǰ��ϵͳֻ������õ� 
//    /// </summary>
//    public class virtualcaptualoperation 
//	{
//        /// <summary>
//        /// ��¼����
//        /// </summary>
//        [Key]
//        public int fId { get; set; }
//        /// <summary>
//        /// �û�id
//        /// </summary>
//        public int FUs_fId2 { get; set; }
//		/// <summary>
//		/// ��������id
//		/// </summary>
//		public int fVi_fId2 { get; set; }
//        /// <summary>
//        /// ��������
//        /// </summary>
//        public DateTime fCreateTime { get; set; }
//        /// <summary>
//        /// ����
//        /// </summary>
//        public decimal fAmount { get; set; }
//        /// <summary>
//        /// ������
//        /// </summary>
//        public decimal ffees { get; set; }
//        /// <summary>
//        /// ����:1����ҳ�ֵ,2���������
//        /// </summary>
//        public int fType { get; set; }
//        /// <summary>
//        /// ״̬
//        /// ��ֵ:0.�ȴ�ȷ��,1.��ȷ��  
//	    /// ����:1.�������� 2.�ʼ�ȷ�ϣ�3.�ȴ�һ����� 4.�ȴ�������� 5.�ȴ����� 6.������� 7.���ֶ����ʽ�
//        /// </summary>
//        public int fStatus { get; set; }
//        /// <summary>
//        /// �汾��
//        /// </summary>
//        public int version { get; set; }
//        /// <summary>
//        /// ���ֵ�ַ
//        /// </summary>
//        public string withdraw_virtual_address { get; set; }
//        /// <summary>
//        /// ��ֵ��ַ
//        /// </summary>
//        public string recharge_virtual_address { get; set; }
//        /// <summary>
//        /// Ǯ�����׶�����(���׵�hash)
//        /// </summary>
//        public string ftradeUniqueNumber { get; set; }
//        /// <summary>
//        /// ȷ����
//        /// </summary>
//        public int fconfirmations { get; set; }
//        /// <summary>
//        /// �����ַ�Ƿ�������
//        /// </summary>
//        public int fhasOwner { get; set; }
//        /// <summary>
//        /// ������У���md5ֵ
//        /// </summary>
//        public string mdwu { get; set; }
//        /// <summary>
//        /// ��ϵͳ��֤��md5ֵ,��ֵ��״̬Ϊ5����ʱΪ��,������ֻ���ڽ�״̬���ĳ�5ʱ����Ҫд���ֵ
//        /// (�û�id+"-"+��������id+"-"+����+"-"+������+"-"+fType"-"+���ֵ�ַ+"-"+"fStatus"+WalletContracts˽Կ)��md5ֵ
//        /// </summary>
//	    public string riskmdwu { get; set; }
//        /// <summary>
//        /// ʵ�ʵ��˽�� fAmount-ffees
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

