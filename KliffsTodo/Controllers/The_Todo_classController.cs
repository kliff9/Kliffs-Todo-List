using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using KliffsTodo.Models;

namespace KliffsTodo.Controllers
{
    public class The_Todo_classController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: The_Todo_class
        public ActionResult Index()
        {
            string currentuserId = User.Identity.GetUserId(); 
            ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentuserId); 
        
            return View(db.The_Todo.ToList().Where(x => x.User == currentUser));
        }

        // GET: The_Todo_class/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            The_Todo_class the_Todo_class = db.The_Todo.Find(id);
            if (the_Todo_class == null)
            {
                return HttpNotFound();
            }
            return View(the_Todo_class);
        }

        // GET: The_Todo_class/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: The_Todo_class/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,Finished")] The_Todo_class the_Todo_class)
        {


            if (ModelState.IsValid)
            {
                string currentuserId = User.Identity.GetUserId();
                ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentuserId);
                the_Todo_class.User = currentUser;
                db.The_Todo.Add(the_Todo_class);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(the_Todo_class);
        }

        // GET: The_Todo_class/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            The_Todo_class the_Todo_class = db.The_Todo.Find(id);
            if (the_Todo_class == null)
            {
                return HttpNotFound();
            }
            return View(the_Todo_class);
        }

        // POST: The_Todo_class/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,Finished")] The_Todo_class the_Todo_class)
        {
            if (ModelState.IsValid)
            {
                db.Entry(the_Todo_class).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(the_Todo_class);
        }

        // GET: The_Todo_class/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            The_Todo_class the_Todo_class = db.The_Todo.Find(id);
            if (the_Todo_class == null)
            {
                return HttpNotFound();
            }
            return View(the_Todo_class);
        }

        // POST: The_Todo_class/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            The_Todo_class the_Todo_class = db.The_Todo.Find(id);
            db.The_Todo.Remove(the_Todo_class);
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
