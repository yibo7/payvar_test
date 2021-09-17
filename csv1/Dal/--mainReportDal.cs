//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Dapper;
//using WalletMiddleware.TableModels;

//namespace WalletMiddleware.Dal
//{
//    public class mainReportDal
//    {
//        public static readonly mainReportDal Inst = new mainReportDal();
//        private IDbConnection GetConn=> DbUtils.GetConnForEbChange();

//        public string GetLastDayReport()
//        {
//            string lastDay = DateTime.Now.AddDays(-1).ToShortDateString();
//            string sWhere = string.Format("date_format('{0}','%Y-%m-%d')", lastDay);
//            StringBuilder sbReport = new StringBuilder();
//            using (var connection = GetConn)
//            {

//                int iCount = connection.QuerySingleOrDefault<int>("select count(*) as countnum   from fuser ;");

//                sbReport.Append("<h3>【注册用户】:</h3>");
//                sbReport.AppendFormat("总用户数:<font color=\"#ff0000\">{0}</font><br>", iCount);
//                sbReport.Append("昨天新增:");
//                List<ReportTem> rpData = connection.Query<ReportTem>(string.Format("select fcountrys.countryname as Title ,count(fuser.fId) as CountNum  from fuser,fcountrys where fuser.countryid = fcountrys.fid AND date_format(fRegisterTime,'%Y-%m-%d')={0}  GROUP BY countryid;", sWhere)).ToList();

//                foreach (var model in rpData)
//                {
//                    sbReport.AppendFormat("{0}(<font color=\"#ff0000\">{1}</font>) ", model.Title, model.CountNum);
//                }

//                rpData = connection.Query<ReportTem>(string.Format("select fregIp as Title,count(*) as CountNum   from fuser where fRegisterTime between '{0}' and '{1}'  GROUP BY fregIp  ORDER BY CountNum DESC LIMIT 10;", DateTime.Now.AddDays(-7).ToShortDateString(), DateTime.Now.ToShortDateString())).ToList();
//                sbReport.Append("<br>最近7天同IP注册前10名:<br>");
//                foreach (var model in rpData)
//                {
//                    sbReport.AppendFormat("{0}(<font color=\"#ff0000\">{1}</font>)<br>", model.Title, model.CountNum);
//                }


//                rpData = connection.Query<ReportTem>(string.Format("select FV.fShortName as Title,SUM(FE.fleftfees) as CountNum  from fentrust FE ,ftrademapping FT,fvirtualcointype FV where FE.fEntrustType=1 AND FT.fid=FE.ftrademapping AND FV.fId=FT.fvirtualcointype1  AND date_format(FE.fCreateTime,'%Y-%m-%d')= {0} GROUP BY FV.fShortName;", sWhere)).ToList();
//                sbReport.Append("<br><h3>【卖单手续费】:</h3>");
//                foreach (var model in rpData)
//                {
//                    sbReport.AppendFormat("{0}(<font color=\"#ff0000\">{1}</font>)  ", model.Title, model.CountNum);
//                }
//                rpData = connection.Query<ReportTem>(string.Format("select FV.fShortName as  Title,SUM(FE.fleftfees) as CountNum  from fentrust FE ,ftrademapping FT,fvirtualcointype FV where FE.fEntrustType=0 AND FT.fid=FE.ftrademapping AND FV.fId=FT.fvirtualcointype2  AND date_format(FE.fCreateTime,'%Y-%m-%d')= {0} GROUP BY FV.fShortName;", sWhere)).ToList();
//                sbReport.Append("<br><h3>【买单手续费】:</h3>");
//                foreach (var model in rpData)
//                {
//                    sbReport.AppendFormat("{0}(<font color=\"#ff0000\">{1}</font>)  ", model.Title, model.CountNum);
//                }
//            }

//            return sbReport.ToString();

//        }

//        public List<MainReport> GetMainReport(string startDate,string endDate)
//        {
//            List<MainReport> lstData = new List<MainReport>();
//            using (var connection = GetConn)
//            {

//                #region 订单处理


//                List<ReportTem> rpNewBuys = connection.Query<ReportTem>(string.Format("select DATE_FORMAT(fCreateTime, \"%Y-%m-%d\" ) as Title,count(*) as CountNum from fentrust where fEntrustType=0  AND fCreateTime between '{0}' and '{1}'  GROUP BY DATE_FORMAT(fCreateTime, \"%Y-%m-%d\") ORDER BY Title DESC;", startDate, endDate)).ToList();

