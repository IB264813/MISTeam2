﻿using System;
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
    [Authorize]
    public class RecognitionsController : Controller
    {
        private Context db = new Context();

        // GET: Recognitions
        public ActionResult Index(Guid? id, string emp)
        {
            var recognition = db.Recognition.Include(r => r.Giver).Include(r => r.UserDetail);
            if (id != null)
            {
                recognition = db.Recognition.Where(e => e.ID == id).Include(e => e.UserDetail).Include(e => e.RecognitionId).Include(e => e.EmployeeGivingRecog);

                ViewBag.Awardee = emp;
                var awards = (from aw in recognition
                              group aw by new
                              { e = aw.UserDetail.ID, a = aw.RecognitionId } into g
                              select new
                              { receiverID = g.Key.e, awardID = g.Key.a, AwardCount = g.Count() });
                ViewBag.AwardList = awards.ToList();

                return View("Awards");


            }
            else
            {
                return View(recognition.ToList());

            }

        }

        // GET: Recognitions/Details/5
        public ActionResult Details(int? id)
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
            ViewBag.EmployeeGivingRecog = new SelectList(db.userDetails, "ID", "fullName");
            ViewBag.ID = new SelectList(db.userDetails, "ID", "fullName");
            return View();
        }

        // POST: Recognitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "EmployeeRecognitionID,RecognitionId,EmployeeGivingRecog,RecognitionComments,ID")] Recognition recognition)
        {
            if (ModelState.IsValid)
            {
                //recognition.ID = Guid.NewGuid();
                db.Recognition.Add(recognition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeGivingRecog = new SelectList(db.userDetails, "ID", "fullName", recognition.EmployeeGivingRecog);
            ViewBag.ID = new SelectList(db.userDetails, "ID", "fullName", recognition.ID);
            return View(recognition);
        }

        // GET: Recognitions/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.EmployeeGivingRecog = new SelectList(db.userDetails, "ID", "Email", recognition.EmployeeGivingRecog);
            ViewBag.ID = new SelectList(db.userDetails, "ID", "Email", recognition.ID);
            return View(recognition);
        }

        // POST: Recognitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeRecognitionID,RecognitionId,EmployeeGivingRecog,RecognitionComments,ID")] Recognition recognition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recognition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeGivingRecog = new SelectList(db.userDetails, "ID", "Email", recognition.EmployeeGivingRecog);
            ViewBag.ID = new SelectList(db.userDetails, "ID", "Email", recognition.ID);
            return View(recognition);
        }

        // GET: Recognitions/Delete/5
        public ActionResult Delete(int? id)
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
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
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
