using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SubmissionDojo.DAL;
using SubmissionDojo.Models;

namespace SubmissionDojo.Controllers
{
    public class WrestlingsController : Controller
    {
        private DojoContext db = new DojoContext();

        // GET: Wrestlings
        public ActionResult Index()
        {
            return View(db.Wrestling.ToList());
        }

        // GET: Wrestlings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wrestling wrestling = db.Wrestling.Find(id);
            if (wrestling == null)
            {
                return HttpNotFound();
            }
            return View(wrestling);
        }

        // GET: Wrestlings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Wrestlings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Link,Difficulty,Type")] Wrestling wrestling)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Wrestling.Add(wrestling);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(wrestling);
        }

        // GET: Wrestlings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wrestling wrestling = db.Wrestling.Find(id);
            if (wrestling == null)
            {
                return HttpNotFound();
            }
            return View(wrestling);
        }

        // POST: Wrestlings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Link,Difficulty,Type")] Wrestling wrestling)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(wrestling).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                 ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(wrestling);
        }

        // GET: Wrestlings/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }

            Wrestling wrestling = db.Wrestling.Find(id);
            if (wrestling == null)
            {
                return HttpNotFound();
            }
            return View(wrestling);
        }

        // POST: Wrestlings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try {
                Wrestling wrestling = db.Wrestling.Find(id);
                db.Wrestling.Remove(wrestling);
                db.SaveChanges();
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }

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
