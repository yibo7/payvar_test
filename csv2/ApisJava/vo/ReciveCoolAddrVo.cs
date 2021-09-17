using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletMiddleware.ApisJava.vo
{
    /// <summary>
    /// 接收的冷地址对象
    /// </summary>
    public class ReciveCoolAddrVo
    {
        // 冷地址
        public string Addr { get; set; }

        //币种名称
        public string CoinType { get; set; }

        //mdwu  币种+冷地址+用户ID+用户私钥 +延值  md5 1次  
        public string MdWu { get; set; }
    }
}
