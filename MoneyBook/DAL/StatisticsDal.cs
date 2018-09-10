using MoneyBook.DataRelation;
using MoneyBook.Entities;
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
SELECT T2.USE_WAY,
        SUM(T2.USE_AMOUNT) AS TOTAL_AMOUNT
    FROM DAY_INFO T
        INNER JOIN
        MONEY_INFO T2 ON T.DAY_ID = T2.DAY_ID
    WHERE T.DATE LIKE '{0}%'
    GROUP BY T2.USE_WAY
    ORDER BY TOTAL_AMOUNT DESC;";
            sql = string.Format(sql, month.ToString("yyyyMM"));

            return this.DataAccess.QueryData(sql, new MonthRelation());
        }
    }
}
