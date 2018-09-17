using Microsoft.AspNetCore.Mvc;
using MoneyBook.Models;
using MoneyBook.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyBook.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Newtonsoft.Json.JsonConvert.SerializeObject(new { A = "1" });
            return View();
        }

        public IActionResult Month()
        {
            return View();
        }

        public IActionResult Week()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Test()
        {
            var i = 0;
            return Content((0 / i).ToString());
        }

        public IActionResult Types()
        {
            return View();
        }
    }
}
