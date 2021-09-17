using System.Collections.Generic;
using WalletMiddleware.Apis.Models;

namespace WalletMiddleware.Apis
{
    /// <summary>
    /// COINBIG 更新冷钱包地址相关接口实现
    /// </summary>
    public partial class Api
    {
        /// <summary>
        /// 获取钱包内核数据
        /// </summary>
        /// <returns></returns>
        public List<InsertAddrCoin> GetAddressCore()
        {
            var (result, err) = GetApiData<List<InsertAddrCoin>>(Enums.UrlEnum.CoolAddress_Pool);
            return result==null?new List<InsertAddrCoin>():result;
        }
        /// <summary>
        /// 添加地址
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public (bool, string) InsertAddress(string data)
        {
            return SubmitData(Enums.UrlEnum.ColdAddress_Add,data);
        }
    }
}
