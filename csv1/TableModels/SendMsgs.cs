using System;
using WalletContracts.Comm;
using XS.DataProfile.Dapper.Contrib;

namespace WalletMiddleware.TableModels
{
    [Table("sendmsgs")]
    public class SendMsgs
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } 
        public int MsgType { get; set; }
        public string ToTarget { get; set; }
        public int IsSend { get; set; }  
        public string Msg { get; set; } 
        public DateTime AddTime { get; set; }
        public DateTime SendTime { get; set; }
        public int Version { get; set; }

        public string GetMdwu()
        {
            
            return HashHelper.GetHashStr(string.Format("{0}-{1}-{2}-{3}", Title, MsgType, ToTarget, Msg));
        }

    }
}