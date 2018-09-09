using MoneyBook.DataBase;
using MoneyBook.DataRelation;
using MoneyBook.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyBook.DAL
{
    public class DayDAL : DALBase
    {
        public List<DayEntity> QueryByMonth(DateTime month)
        {
            var sql = @"
SELECT T.DATE,
       T1.MONEYINFO_ID,
       T1.SPEND_FLAG,
       T1.USE_WAY,
       T1.USE_AMOUNT
  FROM DAY_INFO T
       INNER JOIN
       MONEY_INFO T1 ON T.DAY_ID = T1.DAY_ID
 WHERE T.DATE LIKE '{0}%';";
            sql = string.Format(sql, month.ToString("yyyyMM"));

            return this.DataAccess.QueryData(sql, new DayRelation());
        }

        public void InsertMoneyInfo(IEnumerable<MoneyEntity> moneys)
        {
            this.DataAccess.ExecuteNonQueryWithTransaction((command) =>
            {
                var daySql = @"
            INSERT INTO DAY_INFO (
                                     DATE
                                 )
                                 SELECT '{0}'
                                  WHERE NOT EXISTS (
                                                SELECT T.DAY_ID
                                                  FROM DAY_INFO T
                                                 WHERE T.DATE = '{0}'
                                            );";
                var sql = @"
            INSERT INTO MONEY_INFO (
                                       SPEND_FLAG,
                                       USE_WAY,
                                       USE_AMOUNT,
                                       DAY_ID
                                   )
                                   SELECT '{0}',
                                          '{1}',
                                          {2},
                                          T.DAY_ID
                                     FROM DAY_INFO T
                                    WHERE T.DATE = '{3}';";
                foreach (var money in moneys)
                {
                    command.CommandText = string.Format(daySql, money.Date.ToString("yyyyMMdd"));
                    command.ExecuteNonQuery();
                    command.CommandText = string.Format(sql, money.IsSpend ? "1" : "0", money.UseWay, money.UseAmount, money.Date.ToString("yyyyMMdd"));
                    command.ExecuteNonQuery();
                }
            });
        }

        public void DeleteMoneyInfo(IEnumerable<string> moneyIDs)
        {
            this.DataAccess.ExecuteNonQueryWithTransaction((command) =>
            {
                var sql = @"
DELETE FROM MONEY_INFO
      WHERE MONEYINFO_ID = '{0}';";

                foreach (var moneyID in moneyIDs)
                {
                    command.CommandText = string.Format(sql, moneyID);
                    command.ExecuteNonQuery();
                }
            });

        }
    }
}
