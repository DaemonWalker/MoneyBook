using MoneyBook.DAL;
using MoneyBook.Entities;
using MoneyBook.Enums;
using MoneyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyBook.BLL
{
    public class DayBLL
    {
        private DayDAL dal = new DayDAL();
        public void CheckData(IEnumerable<DayModel> data)
        {
            var addList = new List<VInfoEntity>();
            var delList = new List<string>();
            foreach (var day in data)
            {
                foreach (var money in day.Detail)
                {
                    if (string.IsNullOrWhiteSpace(money.ID))
                    {
                        addList.Add(new VInfoEntity()
                        {
                            Date = day.Date,
                            IOFlag = money.IOFlag,
                            UseAmount = money.UseAmount,
                            UseWay = money.UseWay,
                            TypeID = money.UseTypeID
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
                day.Detail = kv.Select(p => new MoneyModel()
                {
                    ID = p.MoneyID,
                    IOFlag = p.IOFlag,
                    UseAmount = p.UseAmount,
                    UseWay = p.UseWay,
                    Percent = Math.Round(p.UseAmount * 100 / totalMoney, 2),
                    IsDelete = false,
                    UseType = p.TypeName
                }).ToList();

                list.Add(day);
            }

            return list;
        }
    }
}
