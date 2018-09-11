using Microsoft.AspNetCore.Mvc;
using MoneyBook.BLL;
using MoneyBook.Models;
using MoneyBook.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyBook.Controllers
{
    public class DayController : Controller
    {
        private DayBLL bll = new DayBLL();

        [HttpPost]
        public IActionResult GetCurrentMonth(DateTime date)
        {
            var day = bll.QueryMonthInfo(DateTime.Now);
            return Json(day); 
        }

        [HttpPost]
        public IActionResult SaveData(IEnumerable<DayModel> data)
        {
            try
            {
                bll.CheckData(data);
                return Json(ResultModel.Success("更新数据成功"));
            }
            catch (Exception e)
            {
                return Json(ResultModel.Error(e.Message));
            }
        }

        [HttpGet]
        public IActionResult Test()
        {
            return Content(AppSettings.DataBase);
        }
    }
}