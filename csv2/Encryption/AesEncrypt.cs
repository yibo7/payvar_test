using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace WalletMiddleware
{

    /// <summary>
    /// 本类提供AES加解密方法
    /// </summary>
    public class AesEncrypt
    {

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="data">待加密数据</param>
        /// <param name="secret">加密秘钥</param>
        /// <returns>加密后数据</returns>
        public static string Encrypt(string data, string secret)
        {
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(secret);
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(data);

            SHA256 sha256 = new SHA256Managed();
            keyArray = sha256.ComputeHash(keyArray);
            sha256.Clear();

            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = rDel.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="data">待解密数据</param>
        /// <param name="secret">解密秘钥</param>
        /// <returns>解密后数据</returns>
        public static string Decrypt(string data, string secret)
        {
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(secret);
            byte[] toEncryptArray = Convert.FromBase64String(data);

            SHA256 sha256 = new SHA256Managed();
            keyArray = sha256.ComputeHash(keyArray);
            sha256.Clear();

            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = rDel.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return UTF8Encoding.UTF8.GetString(resultArray);
        }
    }
}