using MoneyBook.DataBase;
using MoneyBook.DataRelation;
using MoneyBook.Entities;
using MoneyBook.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyBook.DAL
{
    public class DayDAL : DALBase
    {
        public List<VInfoEntity> QueryByMonth(DateTime month)
        {
            var date = new DateTime(month.Year, month.Month, 1);
            return VInfoDAL.GetObj().QueryMoney(date, date.AddMonths(1));
        }

        public void InsertMoneyInfo(IEnumerable<VInfoEntity> moneys)
        {
            this.DataAccess.ExecuteNonQueryWithTransaction((Action<System.Data.Common.DbCommand>)((command) =>
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
                                       TYPE_ID,
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
                    command.CommandText = string.Format(daySql, money.Date.ToString(AppSettings.DayFormat));
                    command.ExecuteNonQuery();
                    command.CommandText = string.Format(sql, (object)money.TypeID, money.UseWay, money.UseAmount, money.Date.ToString(AppSettings.DayFormat));
                    command.ExecuteNonQuery();
                }
            }));
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
