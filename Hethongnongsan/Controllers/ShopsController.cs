using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Mvc;
using Hethongnongsan.Models;

namespace Hethongnongsan.Controllers
{
    public class ShopsController : Controller
    {
        HethongnongsanContext db = new HethongnongsanContext();
        // GET: Shops
        public ActionResult Index(int id)
        {

            Nguoidung nguoidung = db.Nguoidung.FirstOrDefault(row => row.Idnguoidung == id);
            Shop shop = db.Shop.FirstOrDefault(row => row.Idshop == nguoidung.Idshop);
            List<Sanpham> sanphams = new List<Sanpham>();

            try
            {
                sanphams = db.Sanpham.Where(row => row.Idshop == nguoidung.Idshop).ToList();

            }
            catch (Exception ex)
            {

            }

            ViewBag.sanpham = sanphams;
            ViewBag.nguoidung = nguoidung;
            return View((Shop)shop);
        }

        //id chu so huu
        public ActionResult newShop(int id)
        {
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public ActionResult newShop(Shop shop)
        {
            db.Shop.Add(shop);
            db.SaveChanges();
            Shop shops = db.Shop.FirstOrDefault(row => row.Idchusohuu == shop.Idchusohuu);
            Nguoidung ng = db.Nguoidung.Where(row => row.Idnguoidung == shop.Idchusohuu).FirstOrDefault();
            ng.Idshop = shop.Idshop;
            db.SaveChanges();
            return RedirectToAction("Index", new { id = shop.Idchusohuu });
        }
        public ActionResult Delete(int id)
        {
            Nguoidung nguoidung = db.Nguoidung.FirstOrDefault(row => row.Idnguoidung == id);
            Shop shop = db.Shop.FirstOrDefault(row => row.Idshop == nguoidung.Idshop);
            List<Sanpham> sp = db.Sanpham.Where(row => row.Idshop == shop.Idshop).ToList();
            nguoidung.Idshop = null;
            db.Shop.Remove(shop);

            foreach (Sanpham item in sp){
                db.Sanpham.Remove(item);
            }
            
            db.SaveChanges();
            return RedirectToAction("Index", new { id = id });
        }

        public ActionResult Edit(int id)
        {
            Nguoidung nguoidung = db.Nguoidung.FirstOrDefault(row => row.Idnguoidung == id);
            Shop shop = db.Shop.FirstOrDefault(row => row.Idshop == nguoidung.Idshop);
            return View((Shop)shop);
        }
        [HttpPost]
        public ActionResult Edit(Shop shop)
        {
            ;
            Shop editshop = db.Shop.Where(row => row.Idshop == shop.Idshop).FirstOrDefault();

            //edit
            editshop.Idchusohuu = shop.Idchusohuu;
            editshop.Gioithieu = shop.Gioithieu;
            editshop.Logo = shop.Logo;
            editshop.Ngaythanhlap = shop.Ngaythanhlap;
            editshop.Instagram = shop.Instagram;
            editshop.Tenshop = shop.Tenshop;
            editshop.Tenshop = shop.Email;
            editshop.Email = shop.Email;
            editshop.Facebook = shop.Facebook;
            db.SaveChanges();
            return RedirectToAction("Index", new { id = shop.Idshop });
        }

    }
}