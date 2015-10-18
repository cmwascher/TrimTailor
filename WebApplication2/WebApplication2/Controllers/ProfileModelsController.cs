using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ProfileModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProfileModels
        public ActionResult Index()
        {
            return View(db.ProfileModels.ToList());
        }

        // GET: ProfileModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfileModels profileModels = db.ProfileModels.Find(id);
            if (profileModels == null)
            {
                return HttpNotFound();
            }
            return View(profileModels);
        }

        // GET: ProfileModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfileModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,mes_waist")] ProfileModels profileModels)
        {
            if (ModelState.IsValid)
            {
                string userID = User.Identity.GetUserId();
                profileModels.ApplicationUserID = userID;
                profileModels.ApplicationUser = db.Users.FirstOrDefault(x => x.Id == userID);
                db.ProfileModels.Add(profileModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profileModels);
        }

        // GET: ProfileModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfileModels profileModels = db.ProfileModels.Find(id);
            if (profileModels == null)
            {
                return HttpNotFound();
            }
            return View(profileModels);
        }

        // POST: ProfileModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,mes_waist")] ProfileModels profileModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profileModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profileModels);
        }

        // GET: ProfileModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfileModels profileModels = db.ProfileModels.Find(id);
            if (profileModels == null)
            {
                return HttpNotFound();
            }
            return View(profileModels);
        }

        // POST: ProfileModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProfileModels profileModels = db.ProfileModels.Find(id);
            db.ProfileModels.Remove(profileModels);
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
