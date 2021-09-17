using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XS.DataProfile.Dapper.Contrib;

namespace RiskCheck.TableModels
{
    [Table("smpts")]
    public class Smpts
    {
        [Key]
        public long Id { get; set; }

       
        public String SmtpServer { get; set; }
      
        public String EmailFrom { get; set; }

        public String EmailPass { get; set; }

        public int EmailPort { get; set; }

        public bool IsSSL { get; set; }
    }
}
