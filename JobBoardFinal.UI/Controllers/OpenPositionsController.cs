using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobBoardFinal.Data;
using Microsoft.AspNet.Identity;
using System.Web.Security;

namespace JobBoardFinal.UI.Controllers
{
    [Authorize (Roles = "Admin,Manager,Employee")]
    public class OpenPositionsController : Controller
    {
        private JobBoardEntities db = new JobBoardEntities();

        // GET: OpenPositions
        [Authorize(Roles = "Admin,Manager,Employee")]
        public ActionResult Index()
        {
            if (User.IsInRole("Manager"))
            {
                string myUserID = User.Identity.GetUserId();
                var mgrOpenPositions = db.OpenPositions.Include(o => o.Location).Include(o => o.Position)
                    .Where(x => x.Location.ManagerID == myUserID);
                return View(mgrOpenPositions.ToList());

            }
            else 
            {
                var openPositions = db.OpenPositions.Include(o => o.Location).Include(o => o.Position);
                return View(openPositions.ToList());

            }

        }

        // GET: OpenPositions/Details/5
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            OpenPosition openPosition = db.OpenPositions.Find(id);
            if (openPosition == null)
            {
                return HttpNotFound();
            }
            return View(openPosition);
        }

        // GET: OpenPositions/Create
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Create()
        {
            if (User.IsInRole("Manager"))
            {
                string myUserID = User.Identity.GetUserId();
                var mgrLocations = db.Locations.Where(l => l.ManagerID == myUserID);
                ViewBag.LocationID = new SelectList(mgrLocations, "LocationID", "City");
                ViewBag.PositionID = new SelectList(db.Positions, "PositionID", "Title");
                return View();
            }
            else
            {
                ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "City");
                ViewBag.PositionID = new SelectList(db.Positions, "PositionID", "Title");
                return View();
            }
        }

        // POST: OpenPositions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OpenPositionID,PositionID,LocationID")] OpenPosition openPosition)
        {
            if (User.IsInRole("Manager"))
            {
                if (ModelState.IsValid)
                {
                    db.OpenPositions.Add(openPosition);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                string myUserID = User.Identity.GetUserId();
                var mgrLocations = db.Locations.Where(l => l.ManagerID == myUserID);
                ViewBag.LocationID = new SelectList(mgrLocations, "LocationID","City",openPosition.LocationID);
                ViewBag.PositionID = new SelectList(db.Positions, "PositionID", "Title", openPosition.PositionID);
                return View(openPosition);

            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.OpenPositions.Add(openPosition);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "City", openPosition.LocationID);
                ViewBag.PositionID = new SelectList(db.Positions, "PositionID", "Title", openPosition.PositionID);
                return View(openPosition);
            }


        }

        // GET: OpenPositions/Edit/5
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpenPosition openPosition = db.OpenPositions.Find(id);
            if (openPosition == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "City", openPosition.LocationID); 
            ViewBag.PositionID = new SelectList(db.Positions, "PositionID", "Title", openPosition.PositionID);
            return View(openPosition);
        }

        // POST: OpenPositions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OpenPositionID,PositionID,LocationID")] OpenPosition openPosition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(openPosition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "City", openPosition.LocationID);
            ViewBag.PositionID = new SelectList(db.Positions, "PositionID", "Title", openPosition.PositionID);
            return View(openPosition);

        }

        // GET: OpenPositions/Delete/5
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpenPosition openPosition = db.OpenPositions.Find(id);
            if (openPosition == null)
            {
                return HttpNotFound();
            }
            return View(openPosition);
        }

        // POST: OpenPositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OpenPosition openPosition = db.OpenPositions.Find(id);
            db.OpenPositions.Remove(openPosition);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Apply([Bind(Include = "OpenPositionID,UserID,ApplicationDate,isDeclined,ResumeFilename")] Application app,int openPosition)
        {

            string myUserID = User.Identity.GetUserId();
            app.UserID = myUserID;
            app.OpenPositionID = openPosition;
            app.ApplicationDate = DateTime.Now;
            app.ResumeFilename = db.UserDetails.Where(ud => ud.UserId == myUserID).SingleOrDefault().ResumeFilename;
            app.IsDeclined = false;
            db.Applications.Add(app);
            db.SaveChanges();
            
            return RedirectToAction("Index", "Applications");
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
