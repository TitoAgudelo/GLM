using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IntranetGLM2013.Models;
using IntranetGLM2013.DAL;

namespace IntranetGLM2013.Controllers
{
    public class testLunchItemController : Controller
    {
        private GLMEEDContext db = new GLMEEDContext();

        // GET: /testLunchItem/
        public ActionResult Index()
        {
            return View(db.LunchItems.ToList());
        }

        // GET: /testLunchItem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LunchItem lunchitem = db.LunchItems.Find(id);
            if (lunchitem == null)
            {
                return HttpNotFound();
            }
            return View(lunchitem);
        }

        // GET: /testLunchItem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /testLunchItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Name,UrlPhoto,Like,Dislike,Category,Status")] LunchItem lunchitem)
        {
            if (ModelState.IsValid)
            {
                db.LunchItems.Add(lunchitem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lunchitem);
        }

        // GET: /testLunchItem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LunchItem lunchitem = db.LunchItems.Find(id);
            if (lunchitem == null)
            {
                return HttpNotFound();
            }
            return View(lunchitem);
        }

        // POST: /testLunchItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Name,UrlPhoto,Like,Dislike,Category,Status")] LunchItem lunchitem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lunchitem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lunchitem);
        }

        // GET: /testLunchItem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LunchItem lunchitem = db.LunchItems.Find(id);
            if (lunchitem == null)
            {
                return HttpNotFound();
            }
            return View(lunchitem);
        }

        // POST: /testLunchItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LunchItem lunchitem = db.LunchItems.Find(id);
            db.LunchItems.Remove(lunchitem);
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
