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
        public List<MonthEntity> MonthInfo(DateTime month)
        {
            var sql = @"
SELECT
	T3.TYPE_NAME,
	SUM( T2.USE_AMOUNT ) AS TOTAL_AMOUNT,
	T3.TYPE_ID 
FROM
	DAY_INFO T
	INNER JOIN MONEY_INFO T2 ON T.DAY_ID = T2.DAY_ID
	INNER JOIN TYPE_INFO T3 ON T2.TYPE_ID = T3.TYPE_ID 
WHERE
	T.DATE LIKE '{0}%' 
	AND T3.IO_FLAG = 'O' 
GROUP BY
	T3.TYPE_ID,
	T3.TYPE_NAME 
ORDER BY
	TOTAL_AMOUNT DESC";
            sql = string.Format(sql, month.ToString(AppSettings.MonthFormat));

            return this.DataAccess.QueryData(sql, new MonthRelation());
        }

        public List<MoneyEntity> GetMonthDetail(DateTime month, string typeID)
        {
            var sql = @"
SELECT
	T1.DATE,
	T.USE_AMOUNT,
	T.USE_WAY 
FROM
	MONEY_INFO T
	INNER JOIN DAY_INFO T1 ON T.DAY_ID = T1.DAY_ID
	INNER JOIN TYPE_INFO T3 ON T.TYPE_ID = T3.TYPE_ID 
WHERE
	T1.DATE LIKE '{0}%' 
	AND T.TYPE_ID = '{1}' 
	AND T3.IO_FLAG = 'O' 
ORDER BY
	T1.DATE";
            sql = string.Format(sql, month.ToString(AppSettings.MonthFormat), typeID);

            return this.DataAccess.QueryData(sql, new MonthDetailRelation());
        }

        public List<WeekEntity> Week(DateTime month)
        {
            var sql = @"
SELECT
	WEEK,
	SUM( TAB.USE_AMOUNT ) 
FROM
	(
	SELECT
		STRFTIME( '%w', T.DATE ) WEEK,
		T1.USE_AMOUNT 
	FROM
		DAY_INFO T
		INNER JOIN MONEY_INFO T1 ON T.DAY_ID = T1.DAY_ID
		INNER JOIN TYPE_INFO T2 ON T1.TYPE_ID = T2.TYPE_ID 
	WHERE
		T2.IO_FLAG = 'O' 
		AND T.DATE > DATE( '{0}', 'start of day', - ( ( strftime( '%w', '{0}' ) + 7 ) % 8 ) || ' days' ) 
		AND T.DATE < DATE( '{1}', 'start of day', - ( ( strftime( '%w', '{1}' ) + 7 ) % 8 ) || ' days' ) 
	ORDER BY
		T.DATE 
	) TAB 
GROUP BY
	WEEK";
            var bDate = new DateTime(month.Year, month.Month, 1);
            var eDate = bDate.AddMonths(1);
            sql = string.Format(sql,
                bDate.ToString(AppSettings.DayFormat),
                eDate.ToString(AppSettings.DayFormat));

            return this.DataAccess.QueryData(sql, new WeekRelation());
        }

        public List<DayEntity> GetWeekDetail(string week)
        {
            var sql = @"
WITH TEMPT AS (
	SELECT
		T1.DATE,
		T.MONEYINFO_ID,
		T2.IO_FLAG,
		T.USE_WAY,
		T2.TYPE_NAME,
		STRFTIME( '%W', T1.DATE ) AS WEEK_IDX 
	FROM
		MONEY_INFO T
		INNER JOIN DAY_INFO T1 ON T.DAY_ID = T1.DAY_ID
		INNER JOIN TYPE_INFO T2 ON T.TYPE_ID = T2.TYPE_ID 
	) SELECT
	TEMPT.* 
FROM
	TEMPT 
WHERE
	WEEK_IDX = {0}";
            sql = string.Format(sql, week);

            return this.DataAccess.QueryData(sql, new DayRelation());
        }
    }
}
