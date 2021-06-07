using System.Collections.Generic;
using System.Linq;
using WalletMiddleware.Apis;
using WalletMiddleware.Apis.Models;
using WalletMiddleware.TableModels;

namespace WalletMiddleware
{
    public class AppStaticData
    {
        //public static readonly string EncodeKey = "coinbig2017";
        /// <summary>
        /// 币种ID对应币种实例
        /// </summary>
        public static Dictionary<int, VirtualCoinType> CoinTypes = new Dictionary<int, VirtualCoinType>();
        ///// <summary>
        ///// 地址内核
        ///// </summary>
        ////public static Dictionary<int, walletaddrecore> CoinCores = new Dictionary<int, walletaddrecore>();
        //public static Dictionary<string, int> CoinCores = new Dictionary<string, int>();

       public static string walletaddrecoreMsg = "";
		/// <summary>
		/// 本地热钱包对象预加载
		/// </summary>
		public static Dictionary<int, HotWallet> HotWallets = new Dictionary<int, HotWallet>();
        

        public static void InitData()
        {
            ChangeData(null, null);
            if (!timer.Enabled)
            {
                //十分钟更新一次
                timer.Interval = 1 * 60 * 1000;
                timer.Elapsed += new System.Timers.ElapsedEventHandler(ChangeData);
                timer.Start();
            }

            



        }


        #region 定时处理
        /// <summary>
        /// 定时器
        /// </summary>
        private static System.Timers.Timer timer = new System.Timers.Timer();

        /// <summary>
        /// 定时处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ChangeData(object sender, System.Timers.ElapsedEventArgs e)
        {
            var hotwallet = Api.Instance.GetData();
            if (hotwallet.Any())
            {
                foreach (var item in hotwallet)
                {
                    if (HotWallets.ContainsKey(item.CoinId))
                    {
                        HotWallets[item.CoinId] = item;
                    }
                    else
                    {
                        HotWallets.Add(item.CoinId, item);
                    }
                }
            }            

            List<VirtualCoinType> lstvirtualcointype = Api.Instance.GetVirtualcointypes();
            if (lstvirtualcointype.Any())
            {
                foreach (VirtualCoinType vmd in lstvirtualcointype)
                {
                    if (CoinTypes.ContainsKey(vmd.fid))
                    {
                        CoinTypes[vmd.fid] = vmd;
                    }
                    else
                    {
                        CoinTypes.Add(vmd.fid, vmd);
                    }

                }
            }            

            Api.Instance.IP = Api.Instance.GetIp();
        }
        #endregion



    }
}
