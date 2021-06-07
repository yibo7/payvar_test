using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletMiddleware.CheckData
{
    public class BtcDataInfo
    {
        public int err_no { get; set; }
        public BtcChildDataInfo data { get; set; }
    }

    public class BtcChildDataInfo
    {
        public string address { get; set; }
        public long received { get; set; }
        public long sent { get; set; }
        public long balance { get; set; }
        public long tx_count { get; set; }
        public long unconfirmed_tx_count { get; set; }
        public long unconfirmed_received { get; set; }
        public long unconfirmed_sent { get; set; }
        public long unspent_tx_count { get; set; }
        public string first_tx { get; set; }
        public string last_tx { get; set; }
    }
}
