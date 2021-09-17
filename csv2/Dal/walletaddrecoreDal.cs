using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletMiddleware.Dal
{
    public class walletaddrecoreDal: DbBaseRiskCheck<TableModels.walletaddrecore>
    {
        public static readonly walletaddrecoreDal Instance = new walletaddrecoreDal();
    }
}
