using System;
using System.Collections.Generic;
using System.Text;
using WalletMiddleware.Apis.Models;
using WalletMiddleware.Apis.Utils;
using WalletMiddleware.TableModels;

namespace WalletMiddleware.Apis
{
    /// <summary>
    ///  COINBIG 钱包地址内核接口实现
    /// </summary>
    public partial class Api
    {
        /// <summary>
        /// 获取钱包内核数据
        /// </summary>
        /// <returns></returns>
        public Dictionary<string,int> AddressCore()
        {
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
            var (result, err) = GetApiData<List<walletaddrecore>>(Enums.UrlEnum.Wallet_Core);
            if (result!=null&&result.Count > 0)
            {
                foreach (var item in result)
                {
                    keyValuePairs.Add(item.WalletName, item.ConfirmNum);
                }
            }            
            return keyValuePairs;
        }
    }
}
