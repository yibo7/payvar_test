using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WalletMiddleware.Apis.Enums;
using WalletMiddleware.Apis.Models;
using WalletMiddleware.Apis.Utils;

using WalletMiddleware.TableModels;

namespace WalletMiddleware.Apis
{
    /// <summary>
    /// COINBIG Api 基础信息配置类
    /// </summary>
    public partial class Api
    {
        public static Api Instance = new Api();

        /// <summary>
        /// 请求站点主地址
        /// </summary>
        private string Domain = Settings.Instance.JavaApiDomain + "/api/publics/walletv1/";
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
        //protected readonly string SECRET = "20d5c5f5-e977-442c-a77c-s123as5x1a5";
        protected readonly string SECRET = "e28c85dd-6279-4e88-81fc-ab6dc8ce9a4a";

        
        /// <summary>
        /// IP地址
        /// </summary>
        internal string IP = string.Empty;// Settings.Instance.IP;//
        /// <summary>
        /// 获取IP地址
        /// </summary>
        /// <returns></returns>
        private string GetIpAddress()
        {
            if (string.IsNullOrEmpty(IP))
            {
                IP = GetIp();
            }
            return IP;
        }

        internal string GetIp()
        {
            try
            {
                dynamic ipstr = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(XS.Core.WebUtils.LoadURLStringUTF8($"{Settings.Instance.JavaApiDomain}/api/publics/vip/getClientIpAndServerTime"));
                                                                                                                                                           

                return ipstr.data.ip;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        private (T,string) GetApiData<T>(UrlEnum urlEnum) where T : class
        {
            try
            {
                string url = this.Domain + this.GetUrl(urlEnum);
                XS.Core.Log.InfoLog.Info($"正在向{url}发送请求");
                var res = WebUtils.PostUrl(url, GetSign());
                var result = JsonUtils.Deserialize<ApiResponce<dynamic>>(res);
                XS.Core.Log.InfoLog.Info($"正在向{url}结果:{result.Code}");
                bool isCheck = false;
                if (result.Code == 0)
                {
                    XS.Core.Log.InfoLog.Info($"正在向{url}结果Msg:{result.Msg}");
                    //XS.Core.Log.InfoLog.Info($"正在向{url}结果Data:{result.Data}");
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
                return (default(T),ex.Message);
            }            
        }

        private (bool,string) SubmitData(UrlEnum urlEnum,string data)
        {            
            try
            {                
                string url = this.Domain + this.GetUrl(urlEnum);
                XS.Core.Log.InfoLog.Info($"正在向{url}发送请求:{data}");
                var res = WebUtils.PostUrl(url, PostSign(data));
                var result = JsonUtils.Deserialize<ApiResponce<dynamic>>(res);
                XS.Core.Log.InfoLog.Info($"正在向{url}结果:{result.Code}");
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

        private (bool, string) PostData(UrlEnum urlEnum, string data, out int code)
        {
            try
            {
                string url = this.Domain + this.GetUrl(urlEnum);
                var res = WebUtils.PostUrl(url, PostSign(data));
                var result = JsonUtils.Deserialize<ApiResponce<dynamic>>(res);
                code = result.Code;
                if (result.Code == 0)
                {
                    return (true, "");
                }
                return (false, result.Data);
                //return (false, result.Msg);
            }
            catch (System.Exception ex)
            {
                code = -101;
                return (false, ex.Message);
            }
        }

        private string GetUrl(UrlEnum urlEnum)
        {
            string url = string.Empty;
            switch (urlEnum)
            {
                case UrlEnum.HotWallet_Update:
                    url = "wallethot/wallethotupdate";
                    break;
                case UrlEnum.HotWallet_List:
                    url = "wallethot/getwallethotlist";
                    break;
                case UrlEnum.Recharge_Add:
                    url = "recharge/rechargeadd";
                    break;
                case UrlEnum.Recharge_Confirm:
                    url = "recharge/confirmupdate";
                    break;
                case UrlEnum.Wallet_Core:
                    url = "walletaddrecore/getwalletaddrecorelist";
                    break;
                case UrlEnum.CoolAddress_Pool:
                    url = "walletaddress/getaddaddresscoinlist";
                    break;
                case UrlEnum.ColdAddress_Add:
                    url = "walletaddress/addressadd";
                    break;
                case UrlEnum.Withdraw_Back:
                    url = "withdrawal/fvirtualcaptualoperationupdate";
                    break;
                case UrlEnum.Withdraw_List:
                    url = "withdrawal/getfvirtualcaptualoperationlist";
                    break;
                case UrlEnum.VirtualCoinType:
                    url = "walletaddrecore/getwalletcointypelist";
                    break;
                case UrlEnum.IsAuthorized:
                    url = "walletpublicapi/getpermission";
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
        private string GetSign()
        {
            StringBuilder signSbr = new StringBuilder();
            var clientIp = $"clientIp={this.GetIpAddress()}&";
            signSbr.Append(clientIp).AppendFormat("time={0}&", WebUtils.CurrMillseconds());
            signSbr.AppendFormat("sign={0}", Md5Utils.Md5($"{signSbr}secret_key={SECRET}").ToUpper());

            return signSbr.Replace(clientIp, "").ToString();
        }
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
            var clientIp = $"clientIp={this.GetIpAddress()}&";
            signSbr.Append(clientIp)
                .AppendFormat($"data={aescode}&")
                .AppendFormat($"msg={md5Data}&")
                .AppendFormat("time={0}&", WebUtils.CurrMillseconds());
            signSbr.AppendFormat("sign={0}", Md5Utils.Md5($"{signSbr}secret_key={SECRET}").ToUpper());

            return signSbr.Replace(clientIp, "").Replace(aescode, aes).ToString();
        }
        #endregion

        /// <summary>
        /// 获得访问权限
        /// 因ip发生变化，不能访问API。
        /// </summary>
        /// <returns></returns>
        public bool IsAuthorized()
        {
            try
            {
                var result = WebUtils.LoadURLString($"{this.Domain}{GetUrl(UrlEnum.IsAuthorized)}", Encoding.UTF8, "GET");
                var dy = JsonUtils.Deserialize<ApiResponce<object>>(result);
                return dy.Code == 0;
            }
            catch (Exception ex)
            {
                XS.Core.Log.InfoLog.Error("获取授权异常:"+ex.Message);
                return false;
            }
           
        }
    }
}
