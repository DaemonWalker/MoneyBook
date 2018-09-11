using MoneyBook.DAL;
using MoneyBook.Entities;
using MoneyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyBook.BLL
{
    public class StatisticsBLL
    {
        private StatisticsDAL dal = new StatisticsDAL();
        public List<MonthModel> MonthInfo(DateTime month)
        {
            var entities = dal.MonthInfo(month);
            var totalMoney = entities.Sum(p => p.TotalMoney);
            var list = entities.Select(p => new MonthModel()
            {
                TotalMoney = p.TotalMoney,
                UseWay = p.UseWay,
                Percent = Math.Round(p.TotalMoney * 100 / totalMoney, 2),
                IsSum = false
            }).ToList();
            list.Add(new MonthModel() { TotalMoney = list.Sum(p => p.TotalMoney), UseWay = "总计", IsSum = true });

            return list;
        }

        public List<MonthDetailModel> GetMonthDetail(DateTime month, string useWay)
        {
            var list = dal.GetMonthDetail(month, useWay);
            var totalMoney = list.Sum(p => p.UseAmount);
            return list.Select(p => new MonthDetailModel()
            {
                Date = p.Date,
                UseAmount = p.UseAmount,
                Percent = Math.Round(p.UseAmount * 100 / totalMoney, 2)
            }).ToList();
        }
    }
}
