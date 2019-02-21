using Jop_Offers_Website.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jop_Offers_Website.Controllers
{
    
    public class RolesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View(db.Roles.ToList());
        }


        // GET: Roles/Details/5
        public ActionResult Details(string id)
        {
            var details = db.Roles.Find(id);
            if (details == null)
            {
                return HttpNotFound();
            }
            return View(details);
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        public ActionResult Create(IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                db.Roles.Add(role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }              
           
                return View(role);
            
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(string id)
        {
            var edite= db.Roles.Find(id);
            if (edite == null)
            {
                return HttpNotFound();
            }
            return View(edite);
        }

        // POST: Roles/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include ="Id,Name")]IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(role).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }                        
                return View(role);
          
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(string id)
        {
            
            return View(db.Roles.Find(id));
        }

        // POST: Roles/Delete/5
        [HttpPost]
        public ActionResult Delete(IdentityRole role)
        {
            var delete = db.Roles.Find(role.Id);
            db.Roles.Remove(delete);
            db.SaveChanges();
            return RedirectToAction("Index");
           
            return View();
            
        }
    }
}
