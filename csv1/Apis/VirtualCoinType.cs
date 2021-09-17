using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletMiddleware.Apis.Enums;
using WalletMiddleware.Apis.Models;
using WalletMiddleware.TableModels;

namespace WalletMiddleware.Apis
{
    public partial class Api
    {
        public List<VirtualCoinType> GetVirtualcointypes()
        {
            var (result, err) = GetApiData<List<VirtualCoinType>>(UrlEnum.VirtualCoinType);
            return result==null?new List<VirtualCoinType>():result;
        }
    }
}
