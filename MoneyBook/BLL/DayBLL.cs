using MoneyBook.DAL;
using MoneyBook.Entities;
using MoneyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyBook.BLL
{
    public class DayBLL
    {
        private DayDAL dal = new DayDAL();
        public void CheckData(IEnumerable<DayModel> data)
        {
            var addList = new List<MoneyEntity>();
            var delList = new List<string>();
            foreach (var day in data)
            {
                foreach (var money in day.Detail)
                {
                    if (string.IsNullOrWhiteSpace(money.ID))
                    {
                        addList.Add(new MoneyEntity()
                        {
                            Date = day.Date,
                            IsSpend = money.IsSpend,
                            UseAmount = money.UseAmount,
                            UseWay = money.UseWay
                        });
                    }
                    else if (money.IsDelete)
                    {
                        delList.Add(money.ID);
                    }
                }
            }
            dal.DeleteMoneyInfo(delList);
            dal.InsertMoneyInfo(addList);
        }

        public List<DayModel> QueryMonthInfo(DateTime date)
        {
            var days = dal.QueryByMonth(date).GroupBy(p => p.Date);
            var list = new List<DayModel>();

            foreach (var kv in days)
            {
                var day = new DayModel();
                day.Date = kv.Key;
                var totalMoney = kv.Sum(p => p.UseAmount);
                day.Detail = kv.Select(p => new MoneyShowModel()
                {
                    ID = p.MoneyID,
                    IsSpend = p.IsSpend,
                    UseAmount = p.UseAmount,
                    UseWay = p.UseWay,
                    Percent = Math.Round( p.UseAmount * 100 / totalMoney, 2)
                }).ToList<MoneyModel>();

                list.Add(day);
            }

            return list;
        }
    }
}
