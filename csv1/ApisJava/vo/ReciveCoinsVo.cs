using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletMiddleware.ApisJava.vo
{
  public  class ReciveCoinsVo
    {
        //币ID
        public long coinId { get; set; }
        //币名称
        public string coinTypeName { get; set; }

        //冷钱包金额
        public decimal coolSum { get; set; }

        //热钱包金额
        public decimal hotSum { get; set; }
        /// <summary>
        /// 手续费金额
        /// </summary>
        public decimal feeSum { get; set; }

        //币对应的热钱包地址列表
        public List<HotTemp> mHotTempList { get; set; }
    }
    public class HotTemp
    {
        //币 地址
        public string coinAddress { get; set; }

        //是否 默认
        public bool isDefault { get; set; }

        //来源 如  coinbig  ,ok
        public string comFrom { get; set; }


    }
}
