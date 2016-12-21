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
    public class NoGIsController : Controller
    {
        private DojoContext db = new DojoContext();

        // GET: NoGIs
        public ActionResult Index()
        {
            return View(db.NoGi.ToList());
        }

        // GET: NoGIs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NoGI noGI = db.NoGi.Find(id);
            if (noGI == null)
            {
                return HttpNotFound();
            }
            return View(noGI);
        }

        // GET: NoGIs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NoGIs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Link,Difficulty,Type")] NoGI noGI)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.NoGi.Add(noGI);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                 ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(noGI);
        }

        // GET: NoGIs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NoGI noGI = db.NoGi.Find(id);
            if (noGI == null)
            {
                return HttpNotFound();
            }
            return View(noGI);
        }

        // POST: NoGIs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Link,Difficulty,Type")] NoGI noGI)
        {
            try {
                if (ModelState.IsValid)
                {
                    db.Entry(noGI).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(noGI);
        }

        // GET: NoGIs/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError=false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            NoGI noGI = db.NoGi.Find(id);
            if (noGI == null)
            {
                return HttpNotFound();
            }
            return View(noGI);
        }

        // POST: NoGIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                NoGI noGI = db.NoGi.Find(id);
                db.NoGi.Remove(noGI);
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
