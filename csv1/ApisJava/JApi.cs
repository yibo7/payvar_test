using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletMiddleware.Apis.Models;
using WalletMiddleware.Apis.Utils;

namespace WalletMiddleware.ApisJava
{
    /// <summary>
    /// java api 开放服务
    /// </summary>
    public class JApi
    {
        public static JApi Instance = new JApi();

        /// <summary>
        /// 请求站点主地址
        /// </summary>
       private string Domain = Settings.Instance.JavaApiDomain + "/api/";

        //private string Domain = Settings.Instance.JavaApiDomain + "/api/publics/walletv1/";
        /// <summary>
        /// AES密钥
        /// </summary>
        private readonly string AESKEY = "f6ac9dc91e464630";
        /// <summary>
        /// AES私钥
        /// </summary>
        private readonly string AESIV = "82757b5722648926";
        /// <summary>
        /// 签名密钥
        /// </summary>       
        protected readonly string SECRET = "e28c85dd-6279-4e88-81fc-ab6dc8ce9a8a";


     

        public (T, string) PostData<T>(JUrlEnum urlEnum, string data) where T : class
        {
            try
            {
                string url = this.Domain + this.GetUrl(urlEnum);
                //var res = WebUtils.PostUrl(url, GetSign());
                var res = WebUtils.PostUrl(url, PostSign(data));
                var result = JsonUtils.Deserialize<ApiResponce<dynamic>>(res);
                bool isCheck = false;
                if (result.Code == 0)
                {
                    isCheck = Md5Utils.MD5Equals(result.Msg, result.Data.ToString());

                    if (isCheck)
                    {
                        return (JsonUtils.Deserialize<T>(AesUtils.DecodeAES(result.Data.ToString(), AESKEY, AESIV)), "");
                    }
                    else
                    {
                        return (default(T), "数据MD5校验未通过");
                    }
                }
                return (default(T), result.Msg);
            }
            catch (Exception ex)
            {
                return (default(T), ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="urlEnum"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public (bool, string) PostData(JUrlEnum urlEnum, string data)
        {
            try
            {
                string url = this.Domain + this.GetUrl(urlEnum);
                //XS.Core.Log.InfoLog.Info($"正在向{url}发送请求:{data}");
                var res = WebUtils.PostUrl(url, PostSign(data));

                var result = JsonUtils.Deserialize<ApiResponce<dynamic>>(res);
                if (result.Code == 0)
                {
                    return (true, "");
                }
                return (false, result.Msg);
            }
            catch (System.Exception ex)
            {
                return (false, ex.Message);
            }
        }

        private string GetUrl(JUrlEnum urlEnum)
        {
            string url = string.Empty;
            switch (urlEnum)
            {
                case JUrlEnum.GatherAddrs:
                    url = "mcool/getaddrs";
                    break;
                case JUrlEnum.GetHotWallets:
                    url = "mhotwallet/gethotdata";
                    break;
                case JUrlEnum.Uploadwithdraw:
                    url = "mwithdrawlist/uploadwithdraw";
                    break;
                case JUrlEnum.GetWithdrawdata:
                    url = "mwithdrawlist/getwithdrawdata";
                    break;
                case JUrlEnum.GetUserRechange:
                    url = "mrechangelist/getuserrechange";
                    break;
                case JUrlEnum.GetUserRechangeByHash:
                    url = "mrechangelist/getuserrechangebyhash";
                    break;
                case JUrlEnum.GetWithdrawdataAgain:
                    url = "mwithdrawlist/getwithdrawdataagain";
                    break;
                case JUrlEnum.GetWithdrawdatav2:
                    url = "mwithdrawlistnew/getwithdrawdata";
                    break;
                case JUrlEnum.GetWithdrawdataAgainv2:
                    url = "mwithdrawlistnew/getwithdrawdataagain";
                    break;
                case JUrlEnum.WriteSMC:
                    url = "messagesendap/sendbytype";
                    break;
                case JUrlEnum.HotWallet_List:
                    url = "data/getwallethotlist";
                    break;
                default:
                    break;
            }
            return url;

        }

        #region 签名
        /// <summary>
        /// 获取数据的签名方式
        /// </summary>
        /// <returns></returns>
        //private string GetSign()
        //{
        //    StringBuilder signSbr = new StringBuilder();
        //    //var clientIp = $"clientIp={this.GetIpAddress()}&";
        //    //signSbr.Append(clientIp).AppendFormat("time={0}&", WebUtils.CurrMillseconds());
        //    signSbr.AppendFormat("sign={0}", Md5Utils.Md5($"{signSbr}secret_key={SECRET}").ToUpper());

        //    return signSbr.ToString();
        //}
        /// <summary>
        /// 提交数据的签名方式
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string PostSign(string data)
        {
            var aescode = AesUtils.EncodeAES(data, AESKEY, AESIV);
            var aes = XS.Core.XsUtils.UrlEncode(aescode);
            var md5Data = Md5Utils.Md5(aescode);
            StringBuilder signSbr = new StringBuilder();
            // var clientIp = $"clientIp={this.GetIpAddress()}&";
            signSbr.AppendFormat($"data={aescode}&").AppendFormat($"msg={md5Data}&");
            signSbr.AppendFormat("sign={0}", Md5Utils.Md5($"{signSbr}secret_key={SECRET}").ToUpper());

            return signSbr.Replace(aescode, aes).ToString();
        }
        #endregion

       
    }
}
