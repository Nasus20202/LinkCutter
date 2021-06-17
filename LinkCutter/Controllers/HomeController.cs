using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinkCutter.Models;

namespace LinkCutter.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            BaseModel model = new BaseModel("Link Cutter");
            return View(model);
        }
    }
}
