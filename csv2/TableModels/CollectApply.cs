using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XS.DataProfile.Dapper.Contrib;

namespace RiskCheck.TableModels
{
    /// <summary>
    /// 归总主表
    /// </summary>
    [Table("collectapply")]
    public class CollectApply
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 币种Id
        /// </summary>
        public int coinId { get; set; }
        /// <summary>
        ///  币种名称
        /// </summary>
        public string coinName { get; set; }
        /// <summary>
        /// 归总数量
        /// </summary>
        public decimal quantity { get; set; }
        /// <summary>
        ///  归类类型(1.热钱包，2.手续费)
        /// </summary>
        public int collectType { get; set; }
        /// <summary>
        ///  审核人账号
        /// </summary>
        public string auditUserName { get; set; }
        /// <summary>
        /// 审核人Id
        /// </summary>
        public int auditUserId { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime auditDateTime { get; set; }
        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime addDateTime { get; set; }
        /// <summary>
        /// 1.等待审核,2.手续费计算中【风控】 3.待打手续费【风控】,4.等待归总(向钱包发起生成归总数据)【风控】5.归总完成 【风控】6.归总取消
        /// </summary>
        public int auditState { get; set; }
        /// <summary>
        /// 归总地址
        /// </summary>
        public string targetAdress { get; set; }
        /// <summary>
        /// 归总手续费
        /// </summary>
        public decimal feeHandCount { get; set; }
        /// <summary>
        /// 预充手续费
        /// </summary>
        public decimal prefeeHandCount { get; set; }
        /// <summary>
        /// md5值(币种Id+"-"+归总数量+"-"+归类类型+"-"+归总地址+网站私钥)的md5值 
        /// </summary>
        public string mdwu { get; set; }
    }
}
