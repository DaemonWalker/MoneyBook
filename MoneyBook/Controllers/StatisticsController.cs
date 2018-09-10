﻿using Microsoft.AspNetCore.Mvc;
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
    }
}