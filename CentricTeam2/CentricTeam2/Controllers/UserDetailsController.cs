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
using Microsoft.AspNet.Identity;

namespace CentricTeam2.Controllers
{
    public class UserDetailsController : Controller
    {
        private Context db = new Context();



        // GET: Users
        public ActionResult Index(string searchString)
        {
            var testusers = from u in db.userDetails select u;
            if (!String.IsNullOrEmpty(searchString))
            {
               testusers = testusers.Where(u => u.lastName.Contains(searchString)
              || u.firstName.Contains(searchString));
                // if here, users were found so view them
                  return View(testusers.ToList());
            }
            return View(db.userDetails.ToList());
        }





        // GET: UserDetails/Details/5
        public ActionResult Details(Guid? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetails userDetails = db.userDetails.Find(ID);
            if (ID == null)
            {
                return HttpNotFound();
            }
            return View(userDetails);
        }

        // GET: UserDetails/Create
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.email = User.Identity.Name;
                return View();
            }
            else
            {
                return View("NotAuthenticated");
            }
        }


        // POST: UserDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Email,firstName,lastName,PhoneNumber,Office,Position,hireDate,photo")] UserDetails userDetails)
        {

            if (ModelState.IsValid)
            {
                // the following code assigns the logged in user’s ID to the ID of the userDetails
                Guid memberID;
                Guid.TryParse(User.Identity.GetUserId(), out memberID);
                userDetails.ID = memberID;
                // the next line sets userDetails.Email = the name of the current user (an email)
                userDetails.Email = User.Identity.Name;
                // the next several lines of code allow you to upload an image of the user
                //this requires modifications to the Create View
                //if there is no image this will be skipped with no harm



                db.userDetails.Add(userDetails);

                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return View("DuplicateUser");
                }

            }

            return View(userDetails);
        }





        // GET: UserDetails/Edit/5
        public ActionResult Edit(Guid? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetails userDetails = db.userDetails.Find(ID);
            if (ID == null)
            {
                return HttpNotFound();
            }
            return View(userDetails);
        }

        // POST: UserDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Email,firstName,lastName,PhoneNumber,Office,Position,hireDate,photo,businessUnit")] UserDetails userDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userDetails);
        }

        // GET: UserDetails/Delete/5
        public ActionResult Delete(Guid? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetails userDetails = db.userDetails.Find(ID);
            if (userDetails == null)
            {
                return HttpNotFound();
            }
            return View(userDetails);
        }

        // POST: UserDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid ID)
        {
            UserDetails userDetails = db.userDetails.Find(ID);
            db.userDetails.Remove(userDetails);
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