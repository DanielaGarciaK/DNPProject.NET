using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class WorkoutsController : Controller
    {
        private FitnessContext db = new FitnessContext();

        // GET: Workouts
        public ActionResult Index()
        {
			if (Session["user"] == null)
			{
				return Redirect("/");
			}
			User user = (User)Session["user"];
			List<Workout> list = db.Workouts.ToList();
			List<Workout> list2 = new List<Workout>();

			foreach(var item in list)
			{
				if(item.Id == user.Id)
				{
					list2.Add(item);
				}
			}
			return View(list2);
        }

        // GET: Workouts/Details/5
        public ActionResult Details(int? id)
        {
			if (Session["user"] == null)
			{
				return Redirect("/");
			}

			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workout workout = db.Workouts.Find(id);
            if (workout == null)
            {
                return HttpNotFound();
            }
            return View(workout);
        }

        // GET: Workouts/Create
        public ActionResult Create()
        {
			if (Session["user"] == null)
			{
				return Redirect("/");
			}
			return View();
        }

        // POST: Workouts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,type,duration,caloriesBurnt,startTime")] Workout workout)
        {
			if (Session["user"] == null)
			{
				return Redirect("/");
			}

			if (ModelState.IsValid)
            {
                db.Workouts.Add(workout);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workout);
        }

        // GET: Workouts/Edit/5
        public ActionResult Edit(int? id)
        {
			if (Session["user"] == null)
			{
				return Redirect("/");
			}
			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workout workout = db.Workouts.Find(id);
            if (workout == null)
            {
                return HttpNotFound();
            }
            return View(workout);
        }

        // POST: Workouts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,type,duration,caloriesBurnt,startTime")] Workout workout)
        {
			if (Session["user"] == null)
			{
				return Redirect("/");
			}
			if (ModelState.IsValid)
            {
                db.Entry(workout).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workout);
        }

        // GET: Workouts/Delete/5
        public ActionResult Delete(int? id)
        {
			if (Session["user"] == null)
			{
				return Redirect("/");
			}
			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workout workout = db.Workouts.Find(id);
            if (workout == null)
            {
                return HttpNotFound();
            }
            return View(workout);
        }

        // POST: Workouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			if (Session["user"] == null)
			{
				return Redirect("/");
			}
			Workout workout = db.Workouts.Find(id);
            db.Workouts.Remove(workout);
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
