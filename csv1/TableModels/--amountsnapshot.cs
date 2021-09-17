//using System;
//using WalletContracts.Comm;
//using XS.DataProfile.Dapper.Contrib;

//namespace WalletMiddleware.TableModels
//{

//    [Table("amountsnapshot")]
//    public class amountsnapshot
//    {
//        [Key]
//        public long Id { get; set; }
//        public string CoinType { get; set; }
//        public DateTime AddTime { get; set; }
//        public decimal HotAmount { get; set; }
//        public decimal ColdAmount { get; set; }
//        public decimal AmountSum { get; set; }

//        public string GetMdWu(string str)
//        {
//            return HashHelper.GetHashStr(str);
//        }
//    }
//}
