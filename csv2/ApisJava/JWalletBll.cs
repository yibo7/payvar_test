using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletContracts.Entity;
using WalletMiddleware.Apis.Utils;
using WalletMiddleware.ApisJava.vo;

namespace WalletMiddleware.ApisJava
{
    public class JWalletBll
    {
        public static readonly JWalletBll Instane = new JWalletBll();

        public JWalletBll()
        {

        }

        /// <summary>
        ///  采集冷地址
        /// </summary>
        /// <param name="coinType">币种名称</param>
        /// <param name="count">采集数量 10000</param>
        /// <returns></returns>
        public List<ReciveCoolAddrVo> GetCoinCoolAddrs(string coinTypeName, int count,out string temp)
        {
            //改用通过api方式，请求交易所热钱包数据。
            JApi iApi = new JApi();
            string userId = Settings.Instance.WcfUserId;
            //使用有延值功能 Md5
            string mdWu = Md5Utils.ToMd5AndExtend($"{userId}{coinTypeName}{count}secret_key={Settings.Instance.PrivateKey}");

            //var signature = HashHelper.GetHashStr($"coinType={coinType}&count={count}&userid={sUserId}");
            //var result = WcfInst.Instance.CreateColdAddress(sUserId, coinType, count, signature);


            var objModel = new
            {
                userId,
                coinTypeName,
                count,
                mdWu
            };

            var jsonData = JsonUtils.Serialize(objModel);
            temp = "====API 采集冷地址 ====";
            temp += "\t\r ";
            temp += "地址: mcool/getaddrs";
            temp += "\t\r ";
            temp += "参数: userId="+ userId;
            temp += "\t\r ";
            temp += "coinTypeName=" + coinTypeName ;
            temp += "\t\r ";
            temp += "count=" + count ;
            temp += "\t\r ";
            temp += "mdWu=" + mdWu;
            temp += "\t\r ";
            var (result, err) = iApi.PostData<List<ReciveCoolAddrVo>>(JUrlEnum.GatherAddrs, jsonData);
            temp += "==== 结果 ====";

            temp += "\t\r ";
            temp += "result=" + JsonUtils.Serialize(result);
            temp += "\t\r ";
            return result == null ? new List<ReciveCoolAddrVo>() : result;


        }


        /// <summary>
        /// 得到 热钱包的数据
        /// </summary>
        /// <returns></returns>
        public List<ReciveHotWalletVo> GetHotWallets()
        {
            //改用通过api方式，请求交易所热钱包数据。
            JApi iApi = new JApi();
            string userId = Settings.Instance.WcfUserId;
            //使用有延值功能 Md5  (用户ID+用户私钥 +延值) md5 1次
            string mdWu = Md5Utils.ToMd5AndExtend($"{userId}secret_key={Settings.Instance.PrivateKey}");


            var objModel = new
            {
                userId,
                mdWu
            };

            var jsonData = JsonUtils.Serialize(objModel);

            var (result, err) = iApi.PostData<List<ReciveHotWalletVo>>(JUrlEnum.GetHotWallets, jsonData);
            return result == null ? new List<ReciveHotWalletVo>() : result;

        }


