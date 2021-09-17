using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WalletMiddleware.Apis.Utils
{
    public class WebUtils
    {
        /// <summary>
        /// 获取当前毫秒数
        /// </summary>
        /// <returns></returns>
        public static string CurrMillseconds()
        {
            return ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000 + 1000).ToString();
        }

        /// <summary>
        /// Post提交数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public static string PostUrl(string url, string postData, string type = "x-www-form-urlencoded")
        {
            string result = "";

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

            req.Method = "POST";

            //req.Timeout = 800;//设置请求超时时间，单位为毫秒

            req.ContentType = "application/" + type;

            byte[] data = Encoding.UTF8.GetBytes(postData);

            req.ContentLength = data.Length;

            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);

                reqStream.Close();
            }

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            Stream stream = resp.GetResponseStream();

            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }


        public static string LoadURLString(string url, Encoding ed, string GetPost)
        {
            HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(url);
            request1.Method = GetPost;
            request1.ContentType = "application/json";
            request1.Accept = "application/json";
            return new StreamReader(((HttpWebResponse)request1.GetResponse()).GetResponseStream(), ed).ReadToEnd();
        }
    }
}
