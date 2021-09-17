using System.Collections.Generic;
using System.Text;
using WalletMiddleware.Apis.Enums;
using WalletMiddleware.Apis.Models;
using WalletMiddleware.Apis.Utils;
using WalletMiddleware.TableModels;

namespace WalletMiddleware.Apis
{
    /// <summary>
    /// COINBIG 热钱包相关接口实现
    /// </summary>
    public partial class Api
    {        
        /// <summary>
        /// 从交易所获取状态为0的热钱包数据
        /// (未生成最新热钱包地址的币种数据)
        /// 并保存到本地数据库
        /// </summary>
        public List<HotWallet> GetData()
        {
            var (result,err)  = GetApiData<List<HotWallet>>(UrlEnum.HotWallet_List);
            return result==null?new List<HotWallet>():result;          
        }

        /// <summary>
        /// 更新冷热钱包余额
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public (bool,string) UpdateHotWallet(string data)
        {
            return SubmitData(UrlEnum.HotWallet_Update, data);                        
        }
    }
}