        /// <summary>
        /// 上传 用户提现数据
        /// </summary>
        /// <param name="coinTypeId">币种DI</param>
        /// <param name="toAddress">收币地址</param>
        /// <param name="amountDecimal">金额</param>
        /// <param name="orderId">交易所ID</param>
        /// <returns>true 成功，false 失败 </returns>
        public bool UploadWithdraw(string coinType, string toAddress, decimal amountDecimal, string orderId, out string  temp)
        {
            //改用通过api方式，请求交易所热钱包数据。
            JApi iApi = new JApi();
            string userGid = Settings.Instance.WcfUserId;
            //使用有延值功能 Md5  (用户GID+币种名称+收币地址+金额【8位小数】+orderId+ 用户私钥 +延值) md5 1次
            //string mdwu = Md5Utils.ToMd5AndExtend($"{userGid}{coinType}{toAddress}{ amountDecimal.ToString("0.########")}{orderId}{Settings.Instance.PrivateKey}");


            //string mdwu = Md5Utils.ToMd5AndExtend($"{userGid}{coinType}{toAddress}{DecimalHelper. CutDecimalWithN( amountDecimal,8)}{orderId}{Settings.Instance.PrivateKey}");
            string mdwu = Md5Utils.ToMd5AndExtend($"{userGid}{coinType}{toAddress}{DecimalHelper.CutDecimalWithN(amountDecimal, 8). ToString("0.########")}{orderId}{Settings.Instance.PrivateKey}");

            var objModel = new
            {
                coinType,
                toAddress,
                amountDecimal,
                userGid,
                orderId,
                mdwu

            };
            temp = "====API 提现申请 ====";
            temp += "\t\r ";
            temp += "地址: mwithdrawlist/uploadwithdraw";
            temp += "\t\r ";
            temp += "参数: coinType=" + coinType;
            temp += "\t\r ";
            temp += "toAddress=" + toAddress;
            temp += "\t\r ";
            temp += "amountDecimal=" + amountDecimal;
            temp += "\t\r ";
            temp += "userGid=" + userGid;
            temp += "\t\r ";
            temp += "orderId=" + orderId;
            temp += "\t\r ";
            temp += "mdWu=" + mdwu;
            temp += "\t\r ";

            var jsonData = JsonUtils.Serialize(objModel);

            var (result, err) = iApi.PostData<string>(JUrlEnum.Uploadwithdraw, jsonData);

           
            if (long.Parse(result) > 0)
            {
                return true;
            }
            return false;

        }
        /// <summary>
        /// 中间件 定时请求 提现的结果
        /// </summary>
      
        /// <param name="toAddress"></param>
        /// <param name="amountDecimal"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public ReciveWithdrawVo GetWithdrawdata( string toAddress, decimal amountDecimal, int orderId)
        {
            //改用通过api方式，请求交易所热钱包数据。
            JApi iApi = new JApi();
            string userGid = Settings.Instance.WcfUserId;
            //使用有延值功能 Md5  (用户GID+币种名称+收币地址+金额【8位小数】+orderId+ 用户私钥 +延值) md5 1次
            string mdwu = Md5Utils.ToMd5AndExtend($"{userGid}{toAddress}{ amountDecimal.ToString("0.########")}{orderId}{Settings.Instance.PrivateKey}");

            var objModel = new
            {               
                toAddress,
                amountDecimal,
                userGid,
                orderId,
                mdwu

            };


            var jsonData = JsonUtils.Serialize(objModel);

            var (result, err) = iApi.PostData<ReciveWithdrawVo>(JUrlEnum.GetWithdrawdata, jsonData);

            return result == null ? new ReciveWithdrawVo() : result;
        }


        /// <summary>
        /// 从Java API 中得到用户的充值记录
        /// </summary>
        /// <returns></returns>
        public List<ReciveRechangeVo> GetUserRechangeData()
        {

            //改用通过api方式，请求交易所热钱包数据。
            JApi iApi = new JApi();
            string userGid = Settings.Instance.WcfUserId;
            //用户GID+用户私钥 +延值
            string mdwu = Md5Utils.ToMd5AndExtend($"{userGid}{Settings.Instance.PrivateKey}");

            var objModel = new
            {
                userGid,
                mdwu

            };
            var jsonData = JsonUtils.Serialize(objModel);
            var (result, err) = iApi.PostData<List<ReciveRechangeVo>>(JUrlEnum.GetUserRechange, jsonData);

            return result == null ? new List<ReciveRechangeVo>() : result;
        }


        /// <summary>
        /// 从Java API 中得到用户的充值记录
        /// </summary>
        /// <returns></returns>
        public ReciveRechangeVo GetUserRechangeDataByHash(string hash)
        {

            //改用通过api方式，请求交易所热钱包数据。
            JApi iApi = new JApi();
            string userGid = Settings.Instance.WcfUserId;
            //用户GID+用户私钥 +延值
            string mdwu = Md5Utils.ToMd5AndExtend($"{userGid}{hash}{Settings.Instance.PrivateKey}");

            var objModel = new
            {
                userGid,
                hash,
                mdwu

            };
            var jsonData = JsonUtils.Serialize(objModel);
            var (result, err) = iApi.PostData<ReciveRechangeVo>(JUrlEnum.GetUserRechangeByHash, jsonData);

            return result == null ? new ReciveRechangeVo() : result;
        }



        /// <summary>
        /// 【再次】中间件 定时请求  再次  提现的结果
        /// </summary>

        /// <param name="toAddress"></param>
        /// <param name="amountDecimal"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public ReciveWithdrawVo GetWithdrawdataAgain(string toAddress, decimal amountDecimal, int orderId)
        {
            //改用通过api方式，请求交易所热钱包数据。
            JApi iApi = new JApi();
            string userGid = Settings.Instance.WcfUserId;
            //使用有延值功能 Md5  (用户GID+币种名称+收币地址+金额【8位小数】+orderId+ 用户私钥 +延值) md5 1次
            string mdwu = Md5Utils.ToMd5AndExtend($"{userGid}{toAddress}{ amountDecimal.ToString("0.########")}{orderId}{Settings.Instance.PrivateKey}");

            var objModel = new
            {
                toAddress,
                amountDecimal,
                userGid,
                orderId,
                mdwu

            };


            var jsonData = JsonUtils.Serialize(objModel);

            var (result, err) = iApi.PostData<ReciveWithdrawVo>(JUrlEnum.GetWithdrawdataAgain, jsonData);

            return result == null ? new ReciveWithdrawVo() : result;
        }


        /// <summary>
        /// 中间件 定时请求 提现的结果
        /// </summary>

        /// <param name="toAddress"></param>
        /// <param name="amountDecimal"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public ReciveWithdrawNewVo GetWithdrawdatav2(string toAddress, decimal amountDecimal, int orderId)
        {
            //改用通过api方式，请求交易所热钱包数据。
            JApi iApi = new JApi();
            string userGid = Settings.Instance.WcfUserId;
            //使用有延值功能 Md5  (用户GID+币种名称+收币地址+金额【8位小数】+orderId+ 用户私钥 +延值) md5 1次
            string mdwu = Md5Utils.ToMd5AndExtend($"{userGid}{toAddress}{ amountDecimal.ToString("0.########")}{orderId}{Settings.Instance.PrivateKey}");

            var objModel = new
            {
                toAddress,
                amountDecimal,
                userGid,
                orderId,
                mdwu

            };


            var jsonData = JsonUtils.Serialize(objModel);

            var (result, err) = iApi.PostData<ReciveWithdrawNewVo>(JUrlEnum.GetWithdrawdatav2, jsonData);

            return result == null ? new ReciveWithdrawNewVo() : result;
        }

        public ReciveWithdrawNewVo GetWithdrawdataAgainv2(string toAddress, decimal amountDecimal, int orderId)
        {
            //改用通过api方式，请求交易所热钱包数据。
            JApi iApi = new JApi();
            string userGid = Settings.Instance.WcfUserId;
            //使用有延值功能 Md5  (用户GID+币种名称+收币地址+金额【8位小数】+orderId+ 用户私钥 +延值) md5 1次
            string mdwu = Md5Utils.ToMd5AndExtend($"{userGid}{toAddress}{ amountDecimal.ToString("0.########")}{orderId}{Settings.Instance.PrivateKey}");

            var objModel = new
            {
                toAddress,
                amountDecimal,
                userGid,
                orderId,
                mdwu

            };


            var jsonData = JsonUtils.Serialize(objModel);

            var (result, err) = iApi.PostData<ReciveWithdrawNewVo>(JUrlEnum.GetWithdrawdataAgainv2, jsonData);

            return result == null ? new ReciveWithdrawNewVo() : result;
        }

        /// <summary>
        /// 得到用户下的 币种列表和币种下对应的热地址
        /// </summary>
        /// <returns></returns>
        public List<ReciveCoinsVo> GetHotWalletList()
        {
            //改用通过api方式，请求交易所热钱包数据。
            JApi iApi = new JApi();
            string userid = Settings.Instance.WcfUserId;
            //使用有延值功能 Md5
            string useridmdwu = Md5Utils.ToMd5AndExtend($"{userid}secret_key={Settings.Instance.PrivateKey}");

            var objModel = new
            {
                userid,
                useridmdwu
            };

            var jsonData = JsonUtils.Serialize(objModel);
          
            var (result, err) = iApi.PostData< List<ReciveCoinsVo> > (JUrlEnum.HotWallet_List, jsonData);
            return result == null ? new List<ReciveCoinsVo>() : result;

        }

        public string SendMsg(string toMsg)
        {
            //改用通过api方式，请求交易所热钱包数据。
            JApi iApi = new JApi();
           

            var jsonData = JsonUtils.Serialize(toMsg);

            var (result, err) = iApi.PostData<string>(JUrlEnum.WriteSMC, jsonData);

            return result ;
        }
    }
}
