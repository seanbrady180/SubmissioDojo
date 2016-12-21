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
    public class JudoesController : Controller
    {
        private DojoContext db = new DojoContext();

        // GET: Judoes
        public ActionResult Index()
        {
            return View(db.Judo.ToList());
        }

        // GET: Judoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Judo judo = db.Judo.Find(id);
            if (judo == null)
            {
                return HttpNotFound();
            }
            return View(judo);
        }

        // GET: Judoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Judoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Link,Difficulty,Type")] Judo judo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Judo.Add(judo);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(judo);
        }

        // GET: Judoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Judo judo = db.Judo.Find(id);
            if (judo == null)
            {
                return HttpNotFound();
            }
            return View(judo);
        }

        // POST: Judoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Link,Difficulty,Type")] Judo judo)
        {
            try {
                if (ModelState.IsValid)
                {
                    db.Entry(judo).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(judo);
        }

        // GET: Judoes/Delete/5
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

            Judo judo = db.Judo.Find(id);
            if (judo == null)
            {
                return HttpNotFound();
            }
            return View(judo);
        }

        // POST: Judoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Judo judo = db.Judo.Find(id);
                db.Judo.Remove(judo);
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
