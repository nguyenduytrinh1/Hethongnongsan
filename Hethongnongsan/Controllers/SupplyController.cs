using Hethongnongsan.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hethongnongsan.Controllers
{
    public class SupplyController : Controller
    {
        HethongnongsanContext db = new HethongnongsanContext();
        // GET: Supply
        public ActionResult Addpro(int id)
        {
            Nguoidung nguoidung = db.Nguoidung.FirstOrDefault(row => row.Idnguoidung == id);
            Shop shop = db.Shop.FirstOrDefault(row => row.Idshop == nguoidung.Idshop);
            ViewBag.id = shop.Idshop;
            return View(nguoidung);
        }
        [HttpPost]
        public ActionResult Addpro(Sanpham sp,string nameimg, HttpPostedFileBase imageFile)
        {
            string url = "";
            string fileName = Path.GetFileName(imageFile.FileName);
            string filePath = Path.Combine(Server.MapPath("~/img"), nameimg + sp.Idsanpham+".jpg");
            if (System.IO.File.Exists(filePath))
            {
                ViewBag.Message = "File deleted successfully.";
            }
            else
            {
                imageFile = Request.Files["imageFile"];

                if (imageFile != null && imageFile.ContentLength > 0)
                {
                    /*string uploadDirectory = Server.MapPath("~/App_Data");*/

                    
                    imageFile.SaveAs(filePath);
                    /*if (!Directory.Exists(uploadDirectory))
                    {
                        Directory.CreateDirectory(uploadDirectory);
                    }*/
                    /*string fileName = Path.GetFileName(imageFile.FileName);
                    string filePath = Path.Combine(uploadDirectory, fileName);
                    imageFile.SaveAs(filePath);*/
                    ViewBag.Message = "Image uploaded successfully!";
                }
                else
                {
                    ViewBag.Message = "Please select an image to upload.";
                }
                Nguoidung nguoidung = db.Nguoidung.FirstOrDefault(row => row.Idshop == sp.Idshop);
                sp.Linkhinhanh = nameimg +sp.Idsanpham+ ".jpg";
                db.Sanpham.Add(sp);
                db.SaveChanges();
                db.SaveChanges();
                url = "https://localhost:44345/Shops/Index/" + nguoidung.Idnguoidung;
            }         
            return Redirect(url);
        }

        public ActionResult Editpro(int id)
        {
            Nguoidung nguoidung = db.Nguoidung.FirstOrDefault(row => row.Idnguoidung == id);
            Sanpham sp = db.Sanpham.Where(row => row.Idsanpham == id).FirstOrDefault();
            return View(sp);
        }
        [HttpPost]
        public ActionResult Editpro(Sanpham sp, string nameimg, HttpPostedFileBase imageFile)
        {
            string fileName = Path.GetFileName(imageFile.FileName);
            string filePath = Path.Combine(Server.MapPath("~/img"), nameimg + sp.Idsanpham + ".jpg");
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
                ViewBag.Message = "File deleted successfully.";
            }
            imageFile = Request.Files["imageFile"];

            if (imageFile != null && imageFile.ContentLength > 0)
            {
                /*string uploadDirectory = Server.MapPath("~/App_Data");*/

                imageFile.SaveAs(filePath);
                /*if (!Directory.Exists(uploadDirectory))
                {
                    Directory.CreateDirectory(uploadDirectory);
                }*/
                /*string fileName = Path.GetFileName(imageFile.FileName);
                string filePath = Path.Combine(uploadDirectory, fileName);
                imageFile.SaveAs(filePath);*/
                ViewBag.Message = "Image uploaded successfully!";
            }
            else
            {
                ViewBag.Message = "Please select an image to upload.";
            }

            Nguoidung nguoidung = db.Nguoidung.FirstOrDefault(row => row.Idshop == sp.Idshop);
            Sanpham sanpham = db.Sanpham.Where(row => row.Idsanpham == sp.Idsanpham).FirstOrDefault();
            sanpham.Tensanpham = sp.Tensanpham;
            sanpham.Linkhinhanh = nameimg + sp.Idsanpham + ".jpg";
            sanpham.Idshop = sp.Idshop;
            sanpham.Tenloai = sp.Tenloai;
            sanpham.Gia = sp.Gia;
            db.SaveChanges();
            string url = "https://localhost:44345/Shops/Index/" + nguoidung.Idnguoidung;
            return Redirect(url);
        }


        public ActionResult Deletepro(int idsp, int idshop)
        {
            Nguoidung nguoidung = db.Nguoidung.FirstOrDefault(row => row.Idshop == idshop);
            Sanpham sanpham = db.Sanpham.Where(row => row.Idsanpham == idsp).FirstOrDefault();
            db.Sanpham.Remove(sanpham);
            db.SaveChanges();
            string url = "https://localhost:44345/Shops/Index/" + nguoidung.Idnguoidung;
            return Redirect(url);
        }
        [HttpPost]
        public FileResult DownloadImage(HttpPostedFileBase imageFile)
        {
            if (imageFile != null && imageFile.ContentLength > 0)
            {
                var fileName = Path.GetFileName(imageFile.FileName);
                var filePath = Path.Combine(Server.MapPath("~/App_Data"), fileName);
                imageFile.SaveAs(filePath);
                return File(filePath, "image/jpeg", fileName);
            }
            else
            {
                
                return null; 
            }
        }
    }
}