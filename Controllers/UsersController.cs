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
    public class UsersController : Controller
    {
        private FitnessContext db = new FitnessContext();

        // GET: Users
        public ActionResult Index()
        {
			if(Session["user"] == null)
			{
				return Redirect("/");
			}
			List<User> list = new List<User>();
			list.Add((User)Session["user"]);
			return View(list);
        }

        // GET: Users/Details/5
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
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
			return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,fName,lName,password")] User user)
        {
			if (Session["user"] == null)
			{
				return Redirect("/");
			}
			if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
				Session["user"] = user;
				List<User> list = new List<User>();
				list.Add(user);
				return View("Index", list);

            } 
            return View(user);
        }

        // GET: Users/Edit/5
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
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,fName,lName,password")] User user)
        {
			if (Session["user"] == null)
			{
				return Redirect("/");
			}
			if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
				List<User> list = new List<User>();
				list.Add(user);
				return View("Index", list);
			}
            return View(user);
        }

        // GET: Users/Delete/5
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
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			if (Session["user"] == null)
			{
				return Redirect("/");
			}
			User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
			Session["user"] = null;

			return Redirect("/");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

		


		// GET: Users/Details/5
		public ActionResult LogIn(User user)
		{
			if(user == null)
			{
				return Redirect("/");
			}

			if (user.Id.ToString().Trim() == "" || user.password.Trim() == "")
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			User userFromDB = db.Users.Find(user.Id);

			if (userFromDB == null)
			{
				return HttpNotFound();
			}
			
			if(userFromDB.password != user.password)
			{
				return HttpNotFound();
			}

			Session["user"] = userFromDB;
			List<User> list = new List<User>();
			list.Add(userFromDB);
			
			return View("Index", list);
		}

		public ActionResult GoToLogin()
		{
			
			return View("LogIn");
		}

		public ActionResult SignUp()
		{
			int count = db.Users.Max(x => x.Id);
			ViewData["IdCount"] = ++count;
	
			return View("Create");
		}
	}
}
