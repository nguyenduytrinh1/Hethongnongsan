using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hethongnongsan.Models;

namespace Hethongnongsan.Controllers
{
    public class HomeController : Controller
    {
        HethongnongsanContext db = new HethongnongsanContext();
        // GET: Home
        public ActionResult Index()
        {
            var listsp = db.Sanpham.ToList();
            return View(listsp);
        }
    }
}