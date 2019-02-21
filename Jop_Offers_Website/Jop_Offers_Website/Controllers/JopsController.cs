using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Jop_Offers_Website.Models;
using Microsoft.AspNet.Identity;

namespace Jop_Offers_Website.Controllers
{
    public class JopsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Jops
        public ActionResult Index()
        {
            var jops = db.Jops.Include(j => j.Category);
            return View(jops.ToList());
        }

        // GET: Jops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jop jop = db.Jops.Find(id);
            if (jop == null)
            {
                return HttpNotFound();
            }
            return View(jop);
        }

        // GET: Jops/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName");
            return View();
        }

        // POST: Jops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]       
        public ActionResult Create( Jop jop, HttpPostedFileBase file)
        {
           
        
            string fileName = Path.GetFileNameWithoutExtension(file.FileName);
            string extension = Path.GetExtension(file.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            jop.jopImg = "~/files/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/files/"), fileName);
            file.SaveAs(fileName);
            
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                jop.UserId = User.Identity.GetUserId();
                db.Jops.Add(jop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.Clear();

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", jop.CategoryId);
            return View(jop);

        }

        // GET: Jops/Edit/5
        public ActionResult Edit(  int? id)
        {
          
          

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jop jop = db.Jops.Find(id);
            if (jop == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", jop.CategoryId);
            return View(jop);
        }

        // POST: Jops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Jop jop, HttpPostedFileBase file)
        {
           
           
            if (file != null)
            {
                string oldpath = Path.GetFileNameWithoutExtension(file.FileName);
                string extension1 = Path.GetExtension(file.FileName);
                oldpath = oldpath + DateTime.Now.ToString("yymmssfff") + extension1;
                jop.jopImg = "~/files/" + oldpath;
                oldpath = Path.Combine(Server.MapPath("~/files/"), oldpath);
                System.IO.File.Delete(oldpath);
                string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                jop.jopImg = "~/files/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/files/"), fileName);
                file.SaveAs(fileName);
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    db.Entry(jop).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Entry(jop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", jop.CategoryId);
            return View(jop);
        }

        // GET: Jops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jop jop = db.Jops.Find(id);
            if (jop == null)
            {
                return HttpNotFound();
            }
            return View(jop);
        }

        // POST: Jops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jop jop = db.Jops.Find(id);
            db.Jops.Remove(jop);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
