using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletMiddleware.Apis.Enums
{
    public enum UrlEnum
    {
        /// <summary>
        /// 跟新冷热余额
        /// </summary>
        HotWallet_Update,
        /// <summary>
        /// 获取热钱包列表
        /// </summary>
        HotWallet_List,
        /// <summary>
        /// 添加充值记录
        /// </summary>
        Recharge_Add,
        /// <summary>
        /// 更新充值记录确认数
        /// </summary>
        Recharge_Confirm,
        /// <summary>
        /// 钱包内核数据
        /// </summary>
        Wallet_Core,
        /// <summary>
        /// 冷钱包需生成地址的币种列表
        /// </summary>
        CoolAddress_Pool,
        /// <summary>
        /// 添加冷地址
        /// </summary>
        ColdAddress_Add,
        /// <summary>
        /// 提现记录
        /// </summary>
        Withdraw_List,
        /// <summary>
        /// 提币数据回传
        /// </summary>
        Withdraw_Back,
        /// <summary>
        /// 虚拟币种列表
        /// </summary>
        VirtualCoinType,
        /// <summary>
        /// 当前机器是否授权
        /// </summary>
        IsAuthorized






    }
}
