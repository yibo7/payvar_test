using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletMiddleware.Apis.Models
{
    public class InsertAddrCoin
    {
        public int Id { get; set; }
        public string WalletName { get; set; }

        public DateTime? LastTipsTime { get; set; }
    }
}
