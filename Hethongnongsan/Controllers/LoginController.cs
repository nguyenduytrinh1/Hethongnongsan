using Hethongnongsan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Net.WebRequestMethods;
namespace Hethongnongsan.Controllers
{
    public class LoginController : Controller
    {
        HethongnongsanContext db = new HethongnongsanContext();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Nguoidung nguoidung)
        {
            string url="";
            Nguoidung nd;
            nd = db.Nguoidung.FirstOrDefault(row => row.TaiKhoan == nguoidung.TaiKhoan);
            if(nd == null)
            {
                nguoidung.Roles = "User";
                db.Nguoidung.Add(nguoidung);
                db.SaveChanges();
                 url = "https://localhost:44345/Login/Index";
            }
            else
            {
                 url = "https://localhost:44345/Login/Index";
            }
            
            return Redirect(url);
        }
        [HttpPost]
        public ActionResult Process(string username, string password)
        {
            Nguoidung nguoidung =null;
            string url = "";
            nguoidung = db.Nguoidung.FirstOrDefault(row => row.TaiKhoan.Equals(username));
            if (nguoidung != null)
            {
                if(nguoidung.MatKhau.Equals(password))
                {
                    url = "https://localhost:44345/Home/Index";
                    HttpCookie cookie = new HttpCookie("nguoidung");
                    cookie.Values.Add("", nguoidung.Idnguoidung.ToString());
                    cookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(cookie);
                }
                else
                {
                     url = "https://localhost:44345/Login/Index";
                }
            }
            else
            {
                url = "https://www.youtube.com/watch?v=BaCR9hA6Eoo&list=RDMM7iME0MldxNM&index=40";
            }
            return Redirect(url);
        }
        [HttpPost]
        public ActionResult Out()
        {
            string tenCookie = "nguoidung";

            if (Request.Cookies[tenCookie] != null)
            {
                Response.Cookies.Remove(tenCookie);
            }
            string url = "https://localhost:44345/Login/Index";
            return Redirect(url);
        }
    }
}