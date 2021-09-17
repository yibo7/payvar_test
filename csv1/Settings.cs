using System;
using XS.Core;

namespace WalletMiddleware
{
    public class Settings
    {
        public readonly static Settings Instance = new Settings();
        private IniParser iniParser;

        private Settings()
        {
             
            //D:\\web\\BeiMaiProject\\beimai5.0\\Web\\BeiMai.WebApp\\BeiMai.WebApp\\bin
            string sPath = AppDomain.CurrentDomain.BaseDirectory;
#if DEBUG
            if (sPath.EndsWith("\\bin"))
                sPath = sPath.Replace("\\bin", "");
#endif
            iniParser = new IniParser(string.Concat(sPath, @"\conf\conf.ini"));

            JavaApiDomain = iniParser.GetSetting("App", "JavaApiDomain");
            WcfUserId =  iniParser.GetSetting("App", "WcfUserId");      
         
            PrivateKey=iniParser.GetSetting("App", "PrivateKey");


           
        }

        public void Save()
        {
            ////app 
            iniParser.AddSetting("App", "WcfUserId", WcfUserId);
            iniParser.AddSetting("App", "PrivateKey", PrivateKey);
            iniParser.SaveSettings();
        }

   
        /// <summary>
        /// java版 api 的地址
        /// </summary>
        public string JavaApiDomain { get; set; }
 
        public string WcfUserId { get; set; }

        public string PrivateKey { get; set; }

   


    }
}