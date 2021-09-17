using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletMiddleware.ApisJava
{
    public enum JUrlEnum
    {
       
        /// <summary>
        /// 批量从java api中采集冷地址
        /// </summary>
        GatherAddrs,

        /// <summary>
        /// 得到热钱包的余额和新增加的热地址
        /// </summary>
        GetHotWallets,

        /// <summary>
        /// 上传 用户提现数据
        /// </summary>
        Uploadwithdraw,

        /// <summary>
        /// 中间件 定时请求 提现的结果
        /// </summary>
        GetWithdrawdata,

        /// <summary>
        /// 得到用户充值
        /// </summary>
        GetUserRechange,

            /// <summary>
            /// 得到用户充值
            /// </summary>
        GetUserRechangeByHash,
        /// <summary>
        /// 再次 获 提币记录
        /// </summary>
        GetWithdrawdataAgain,
        /// <summary>
        /// 中间件 定时请求 提现的结果
        /// </summary>
        GetWithdrawdatav2,
        /// <summary>
        /// 再次 获 提币记录
        /// </summary>
        GetWithdrawdataAgainv2,

        WriteSMC,

        /// <summary>
        /// 获取热钱包列表
        /// </summary>
        HotWallet_List
    }
}
