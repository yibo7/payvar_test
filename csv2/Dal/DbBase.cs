﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using XS.DataProfile;
using XS.DataProfile.Dapper.Contrib;

namespace RiskCheck.Dal
{
   abstract public class DbBase<T> where T : class
    {
        protected readonly object lockHelper = new object();
        private string _TableName;
        private string TableName
        {
            get
            {
                if (string.IsNullOrEmpty(_TableName))
                {
                    lock (lockHelper)
                    {
                        Type t = typeof(T);
                        Attribute attribute = t.GetCustomAttribute(typeof(TableAttribute));
                        if (!Equals(attribute, null))
                        {
                            TableAttribute table = (TableAttribute)attribute;
                            _TableName = table.Name;
                        }
                    }
                    
                }
                
                return _TableName;
            }
        }

        abstract protected IDbConnection GetConn { get; }
        private IDbConnection _Db = null;
        private IDbConnection Db
        {
            get
            {
                if (Equals(_Db,null))
                {
                    lock (lockHelper)
                    {
                        _Db = GetConn;
                    }
                   
                }

                return _Db;
            }
        }

        /// <summary>
        /// 是否存在表名
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <returns></returns>
        public bool ExistsTable(string TableName)
        {
            using (var connection = Db)
            {
                string strSql = string.Format(" SHOW TABLES LIKE '{0}';", TableName); 

                List<string> list = new List<string>();
                using (IDataReader dataReader = connection.ExecuteReader(strSql))
                {
                    while (dataReader.Read())
                    {
                        list.Add(dataReader[0].ToString());
                    }
                }
                if (list.Count > 0)
                    return true;
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// 获取主键为Id的最大值
        /// </summary>
        /// <returns></returns>
        public long GetMaxID()
        {
            return GetMaxID("Id");
        }
        /// <summary>
        /// 获取数字主键的最大id
        /// </summary>
        /// <param name="keyname">主键名称</param>
        /// <returns></returns>
        public long GetMaxID(string keyname)
        {
            string strsql = string.Format("select max({0}) from {1}", keyname,TableName);
             
            using (var connection = Db)
            {
               return   connection.QuerySingleOrDefault<long>(strsql);
            }
        }
        /// <summary>
        /// 查看某个id的数据是否存在
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool Exists(long Id)
        {
            return Exists(string.Format("Id={0}", Id));
        }
        /// <summary>
        /// 查看某个条件下是否存在数据
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public bool Exists(string where)
        {
            string strSql = string.Format("select count(1) from {0} where {1}", TableName, where);
            using (var connection = Db)
            {
                int iCoint = connection.QuerySingleOrDefault<int>(strSql);
                return iCoint > 0;
            }

        }
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model">数据实例</param>
        /// <returns></returns>
        public long Add(T model)
        {
            return Add(model, null);
        }
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model">数据实例</param>
        /// <param name="Trans">事务</param>
        /// <returns></returns>
        public long Add(T model, DbTransaction Trans)
        {

            using (var connection = Db)
            {
               return connection.Insert(model, Trans);//只有Id为自动增长类型时返回一个整数Id
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">数据实例</param>
        /// <returns></returns>
        public bool Update(T model)
        {
           return Update(model, null);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">数据实例</param>
        /// <param name="Trans">事务</param>
        /// <returns></returns>
        public bool Update(T model, DbTransaction Trans)
        {
            using (var connection = Db)
            {
                return connection.Update(model, Trans);
            }
        }

        /// <summary>
        /// 根据Id获取记录
        /// </summary>
        /// <param name="Id">主键id的值</param>
        /// <returns></returns>
        public T GetEntity(int Id)
        {
            using (var connection = Db)
            {
                return connection.Get<T>(Id);
            }
        }
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="Id">主键Id的值</param>
        public void DeleteModel(int Id)
        {
            DeleteModel(Id, null);
        }
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="Id">主键Id的值</param>
        /// <param name="Trans">事务</param>
        public void DeleteModel(int Id, DbTransaction Trans)
        {
            using (var connection = Db)
            {
                string sql = string.Format("delete from {0} where Id={1} ", TableName, Id);
                 
                connection.ExecuteScalar(sql, Trans);
            }
        }
        /// <summary>
        /// 删除一个实例
        /// </summary>
        /// <param name="model">实例，只要有Id值就可以</param>
        public void DeleteModel(T model)
        {
            DeleteModel(model, null);
        }
        /// <summary>
        /// 删除一个实例
        /// </summary>
        /// <param name="model">实例，只要有id键就可以</param>
        /// <param name="Trans">事务</param>
        public void DeleteModel(T model, DbTransaction Trans)
        {
            using (var connection = Db)
            {
                connection.Delete(model, Trans);
            }
        }

        /// <summary>
        /// 清空记录 
        /// </summary>
        public void DeleteAll()
        {
            using (var connection = Db)
            {
                connection.DeleteAll<T>();
            }
        }

        /// <summary>
        /// 获取所有记录
        /// </summary>
        /// <returns></returns>
        public List<T> GetAll()
        {
            using (var connection = Db)
            {

                return connection.GetAll<T>().ToList();
            }
        }


        /// <summary>
        /// 获取某个条件下的记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0} ", TableName);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            int iCount = 0;
            using (var connection = Db)
            {
                iCount = connection.QuerySingleOrDefault<int>(strSql.ToString());
            }
            return iCount;
        }
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="PageIndex">当前页码</param>
        /// <param name="PageSize">每页显示多少条</param>
        /// <param name="strWhere">条件</param>
        /// <param name="Fileds">只查询的字段，如果为空即查询所有字段</param>
        /// <param name="oderby">排序</param>
        /// <param name="RecordCount">返回总记录数</param>
        /// <returns></returns>
        public List<T> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,
            out int RecordCount)
        {
            return GetListPages( PageIndex,  PageSize,  strWhere,  Fileds,  oderby,  out RecordCount, "Id");
        }
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="PageIndex">当前页码</param>
        /// <param name="PageSize">每页显示多少条</param>
        /// <param name="strWhere">条件</param>
        /// <param name="Fileds">只查询的字段，如果为空即查询所有字段</param>
        /// <param name="oderby">排序</param>
        /// <param name="RecordCount">返回总记录数</param>
        /// <param name="keyname">主键名称</param>
        /// <returns></returns>
        public List<T> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount,string keyname)
        {

            StringBuilder sbSql = new StringBuilder();
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sbSql.AppendFormat(strWhere);
            }
            RecordCount = GetCount(sbSql.ToString());

            //获取SqlServer2005及以上版的分页查询语句 
            //string strSql = SplitPages.GetListPagesSql2005("B_Part", PageSize, PageIndex, Fileds,  strWhere);

            //获取SqlServer2000或access分页查询语句 
            //string strSql = SplitPages.GetSplitPagesSql("B_Part", PageSize, PageIndex, Fileds, "PartInno", "", strWhere, "");

            //获取MySql或SQLite分页查询语句 ,MySql与SQLite的查询语句基本一样，所以GetSplitPagesMySql适用于MySql与SQLite
            string strSql = SplitPages.GetSplitPagesMySql(Db, TableName, PageSize, PageIndex, strWhere, keyname, Fileds, "", oderby);

            using (var connection = Db)
            {
                return connection.Query<T>(strSql).ToList();
            }
        }
        /// <summary>
        /// 查询某个条件下的第一个记录
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public T GetEntityByWhere(string where)
        {
            using (var connection = Db)
            {
                return connection.QueryFirst<T>(string.Format("select * from {0} where {1}",TableName, where));
            }
        }
        /// <summary>
        /// 查询某条件下的所有记录
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public List<T> GetList(string where)
        {
            using (var connection = Db)
            {
                return connection.Query<T>(string.Format("select * from {0} where {1}",TableName, where)).ToList();
            }
        }


        //public void Transactions()
        //{
        //    using (var connection = Db)
        //    {
        //        var id = connection.Insert(new BPart { Name = "one car" });
        //        var tran = connection.BeginTransaction();
        //        var car = connection.Get<BPart>(id, tran);
        //        var orgName = car.Name;
        //        car.Name = "Another car";
        //        connection.Update(car, tran);
        //        tran.Rollback();
        //        car = connection.Get<BPart>(id);
        //    }
        //}
    }
}
