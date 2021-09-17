using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XS.DataProfile.Dapper.Contrib;

namespace RiskCheck.TableModels
{
    /// <summary>
    /// 归总从表
    /// </summary>
    [Table("collectapplyitem")]
    public class CollectApplyItem
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        ///  父idcollectapple主键ID
        /// </summary>
        public int fid { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string coinAddress { get; set; }
        /// <summary>
        ///  归总数量
        /// </summary>
        public decimal quantity { get; set; }
        /// <summary>
        ///  手续费
        /// </summary>
        public decimal feeHand { get; set; }
        /// <summary>
        /// 补充手续费
        /// </summary>
        public decimal prefeeHand { get; set; }
        /// <summary>
        /// 是否充足
        /// </summary>
        public bool isSuff { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime addDateTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime updateDateTime { get; set; }


    }
}
