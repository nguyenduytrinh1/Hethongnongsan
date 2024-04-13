using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hethongnongsan.Models;

namespace Hethongnongsan.Controllers
{
    public class ProductsController : Controller
    {
        HethongnongsanContext db = new HethongnongsanContext();
        // GET: Products
        public ActionResult prod(int idsp)
        {
            var listsp = db.Sanpham.ToList();
            foreach (Sanpham a in listsp)
            {
                if (a.Idsanpham == idsp)
                {
                    ViewBag.Tensp = a.Tensanpham;
                    ViewBag.Gt = a.Gioithieu;
                    ViewBag.pri = a.Gia;
                    ViewBag.tl = a.Tenloai;
                    ViewBag.id = a.Idsanpham;
                    ViewBag.linkanh = a.Linkhinhanh;
                    ViewBag.idshop = a.Idshop;

                    return View();
                }
            }
            return View();
        }
        [Route("Products/Detail/{idnguoidung?}")]
        public ActionResult productsofcustumers(int idnguoidung)
        {
            List<Shopcart> shopcart = db.Shopcart.Where(row => row.Idnguoidung == idnguoidung && row.Status==0).ToList();
            List<Sanpham> sanpham = new List<Sanpham>();

            foreach (var a in shopcart)
            {

                if ((Sanpham)db.Sanpham.FirstOrDefault(row => row.Idsanpham == a.Idsanpham) != null)
                {
                    sanpham.Add((Sanpham)db.Sanpham.FirstOrDefault(row => row.Idsanpham == a.Idsanpham));
                }

            }
            ViewBag.sanpham = sanpham;
            ViewBag.shopcart = shopcart;
            return View();
        }
        [Route("Products/Detail/Search/{idnguoidung}")]
        public ActionResult search(int? idnguoidung, string tensp)
        {
            List<Shopcart> shopcart = db.Shopcart.Where(row => row.Idnguoidung == idnguoidung).ToList();
            List<Sanpham> sanpham = new List<Sanpham>();
            foreach (var a in shopcart)
            {
                Sanpham sp = (Sanpham)db.Sanpham.FirstOrDefault(row => row.Idsanpham == a.Idsanpham);
                if (sp.Tensanpham == tensp)
                {
                    sanpham.Add((Sanpham)db.Sanpham.FirstOrDefault(row => row.Idsanpham == a.Idsanpham));
                }
            }

            ViewBag.sanpham = sanpham;
            ViewBag.shopcart = shopcart;

            return View("productsofcustumers");
        }
        public ActionResult Delete(int idnguoidung, int idshopcart)
        {
            Shopcart shopcart = db.Shopcart.Where(row => row.Idshopcart == idshopcart).FirstOrDefault();
            db.Shopcart.Remove(shopcart);
            db.SaveChanges();
            //sua lai
            return RedirectToAction("Detail/" + idnguoidung);
        }
        public ActionResult Add(int idnguoidung, int idsanpham, int soluong,int idshop)
        {
            Shopcart shopcart = db.Shopcart.Where(row => row.Idshopcart == idnguoidung).FirstOrDefault();
            Shopcart shop = new Shopcart();
            shop.Idnguoidung = idnguoidung;
            shop.Idsanpham = idsanpham;
            shop.Soluong = soluong;
            shop.Idshop = idshop;
            shop.Status = 0;
            db.Shopcart.Add(shop);
            db.SaveChanges();

            return RedirectToAction("Detail/" + idnguoidung);
        }
    }
}