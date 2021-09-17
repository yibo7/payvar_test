//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Dapper;

//namespace WalletMiddleware.Dal
//{
//    public class JobReports : DbBaseRiskCheck<TableModels.JobReports>
//    {
//        public static readonly JobReports Instane = new JobReports();

//        public void AddReport(string info,string jobkey)
//        {
//            TableModels.JobReports model = new TableModels.JobReports();
//            model.AddTime = DateTime.Now;
//            model.JobKey = jobkey;
//            model.Report = info;
//            this.Add(model);
//        }
//    }
//}
