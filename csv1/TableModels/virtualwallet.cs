using System;
using XS.DataProfile.Dapper.Contrib;

namespace RiskCheck.TableModels
{
    /// <summary>
    /// 实体类virtualwallet 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("fvirtualwallet")]
    public class virtualwallet 
	{
		 
		#region Model
		private int _fvi_fid;
		private decimal _ftotal;
		private decimal _ffrozen;
		private DateTime _flastupDateTime;
		private int _fuid;
		private decimal _fborrowbtc;
		private decimal _fcanlendbtc;
		private decimal _ffrozenlendbtc;
		private decimal _falreadylendbtc;
		private int _version;
		private decimal _fhaveappointborrowbtc;
		private string _ftotalaes;
		private string _ftotalver;
		private string _ffrozenaes;
		private string _ffrozenver;
		/// <summary>
		/// 货币类型id(fvirtualcointype的id)
		/// </summary>
		public int fVi_fId
		{
			set{ _fvi_fid=value;}
			get{return _fvi_fid;}
		}
		/// <summary>
		/// 总数量
		/// </summary>
		public decimal fTotal
		{
			set{ _ftotal=value;}
			get{return _ftotal;}
		}
		/// <summary>
		/// 冻结数量
		/// </summary>
		public decimal fFrozen
		{
			set{ _ffrozen=value;}
			get{return _ffrozen;}
		}
		/// <summary>
		/// 更新时间
		/// </summary>
		public DateTime fLastUpDateTime
		{
			set{ _flastupDateTime=value;}
			get{return _flastupDateTime;}
		}
		/// <summary>
		/// 用户id
		/// </summary>
		public int fuid
		{
			set{ _fuid=value;}
			get{return _fuid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal fBorrowBtc
		{
			set{ _fborrowbtc=value;}
			get{return _fborrowbtc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal fCanlendBtc
		{
			set{ _fcanlendbtc=value;}
			get{return _fcanlendbtc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal fFrozenLendBtc
		{
			set{ _ffrozenlendbtc=value;}
			get{return _ffrozenlendbtc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal fAlreadyLendBtc
		{
			set{ _falreadylendbtc=value;}
			get{return _falreadylendbtc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int version
		{
			set{ _version=value;}
			get{return _version;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal fHaveAppointBorrowBtc
		{
			set{ _fhaveappointborrowbtc=value;}
			get{return _fhaveappointborrowbtc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fTotalaes
		{
			set{ _ftotalaes=value;}
			get{return _ftotalaes;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fTotalver
		{
			set{ _ftotalver=value;}
			get{return _ftotalver;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fFrozenaes
		{
			set{ _ffrozenaes=value;}
			get{return _ffrozenaes;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fFrozenver
		{
			set{ _ffrozenver=value;}
			get{return _ffrozenver;}
		}
		#endregion Model

	}
}

