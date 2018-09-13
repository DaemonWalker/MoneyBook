using Microsoft.AspNetCore.Mvc;
using MoneyBook.BLL;
using MoneyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyBook.Controllers
{
    public class TypeController : Controller
    {
        private TypeBLL bll = new TypeBLL();

        [HttpPost]
        public IActionResult Check(IEnumerable<TypeModel> typeModels)
        {
            try
            {
                bll.Check(typeModels);
                return Json(ResultModel.Success("更新收支类型成功!"));
            }
            catch (Exception e)
            {
                return Json(ResultModel.Error(e.Message));
            }
        }
        
        [HttpPost]
        public IActionResult Query()
        {
            return Json(bll.QueryAll());
        }
        
    }
}