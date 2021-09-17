using System;
using System.Collections.Generic;
using WalletMiddleware.Apis.Enums;
using WalletMiddleware.Apis.Models;
using WalletMiddleware.TableModels;

namespace WalletMiddleware.Apis
{
    public partial class Api
    {
        public List<Withdraw> GetWithdrawList()
        {
            var (result, err) = GetApiData<List<Withdraw>>(UrlEnum.Withdraw_List);
            return result==null?new List<Withdraw>():result;
        }


        public (bool,string) WithdrawBack(string data)
        {
            return SubmitData(UrlEnum.Withdraw_Back, data);
        }
    }
}
