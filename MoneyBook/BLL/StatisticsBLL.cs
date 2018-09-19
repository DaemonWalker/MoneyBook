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
        private WeekDAL dal = new WeekDAL();
        private VInfoDAL infoDAL = VInfoDAL.GetObj();
        public List<MonthModel> MonthInfo(DateTime month)
        {
            var entities = infoDAL.QueryMoney(month, month.AddMonths(1));
            var totalMoney = entities.Sum(p => p.UseAmount);
            var list = entities.Select(p => new MonthModel()
            {
                TotalMoney = p.UseAmount,
                UseType = p.TypeName,
                Percent = Math.Round(p.UseAmount * 100 / totalMoney, 2),
                IsSum = false,
                ShowDetail = false,
                UseTypeID = p.TypeID
            }).ToList();
            list.Add(new MonthModel() { TotalMoney = Math.Round(list.Sum(p => p.TotalMoney), 2), UseType = "总计", IsSum = true });

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
            var result = list.Select(p => new WeekModel()
            {
                UseAmount = p.UseAmount,
                Week = $"{month.Year}年第{p.Week}周",
                Percent = Math.Round(p.UseAmount * 100 / total, 2),
                WeekIndex = p.Week,
                IsSum = false,
                ShowDetail = false
            }).ToList();
            var sum = new WeekModel() { UseAmount = total, Week = "总计", IsSum = true };
            result.Add(sum);
            return result;
        }
        public List<WeekDetailModel> GetWeekDetail(string week)
        {
            var list = dal.GetWeekDetail(week);
            return list.Select(p => new WeekDetailModel()
            {
                IOFlag = p.IOFlag,
                UseAmount = p.UseAmount,
                UseType = p.UseType,
                UseWay = p.UseWay,
                Date = p.Date
            }).ToList();
        }

        public object MonthInfoCharts(DateTime month)
        {
            return infoDAL.QueryMoney(month, month.AddMonths(1))
                .Select(p => new { name = p.TypeName, value = p.UseAmount })
                .ToList();
        }
    }
}
