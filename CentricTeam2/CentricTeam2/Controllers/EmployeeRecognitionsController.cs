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
    public class EmployeeRecognitionsController : Controller
    {
        private Context db = new Context();

        // GET: EmployeeRecognitions
        public ActionResult Index()
        {
            var employeeRecognitions = db.EmployeeRecognitions.Include(e => e.Giver).Include(e => e.Recognition).Include(e => e.UserDetails);
            return View(employeeRecognitions.ToList());
        }

        // GET: EmployeeRecognitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeRecognition employeeRecognition = db.EmployeeRecognitions.Find(id);
            if (employeeRecognition == null)
            {
                return HttpNotFound();
            }
            return View(employeeRecognition);
        }

        // GET: EmployeeRecognitions/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeGivingRecog = new SelectList(db.userDetails, "ID", "Email");
            ViewBag.EmployeeGivingRecog = new SelectList(db.Recognitions, "EmployeeGivingRecog", "RecognitionComments");
            ViewBag.ID = new SelectList(db.UserDetails, "ID", "Email");
            return View();
        }

        // POST: EmployeeRecognitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeRecognitionID,CurentDateTime,RecognitionComments,EmployeeGivingRecog,RecognitionId,ID")] EmployeeRecognition employeeRecognition)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeRecognitions.Add(employeeRecognition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeGivingRecog = new SelectList(db.UserDetails, "ID", "Email", employeeRecognition.EmployeeGivingRecog);
            ViewBag.EmployeeGivingRecog = new SelectList(db.Recognitions, "EmployeeGivingRecog", "RecognitionComments", employeeRecognition.EmployeeGivingRecog);
            ViewBag.ID = new SelectList(db.UserDetails, "ID", "Email", employeeRecognition.ID);
            return View(employeeRecognition);
        }

        // GET: EmployeeRecognitions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeRecognition employeeRecognition = db.EmployeeRecognitions.Find(id);
            if (employeeRecognition == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeGivingRecog = new SelectList(db.UserDetails, "ID", "Email", employeeRecognition.EmployeeGivingRecog);
            ViewBag.EmployeeGivingRecog = new SelectList(db.Recognitions, "EmployeeGivingRecog", "RecognitionComments", employeeRecognition.EmployeeGivingRecog);
            ViewBag.ID = new SelectList(db.UserDetails, "ID", "Email", employeeRecognition.ID);
            return View(employeeRecognition);
        }

        // POST: EmployeeRecognitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeRecognitionID,CurentDateTime,RecognitionComments,EmployeeGivingRecog,RecognitionId,ID")] EmployeeRecognition employeeRecognition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeRecognition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeGivingRecog = new SelectList(db.UserDetails, "ID", "Email", employeeRecognition.EmployeeGivingRecog);
            ViewBag.EmployeeGivingRecog = new SelectList(db.Recognitions, "EmployeeGivingRecog", "RecognitionComments", employeeRecognition.EmployeeGivingRecog);
            ViewBag.ID = new SelectList(db.UserDetails, "ID", "Email", employeeRecognition.ID);
            return View(employeeRecognition);
        }

        // GET: EmployeeRecognitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeRecognition employeeRecognition = db.EmployeeRecognitions.Find(id);
            if (employeeRecognition == null)
            {
                return HttpNotFound();
            }
            return View(employeeRecognition);
        }

        // POST: EmployeeRecognitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeRecognition employeeRecognition = db.EmployeeRecognitions.Find(id);
            db.EmployeeRecognitions.Remove(employeeRecognition);
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
