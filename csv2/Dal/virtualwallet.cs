using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskCheck.Dal
{
    public class virtualwallet : DbBaseEbChange<TableModels.virtualwallet>
    {
        public static readonly virtualwallet Instane = new virtualwallet();
    }
}
