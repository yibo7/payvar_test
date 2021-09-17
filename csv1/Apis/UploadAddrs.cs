using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace WalletMiddleware.Apis
{
  public  class UploadAddrs
    {

        public static byte[] ObjectToBytes(object obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                return ms.GetBuffer();
            }
        }
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="postData">要上传的数据</param>
        /// <param name="result">返回上传的结果，比如路径</param>
        /// <param name="oldfilename">老文件名称</param>
        /// <param name="issmallimg">是否生成缩略图</param>
        /// <param name="sfolder">要上传的目录名称</param>
        /// <param name="simg">要生成缩略图的格式</param>
        /// <returns></returns>
        public bool Post(byte[] postData)
        {


            //Dictionary<string, BsonValue> pram = new Dictionary<string, BsonValue>();

            //pram.Add("UserId", Host.Instance.UserID); 
            //result = "";
            //if (!Equals(postData, null) && postData.Length > 0)
            //{
            //    MongoGridFsOPT mgfs = new MongoGridFsOPT();
            //  result =  mgfs.Write(postData, oldfilename, pram,true);
            //}

            //return true;

            var request = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:8088/api/cool/uploadaddress/");
            //var request = (HttpWebRequest)WebRequest.Create("http://192.168.3.164:8082/file/fsapi");
            // var request = (HttpWebRequest)WebRequest.Create("http://192.168.3.104:8080/file/fsapi");

            request.Method = "POST";
            //string oldn = HttpContext.Current.Server.UrlEncode(oldfilename);
            //request.Headers.Add("bfs-oldfilename", oldn);
            //request.Headers.Add("bfs-issmallimg", issmallimg.ToString());
            //request.Headers.Add("bfs-sfolder", sfolder);
            //request.Headers.Add("bfs-simg", simg);
            //request.Headers.Add("bfs-key", Configs.SysConfigs.ConfigsControl.Instance.EncryptionKey);


            if (postData != null)
            {
                request.ContentLength = postData.Length;
                request.KeepAlive = true;

                Stream dataStream = request.GetRequestStream();
                dataStream.Write(postData, 0, postData.Length);
                dataStream.Close();
            }
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                var status = response.Headers["bfs-status"];
                //result = response.Headers["bfs-result"];
                return response.StatusCode == HttpStatusCode.OK && status == "100";
            }
            catch (Exception e)
            {
                //result = e.Message;
            }

            return false;

        }
    }
}
