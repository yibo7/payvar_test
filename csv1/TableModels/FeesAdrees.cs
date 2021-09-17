using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XS.DataProfile.Dapper.Contrib;

namespace RiskCheck.TableModels
{
    [Table("feesadrees")]
    public class FeesAdrees
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 币种Id
        /// </summary>
        public int coinId { get; set; }
        /// <summary>
        /// 币种名称
        /// </summary>
        public string coinName { get; set; }
        /// <summary>
        /// 预警下线数量
        /// </summary>
        public decimal downLine { get; set; }
        /// <summary>
        /// 添加人账号
        /// </summary>
        public string addUserName { get; set; }
        /// <summary>
        /// 添加人Id
        /// </summary>
        public int addUserId { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime addDateTime { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string  targetAdress{get;set;}
        /// <summary>
        ///  md5值(币种Id+"-"targetAdress+网站私钥)的md5值',
        /// </summary>
        public string mdwu { get; set; }
       
    }
}
