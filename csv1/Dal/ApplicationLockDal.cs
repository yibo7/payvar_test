using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletMiddleware.TableModels;

namespace WalletMiddleware.Dal
{
    /// <summary>
    /// 锁
    /// </summary>
   public class ApplicationLockDal: DbBaseRiskCheck<TableModels.ApplicationLock>
    {
        public static readonly ApplicationLockDal Instane = new ApplicationLockDal();
        public ApplicationLockDal()
        {

        }
        /// <summary>
        /// 获得锁
        /// </summary>
        /// <param name="lockkey">job的标记</param>
        /// <param name="info">job的说明</param>
        /// <param name="timeoutvalue">过期秒</param>
        /// <returns></returns>
        public bool GetLock(string lockkey,string info, int timeoutvalue)
        {
            ApplicationLock modelLock = GetEntityByWhere("lockkey='" + lockkey + "'");
            if (modelLock == null)
            {
                ApplicationLock model = new ApplicationLock();
                model.lockkey = lockkey;
                model.info = info;
                model.timeoutvalue = timeoutvalue;
                long id = Add(model);
                if (id > 0)
                {
                    return true;
                }
            }
              
            return false;
        }
        /// <summary>
        /// 释放锁
        /// </summary>
        /// <param name="lockkey">job的标记</param>
        /// <returns></returns>
        public bool DelLock(string lockkey)
        {
            if(!string.IsNullOrEmpty(lockkey))
            {
                ApplicationLock model =   GetEntityByWhere("lockkey='"+lockkey+"'");
                if(model!=null)
                {
                    Delete(model.id);
                    return true;
                }
            }
            return false;
        }
    }
}
