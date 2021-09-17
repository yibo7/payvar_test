using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace WalletMiddleware.CheckData
{
    public class CheckCoinTxState
    {
        private DateTime LastDatetime { get; set; }

        private double WaitSeconds = 3;

        private double TxLimit = 23;

        private double ReTryCount = 3;

        private DateTime LastFaildDatetime { get; set; }

        private int VisitMinite = 5;

        private string CheckUrl = "https://chain.api.btc.com/v3/address/";

        //private string BtcHotAddress = "1Dp1TZfsMDfrNwuAzXi8mJwcXNA5xiHPor";

        static CheckCoinTxState _context;
        public static CheckCoinTxState Current
        {
            get => _context ?? (_context = new CheckCoinTxState());
            set => _context = value;
        }

        public bool CanSend(int coinTypeId,string toAddr)
        {
            switch (coinTypeId)
            {
                case 1: 
                case 15:
                    var btcHotAddr = "1Dp1TZfsMDfrNwuAzXi8mJwcXNA5xiHPor";
                    return JudgeTx(btcHotAddr);
                case 95:
                    return toAddr.ToUpper() != "Vcng4sYJTwQHzLjRBeKfabyUCzkC69hwcws".ToUpper();
                default:return true;
            }
        }

        private bool JudgeTx(string addr)
        {
            try
            {
                var currDateTime = DateTime.Now;
                TimeSpan ts0 = currDateTime.Subtract(LastFaildDatetime);
                var minite = ts0.TotalMinutes;
                if (minite < VisitMinite) return false;

                string result = "";
                for (int i = 0; i < ReTryCount; i++)
                {
                   
                    TimeSpan ts = currDateTime.Subtract(LastDatetime);
                    var second = ts.TotalSeconds;

                    if (second < WaitSeconds)
                    {
                        int secondInt = (int)second;
                        var sleepValue = ((int)WaitSeconds - secondInt) * 1000;
                        Thread.Sleep(sleepValue);
                    }
                    var url = CheckUrl + addr;
                    result = GetJsonStr(url);
                    LastDatetime = DateTime.Now;
                    if (!string.IsNullOrEmpty(result)) break;

                    Thread.Sleep(5000);
                }
                var dataInfo = JsonHelper.Deserialize<BtcDataInfo>(result);
                var canSend= dataInfo != null && dataInfo.err_no == 0 && dataInfo.data != null && dataInfo.data.unconfirmed_tx_count <= TxLimit;
                if (!canSend) LastFaildDatetime = DateTime.Now;
                return canSend;
            }
            catch
            {
                return false;
            }
        }

        private string GetJsonStr(string apiUrl)
        {
            string result = "";
            try
            {
                Encoding encoding = Encoding.UTF8;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);

                request.Method = "GET";
                request.Accept = "text/html, application/xhtml+xml, */*";
                request.ContentType = "application/json";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                using (StreamReader reader = new StreamReader(response.GetResponseStream() ?? throw new InvalidOperationException(), Encoding.UTF8))
                {
                    result = reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                var msg = e.Message;
                var st = e.StackTrace;
                XS.Core.Log.InfoLog.Error(e.Message + "\r\n" + e.StackTrace);
                //Dal.SendMsgsDal.Instane.SendEmails("btc取未确认交易时异常", e.Message+"\r\n"+e.StackTrace); 
            }
            return result;
        }
    }   
}
