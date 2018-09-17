using MoneyBook.DataRelation;
using MoneyBook.Entities;
using MoneyBook.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyBook.DAL
{
    public class StatisticsDAL : DALBase
    {
        private VInfoDAL vInfo = VInfoDAL.GetObj();
        public List<VInfoEntity> MonthInfo(DateTime month)
        {
            var date = new DateTime(month.Year, month.Month, 1);
            return vInfo.QueryGroupByType(date, date.AddMonths(1));
        }

        public List<VInfoEntity> GetMonthDetail(DateTime month, string typeID)
        {
            var sql = @"
SELECT
	T.DATE,
	T.USE_AMOUNT,
	T.USE_WAY 
FROM
	V_INFO T 
WHERE
	T.DATE LIKE '{0}%' 
	AND T.TYPE_ID = '{1}' 
	AND T.IO_FLAG = 'O'";
            sql = string.Format(sql, month.ToString(AppSettings.MonthFormat), typeID);

            return this.DataAccess.QueryData(sql, new MonthDetailRelation());
        }

        public List<WeekEntity> Week(DateTime month)
        {
            var sql = @"
SELECT
	T.WEEK_COL,
	SUM( T.USE_AMOUNT ) AS USE_AMOUNT 
FROM
	V_WEEK T 
WHERE
	T.DATE_COL >= DATE( '{0}' ) 
	AND T.DATE_COL < DATE( '{1}' ) 
	AND T.IO_FLAG = 'O' 
GROUP BY
	T.WEEK_COL";
            var bDate = new DateTime(month.Year, 1, 1);
            var eDate = bDate.AddYears(1);
            sql = string.Format(sql,
                bDate.ToString(AppSettings.DayFormat),
                eDate.ToString(AppSettings.DayFormat));

            return this.DataAccess.QueryData(sql, new WeekRelation());
        }

        public List<WeekEntity> GetWeekDetail(string week)
        {
            var sql = @"
SELECT
	T.DATE,
	T.IO_FLAG,
	T.USE_WAY,
	T.TYPE_NAME,
	T.WEEK_COL,
	T.USE_AMOUNT 
FROM
	V_WEEK T
WHERE
	T.WEEK_COL = '{0}'";
            sql = string.Format(sql, week);

            return this.DataAccess.QueryData(sql, new WeekDetailRelation());
        }
    }
}
