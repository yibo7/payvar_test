using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace WalletMiddleware
{
    /// <summary>
    /// HMACSHA256
    /// </summary>
    public class Hmacsha256
    {
        /// <summary>
        /// HMACSHA256签名
        /// </summary>
        /// <param name="data">需要签名的数据</param>
        /// <param name="secret">签名用的秘钥</param>
        /// <returns>签名字符串</returns>
        public static string Sign(string data, string secret)
        {
            secret = secret ?? "";
            var encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(secret);
            byte[] messageBytes = encoding.GetBytes(data);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                return Convert.ToBase64String(hashmessage);
            }
        }
    }
}