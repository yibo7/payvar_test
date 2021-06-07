using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletMiddleware.Apis.Enums;
using WalletMiddleware.Apis.Models;
using WalletMiddleware.Apis.Utils;

namespace WalletMiddleware.Apis
{
    /// <summary>
    /// COINBIG 充值及修改确认数相关接口实现
    /// </summary>
    public partial class Api
    {
        /// <summary>
        /// 添加充值记录
        /// </summary>
        /// <param name="recharges"></param>
        /// <returns></returns>
        public (bool,string) AddRecharge(string data,out int code)
        {
            return PostData(UrlEnum.Recharge_Add, data,out code);
        }

        public (bool, string) UpdateConfirm(string data)
        {
            return SubmitData(UrlEnum.Recharge_Confirm, data);
        }
    }
}
