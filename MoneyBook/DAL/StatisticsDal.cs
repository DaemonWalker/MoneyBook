﻿using MoneyBook.DataRelation;
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
	T2.USE_WAY,
	SUM( T2.USE_AMOUNT ) AS TOTAL_AMOUNT 
FROM
	DAY_INFO T
	INNER JOIN MONEY_INFO T2 ON T.DAY_ID = T2.DAY_ID 
WHERE
	T.DATE LIKE '{0}%' 
	AND T2.SPEND_FLAG = '1' 
GROUP BY
	T2.USE_WAY 
ORDER BY
	TOTAL_AMOUNT DESC";
            sql = string.Format(sql, month.ToString(AppSettings.MonthFormat));

            return this.DataAccess.QueryData(sql, new MonthRelation());
        }

        public List<MoneyEntity> GetMonthDetail(DateTime month,string useWay)
        {
            var sql = @"
SELECT
	T1.DATE,
	T.USE_AMOUNT 
FROM
	MONEY_INFO T
	INNER JOIN DAY_INFO T1 ON T.DAY_ID = T1.DAY_ID 
WHERE
	T1.DATE LIKE '{0}%' 
	AND T.USE_WAY = '{1}' 
	AND T.SPEND_FLAG = '1' 
ORDER BY
	T1.DATE";
            sql = string.Format(sql, month.ToString(AppSettings.MonthFormat), useWay);

            return this.DataAccess.QueryData(sql, new MonthDetailRelation());
        }

        public List<object> GetWeekDetail(DateTime month)
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
	WHERE
		T1.SPEND_FLAG = '1' 
	ORDER BY
		T.DATE 
	) TAB 
GROUP BY
	WEEK";
        }
    }
}
