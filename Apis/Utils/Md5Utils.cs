using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletMiddleware.Apis.Utils
{
    public class Md5Utils
    {
        private const int times= 7;
        private const string mdwuKey = "bdeed5bc4f";

        public static string Md5(string str) {

            string md5Str = str;

            for (int i = 0; i < times; i++)
            {
                md5Str = ToMd5(md5Str).ToUpper();
            }

            return md5Str;
        }

        public static string Md5Obj(object obj)
        {

            string md5Str = ToMd5Obj(obj).ToUpper();

            for (int i = 0; i < times-1; i++)
            {
                md5Str = ToMd5(md5Str).ToUpper();
            }

            return md5Str;
        }

        public static string ToMd5(string str)
        {
            return XS.Core.Md5Helper.MD5(str);
        }

        public static string ToMd5Obj(object str)
        {
            return XS.Core.Md5Helper.MD5Obj(str);
        }


        public static bool MD5Equals(string md5,string str) {
            return md5.Equals(Md5(str));
        }

        /// <summary>
        /// MD5 有延值功能
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToMd5AndExtend(string str)
        {
            return XS.Core.Md5Helper.MD5(str + mdwuKey);
        }
    }
}
