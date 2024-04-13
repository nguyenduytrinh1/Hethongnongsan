using Hethongnongsan.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Security;
using System.Web;
using System.Web.Mvc;

namespace Hethongnongsan.Controllers
{
    public class ProfilesuserController : Controller
    {
        // GET: Profilesuser
        HethongnongsanContext db = new HethongnongsanContext();
        public ActionResult Index(int id)
        {
            Nguoidung nguoidung = db.Nguoidung.FirstOrDefault(row => row.Idnguoidung == id);

            string check = "";
            Shop shop = db.Shop.FirstOrDefault(row => row.Idshop == nguoidung.Idshop);
            if (shop != null)
            {
                /* List<SanPhamDaBan> spdb = db.SanPhamDaBan.Where(row => row.Idshop == shop.Idshop).ToList();*/
                List<Shopcart> sp = db.Shopcart.Where(row => row.Idshop == shop.Idshop).ToList();

                List<Sanpham> spm = new List<Sanpham>();
                List<Nguoidung> nguoidungmua = new List<Nguoidung>();
                foreach (var item in sp)
                {
                    Nguoidung nm = db.Nguoidung.FirstOrDefault(row => row.Idnguoidung == item.Idnguoidung);
                    nguoidungmua.Add(nm);
                    Sanpham sanpham = db.Sanpham.FirstOrDefault(row => row.Idsanpham == item.Idsanpham);
                    spm.Add(sanpham);
                    check = check + item.Idshopcart + ",";
                }
                SanPhamDaBan spdb = db.SanPhamDaBan.FirstOrDefault(row => row.Idshopcart == check);
                Debug.WriteLine("Số lượng sản phẩm đã bán: " + spm.Count + "*" + nguoidungmua.Count + "*" + "check" + check);
                Debug.WriteLine("Số lượng sản phẩm đã bán: " + sp.Count);
                ViewBag.SanPhamn = spm;
                ViewBag.Nguoimua = nguoidungmua;
                ViewBag.SanPhamDaBan = spdb;
                ViewBag.Shopcart = sp;
            }
            else
            {
                ViewBag.SanPhamn = null;
                ViewBag.Nguoimua = null;
                ViewBag.SanPhamDaBan = null;
                ViewBag.Shopcart = null;
            }

            return View(nguoidung);
        }
        public ActionResult Updateprofiles(int id)
        {

            Nguoidung nguoidung = db.Nguoidung.FirstOrDefault(row => row.Idnguoidung == id);

            return View();
        }
        [HttpPost]
        public ActionResult Updateprofiles(Nguoidung nguoidung)
        {
            Nguoidung nguoidungs = db.Nguoidung.FirstOrDefault(row => row.Idnguoidung == nguoidung.Idnguoidung);
            nguoidungs.Diachi = nguoidung.Diachi;
            nguoidungs.Gioitinh = nguoidung.Gioitinh;
            nguoidungs.Sodienthoai=nguoidung.Sodienthoai;
            nguoidungs.Ngaysinh = nguoidung.Ngaysinh;
            nguoidungs.Tennguoidung = nguoidung.Tennguoidung;
            nguoidungs.TaiKhoan = nguoidung.TaiKhoan;
            nguoidungs.MatKhau = nguoidung.MatKhau;
            db.SaveChanges();

            return RedirectToAction("Index", new { id = nguoidungs.Idnguoidung });
        }
    }
}