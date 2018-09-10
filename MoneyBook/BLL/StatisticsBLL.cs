using MoneyBook.DAL;
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
    }
}
