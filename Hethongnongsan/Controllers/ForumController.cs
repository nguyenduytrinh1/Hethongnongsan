using Hethongnongsan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hethongnongsan.Controllers
{
    public class ForumController : Controller
    {
        HethongnongsanContext db = new HethongnongsanContext();
        // GET: Forum
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult addForum()
        {
            List<Forum> forums = db.Forum.ToList();
           
            return View(forums);
        }
       [HttpPost]
        public ActionResult addForum(Forum forum) {
            db.Forum.Add(forum);
            forum.Ngaydang = DateTime.Now;
            db.SaveChanges();

            List<Forum> forums = db.Forum.ToList();
            return View(forums);
        }
        public ActionResult editForum(int id)
        {
            Forum forum = db.Forum.FirstOrDefault(row => row.Iddiendang == id);
            return View(forum);
        }
        [HttpPost]
        public ActionResult editForum(Forum forum)
        {
            Forum forums = db.Forum.FirstOrDefault(row => row.Iddiendang == forum.Iddiendang);
            forums.Context = forum.Context;
            db.SaveChanges();  
            return View();
        }

    
        public ActionResult deleteForum(int id)
        {
            Forum forum = db.Forum.FirstOrDefault(row => row.Iddiendang == id);
            db.Forum.Remove(forum);
            db.SaveChanges(true);
            return RedirectToAction("addForum", new { id = id });
        }
        
    }
}