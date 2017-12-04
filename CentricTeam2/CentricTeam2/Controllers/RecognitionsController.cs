using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CentricTeam2.DAL;
using CentricTeam2.Models;

namespace CentricTeam2.Controllers
{
    public class RecognitionsController : Controller
    {
        private Context db = new Context();

        // GET: Recognitions
        public ActionResult Index()
        {
            var recognition = db.Recognition.Include(r => r.UserDetails);
            return View(recognition.ToList());
        }

        // GET: Recognitions/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recognition recognition = db.Recognition.Find(id);
            if (recognition == null)
            {
                return HttpNotFound();
            }
            return View(recognition);
        }

        // GET: Recognitions/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.userDetails, "ID", "fullName");
            return View();
        }

        // POST: Recognitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeGivingRecog,RecognitionId,ID,recognizationDate,RecognitionComments")] Recognition recognition)
        {
            if (ModelState.IsValid)
            {
                recognition.EmployeeGivingRecog = Guid.NewGuid();
                db.Recognition.Add(recognition);
                db.SaveChanges();
                return RedirectToAction("Create", "EmployeeRecognitions");
            }

            ViewBag.ID = new SelectList(db.userDetails, "ID", "fullName", recognition.ID);
            return View(recognition);
        }

        // GET: Recognitions/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recognition recognition = db.Recognition.Find(id);
            if (recognition == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.userDetails, "ID", "fullName", recognition.ID);
            return View(recognition);
        }

        // POST: Recognitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeGivingRecog,RecognitionId,ID,recognizationDate,RecognitionComments")] Recognition recognition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recognition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.userDetails, "ID", "fullName", recognition.ID);
            return View(recognition);
        }

        // GET: Recognitions/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recognition recognition = db.Recognition.Find(id);
            if (recognition == null)
            {
                return HttpNotFound();
            }
            return View(recognition);
        }

        // POST: Recognitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Recognition recognition = db.Recognition.Find(id);
            db.Recognition.Remove(recognition);
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
