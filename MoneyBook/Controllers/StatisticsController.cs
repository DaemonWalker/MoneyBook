using Microsoft.AspNetCore.Mvc;
using MoneyBook.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyBook.Controllers
{
    public class StatisticsController : Controller
    {
        private StatisticsBLL bll = new StatisticsBLL();
        [HttpPost]
        public IActionResult Month(DateTime date)
        {
            return Json(bll.MonthInfo(date));
        }

        [HttpPost]
        public IActionResult GetMonthDetail(DateTime date, string typeID)
        {
            return Json(bll.GetMonthDetail(date, typeID));
        }

        [HttpPost]
        public IActionResult Week(DateTime date)
        {
            return Json(bll.Week(date));
        }

        [HttpPost]
        public IActionResult GetWeekDetail(string weekIndex)
        {
            return Json(bll.GetWeekDetail(weekIndex));
        }

        public IActionResult GetDayDetail(DateTime bDate,DateTime eDate)
        {
            return null;
        }
    }
}