using System;
using WalletContracts.Comm;
using XS.DataProfile.Dapper.Contrib;

namespace WalletMiddleware.TableModels
{
    /// <summary>
    /// fpool ��ַ�ر� 
    /// 
    /// </summary>
    [Table("fpool")] 
    [Serializable]
    public class pooladdr
	{
	    [Key]
        public int fid { get; set; }
	    /// <summary>
	    /// ���������id
	    /// </summary>
	    public int fvi_type { get; set; }
        /// <summary>
        /// ������ҵ�ַ
        /// </summary>
        public string faddress { get; set; }
        /// <summary>
        /// ʹ��״̬����δʹ�ã�����ʹ��
        /// </summary>
        public int fstatus { get; set; }
        /// <summary>
        /// �汾��
        /// </summary>
        public int version { get; set; }
        /// <summary>
        /// Ǯ������������ǩ��
        /// </summary>
        public string faddressaes { get; set; }
        /// <summary>
        /// ��վ�Լ�������ǩ��
        /// </summary>
        public string faddressver { get; set; }
        public DateTime AddTime { get; set; }
        /// <summary>
        /// ������������
        /// </summary>
        public string CoinTypeName { get; set; }

        public string GetMdwu()
	    {
            //������¼�Ĺ�ϣֵ��faddress+fvi_type+��Կ��Сд32λmd5��
            return HashHelper.GetHashStr(string.Format("{0}{1}", faddress, fvi_type));
	    }
        /// <summary>
        /// ��� 0�������� 1���ѷ���
        /// </summary>
        public int IsSend { get; set; }

    }

    

    
}

