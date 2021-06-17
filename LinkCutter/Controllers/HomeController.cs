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
        [Route("/")]
        public IActionResult Index()
        {
            BaseModel model = new BaseModel("Link Cutter");
            return View(model);
        }

        [Route("/{code}")]
        public IActionResult RedirectToLink(string code)
        {
            Link link;
            using(var db = new Database())
            {
                link = db.Links.Where(l => l.Code == code).FirstOrDefault();
                if (link == null)
                    return Redirect("/");
                link.TimesUsed++;
                db.SaveChanges();
            }
            return Redirect(link.Url);
        }

        [Route("/{code}/info")]
        public IActionResult Info(string code)
        {
            Link link; LinkInfoModel model = new LinkInfoModel();
            using (var db = new Database())
            {
                link = db.Links.Where(l => l.Code == code).FirstOrDefault();
                if (link == null)
                    return Redirect("/");
                model.Link = link;
            }
            return View(model);
        }
    }
}
