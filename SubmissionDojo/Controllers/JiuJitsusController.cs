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
    public class JiuJitsusController : Controller
    {
        private DojoContext db = new DojoContext();

        // GET: JiuJitsus
        public ActionResult Index()
        {
            return View(db.JiuJitsu.ToList());
        }

        public ActionResult Search()
        {
            return View();
        }


        // GET: JiuJitsus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JiuJitsu jiuJitsu = db.JiuJitsu.Find(id);
            if (jiuJitsu == null)
            {
                return HttpNotFound();
            }
            return View(jiuJitsu);
        }

        // GET: JiuJitsus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JiuJitsus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Link,Difficulty,Type")] JiuJitsu jiuJitsu)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.JiuJitsu.Add(jiuJitsu);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(jiuJitsu);
        }

        // GET: JiuJitsus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JiuJitsu jiuJitsu = db.JiuJitsu.Find(id);
            if (jiuJitsu == null)
            {
                return HttpNotFound();
            }
            return View(jiuJitsu);
        }

        // POST: JiuJitsus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Link,Difficulty,Type")] JiuJitsu jiuJitsu)
        {
            try {
                if (ModelState.IsValid)
                {
                    db.Entry(jiuJitsu).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(jiuJitsu);
        }

        // GET: JiuJitsus/Delete/5
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

            JiuJitsu jiuJitsu = db.JiuJitsu.Find(id);
            if (jiuJitsu == null)
            {
                return HttpNotFound();
            }
            return View(jiuJitsu);
        }

        // POST: JiuJitsus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                JiuJitsu jiuJitsu = db.JiuJitsu.Find(id);
                db.JiuJitsu.Remove(jiuJitsu);
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
