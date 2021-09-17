using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography; 
namespace WalletMiddleware
{
    public partial class ApiKeySetting : Form
    {
        public ApiKeySetting()
        {
            InitializeComponent();
        }

        private void btnJIeMi_Click(object sender, EventArgs e)
        {
            string iTbGongYao = tbGongYaoMi.Text.Trim();
            string iTbPwd = tbPwd.Text.Trim();

            if (!string.IsNullOrEmpty(iTbGongYao) && !string.IsNullOrEmpty(iTbPwd))
            {

                string mMing = AesJieMi(iTbGongYao, iTbPwd);
                if (!string.IsNullOrEmpty(mMing))
                {
                    string[] strArray = mMing.Split(new string[] { "***" }, StringSplitOptions.RemoveEmptyEntries);

                    this.tbGongYao.Text = strArray[0];
                    this.tbSiYao.Text = strArray[1];

                }



            }
            else
            {

                MessageBox.Show("密文或交易密码不能为空");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string iTbGongYao = tbGongYao.Text.Trim();
            string iTbSiYao = tbSiYao.Text.Trim();
            if (!string.IsNullOrEmpty(iTbGongYao) && !string.IsNullOrEmpty(iTbSiYao))
            {
                Settings.Instance.WcfUserId = iTbGongYao;
                Settings.Instance.PrivateKey = iTbSiYao;
                Settings.Instance.Save();
                //BindCoinTypeCombobox();
                MessageBox.Show("保存成功");
            }
            else
            {

                MessageBox.Show("参数为空值");
            }
        }

        #region 解密
        public static string AesJieMi(string decryptStr, string pwd)
        {

            ////私钥
            //string _aesKey = Settings.Instance.WcfUserId.Replace("-", "");
            ////公钥 
            //string _aesIV = Settings.Instance.WcfUserId.Replace("-", "").Substring(0, 16);

            //私钥
            string _aesKey = "89cee2996a117148f2e94cc0386ac0c9"; //Settings.Instance.WcfUserId.Replace("-", "");
            //公钥 
            //string _aesIV = "ea3f9260c4d24675";// Settings.Instance.WcfUserId.Replace("-", "").Substring(0, 16);
            string _aesIV = "ea3f9260c4" + pwd;
            return AesDecrypt(decryptStr, _aesKey, _aesIV);
        }


        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="decryptStr">要解密的串</param>
        /// <param name="aesKey">密钥</param>
        /// <param name="aesIV">IV</param>
        /// <returns></returns>
        private static string AesDecrypt(string decryptStr, string aesKey, string aesIV)
        {

            byte[] byteKEY = Encoding.UTF8.GetBytes(aesKey);
            byte[] byteIV = Encoding.UTF8.GetBytes(aesIV);

            byte[] byteDecrypt = System.Convert.FromBase64String(decryptStr);

            var _aes = new RijndaelManaged();
            _aes.Padding = PaddingMode.PKCS7;
            _aes.Mode = CipherMode.CBC;

            _aes.Key = byteKEY;
            _aes.IV = byteIV;

            var _crypto = _aes.CreateDecryptor(byteKEY, byteIV);
            byte[] decrypted = _crypto.TransformFinalBlock(
                byteDecrypt, 0, byteDecrypt.Length);

            _crypto.Dispose();

            return Encoding.UTF8.GetString(decrypted);
        }
        #endregion

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (tbSiYao.Text != "")
            {
                Clipboard.SetDataObject(tbSiYao.Text);
                MessageBox.Show("已复制到剪贴板！");
            }
        }
    }
}
