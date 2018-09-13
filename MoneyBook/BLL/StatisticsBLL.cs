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
                UseType = p.UseType,
                Percent = Math.Round(p.TotalMoney * 100 / totalMoney, 2),
                IsSum = false,
                ShowDetail = false,
                UseTypeID = p.UseTypeID
            }).ToList();
            list.Add(new MonthModel() { TotalMoney = list.Sum(p => p.TotalMoney), UseWay = "总计", IsSum = true });

            return list;
        }

        public List<MonthDetailModel> GetMonthDetail(DateTime month, string typeID)
        {
            var list = dal.GetMonthDetail(month, typeID);
            var totalMoney = list.Sum(p => p.UseAmount);
            return list.Select(p => new MonthDetailModel()
            {
                Date = p.Date,
                UseAmount = p.UseAmount,
                Percent = Math.Round(p.UseAmount * 100 / totalMoney, 2),
                UseWay = p.UseWay
            }).ToList();
        }

        public List<WeekModel> Week(DateTime month)
        {
            var list = dal.Week(month);
            var total = list.Sum(p => p.UseAmount);
            return list.Select(p => new WeekModel()
            {
                UseAmount = p.UseAmount,
                Week = $"{month.Month}月第{p.Week}周",
                Percent = Math.Round(p.UseAmount * 100 / total, 2),
                WeekIndex = p.Week
            }).ToList();
        }
        public List<MoneyModel> GetWeekDetail(string week)
        {
            var list = dal.GetWeekDetail(week);
            return list.Select(p => new MoneyModel()
            {
                IOFlag = p.IOFlag,
                UseAmount = p.UseAmount,
                UseType = p.UseType,
                UseWay = p.UseWay
            }).ToList();
        }
    }
}
