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
            if (!link.Url.Contains("//"))
                link.Url = "http://" + link.Url;
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

        [HttpPost]
        [Route("/cut")]
        public IActionResult Cut(string url = "")
        {
            if (HttpContext.Request.Headers["X-Requested-With"] != "XMLHttpRequest")
                return BadRequest();
            if (!url.Contains("."))
            {
                return Ok("Bad");
            }
            string code;
            using(var db = new Database())
            {
                Link link = new Link();
                link.Url = url;
                do
                {
                    code = string.Empty;
                    Random random = new Random();
                    for (int i = 0; i < 5; i++)
                    {
                        int r = random.Next(36); char c;
                        if (r < 10)
                            c = (char)(r + 48);
                        else
                            c = (char)(r + 97 - 10);
                        code += c;
                    }
                } while (db.Links.Where(l => l.Code == code).FirstOrDefault() != null);
                link.Code = code;
                if (!link.Url.Contains("//"))
                    link.Url = "http://" + link.Url;
                db.Links.Add(link);
                db.SaveChanges();
            }
            return Content(code);
        }
    }
}
