using MoneyBook.DataRelation;
using MoneyBook.Entities;
using MoneyBook.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyBook.DAL
{
    public class VInfoDAL : DALBase
    {
        static VInfoDAL obj = null;
        static object lockObj = new object();
        private VInfoDAL() { }
        public static VInfoDAL GetObj()
        {
            if (obj == null)
            {
                lock (lockObj)
                {
                    if (obj == null)
                    {
                        obj = new VInfoDAL();
                    }
                }
            }
            return obj;
        }
        public List<VInfoEntity> QueryMoney(DateTime bDate, DateTime eDate)
        {
            var sql = @"
SELECT
	* 
FROM
	V_INFO T 
WHERE
	T.DATE_COL >= DATE( '{0}' ) 
	AND T.DATE_COL < DATE(
	'{1}')";

            sql = string.Format(sql, bDate.ToString(AppSettings.DayFormat), eDate.ToString(AppSettings.DayFormat));

            return this.DataAccess.QueryData(sql, new VInfoRelation());
        }

        public List<VInfoEntity> QueryGroupByType(DateTime? bDate = null, DateTime? eDate = null)
        {
            var sql = @"
SELECT
	T.TYPE_NAME,
	SUM( T.USE_AMOUNT ) AS USE_AMOUNT,
	T.TYPE_ID 
FROM
	V_INFO T 
WHERE
	T.DATE_COL >= DATE( '{0}' ) 
	AND T.DATE_COL < DATE( '{1}' ) 
GROUP BY
	T.TYPE_NAME";
            sql = string.Format(sql, 
                (bDate ?? DateTime.MinValue).ToString(AppSettings.DayFormat),
                (eDate ?? DateTime.MaxValue).ToString(AppSettings.DayFormat));

            return this.DataAccess.QueryData(sql, new VInfoTypeRelation());

        }
    }
}