//                foreach (var mdReposrt in rpNewBuys)
//                {
//                    MainReport mdMainReport = new MainReport();
//                    mdMainReport.DateName = mdReposrt.Title;
//                    mdMainReport.NewBuys = mdReposrt.CountNum;
//                    lstData.Add(mdMainReport);
//                }
//                List<ReportTem> rpNewSells = connection.Query<ReportTem>(string.Format("select DATE_FORMAT(fCreateTime, \"%Y-%m-%d\" ) as Title,count(*) as CountNum  from fentrust where fEntrustType=1 AND fCreateTime between '{0}' and '{1}'  GROUP BY DATE_FORMAT(fCreateTime, \"%Y-%m-%d\") ORDER BY Title DESC;", startDate, endDate)).ToList();

//                foreach (var mdReposrt in rpNewSells)
//                {
//                    MainReport mdMainReport = getMainReport(ref lstData, mdReposrt.Title);
//                    mdMainReport.NewSells = mdReposrt.CountNum;
//                }

//                //foreach (var mdData in lstData)
//                //{
//                //    List<ReportTem> lstFeesBuy = connection.Query<ReportTem>(string.Format("select FV.fShortName as  Title,SUM(FE.fleftfees) as CountNum  from fentrust FE ,ftrademapping FT,fvirtualcointype FV where FE.fEntrustType=0 AND FT.fid=FE.ftrademapping AND FV.fId=FT.fvirtualcointype2  AND date_format(FE.fCreateTime,'%Y-%m-%d')= '{0}' GROUP BY FV.fShortName;", mdData.DateName)).ToList();
//                //    StringBuilder sbFees = new StringBuilder();
//                //    sbFees.Append("【买单】:");
//                //    foreach (var mdReposrt in lstFeesBuy)
//                //    {
//                //        sbFees.AppendFormat("{0}({1})", mdReposrt.Title, mdReposrt.CountNum);
//                //    }

//                //    sbFees.Append("【卖单】:");

//                //    List<ReportTem> lstFeesSell = connection.Query<ReportTem>(string.Format("select FV.fShortName as Title,SUM(FE.fleftfees) as CountNum  from fentrust FE ,ftrademapping FT,fvirtualcointype FV where FE.fEntrustType=1 AND FT.fid=FE.ftrademapping AND FV.fId=FT.fvirtualcointype1  AND date_format(FE.fCreateTime,'%Y-%m-%d')= '{0}' GROUP BY FV.fShortName;", mdData.DateName)).ToList();
//                //    foreach (var mdReposrt in lstFeesSell)
//                //    {
//                //        sbFees.AppendFormat("{0}({1})", mdReposrt.Title, mdReposrt.CountNum);
//                //    }
//                //    mdData.Fees = sbFees.ToString();
//                //}

//                #endregion

//                #region 用户处理

//                List<ReportTem> rpRegCount = connection.Query<ReportTem>(string.Format("select DATE_FORMAT(fRegisterTime, '%Y-%m-%d' ) as Title,count(*) as CountNum   from fuser where fRegisterTime between '{0}' and '{1}'  GROUP BY DATE_FORMAT(fRegisterTime, '%Y-%m-%d');", startDate, endDate)).ToList();

//                foreach (var mdReposrt in rpRegCount)
//                {
//                    MainReport mdMainReport = getMainReport(ref lstData, mdReposrt.Title);
//                    mdMainReport.RegCount = mdReposrt.CountNum;
//                }

//                List<ReportTem> LoginCount = connection.Query<ReportTem>(string.Format("select DATE_FORMAT(fLastLoginTime, '%Y-%m-%d' ) as Title,count(*) as CountNum   from fuser where fLastLoginTime between '{0}' and '{1}'  GROUP BY DATE_FORMAT(fLastLoginTime, '%Y-%m-%d');", startDate, endDate)).ToList();

//                foreach (var mdReposrt in LoginCount)
//                {
//                    MainReport mdMainReport = getMainReport(ref lstData, mdReposrt.Title);
//                    mdMainReport.LoginCount = mdReposrt.CountNum;
//                }

//                #endregion

//            }

//            return lstData;
//        }

//        private MainReport getMainReport(ref  List<MainReport> lstData,string DateName)
//        {
//            foreach (var model in lstData)
//            {
//                if (model.DateName.Equals(DateName))
//                    return model;
//            }
//            MainReport newModel = new MainReport();
//            newModel.DateName = DateName;
//            lstData.Add(newModel);
//            return newModel;
//        }
//    }
//}
