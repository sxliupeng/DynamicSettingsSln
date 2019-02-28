using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DynamicSettings.CodeFirst.Context;
using DynamicSettings.CodeFirst.IDataAccess;
using DynamicSettings.Domain;
using DynamicSettings.EF.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicSettings.MVC.Controllers
{
    public class UserController : Controller
    {
		private SettingsManagementDbContext context;
		private User user;
		//public UserController(SettingsManagementDbContext ctx,User user)
		//public UserController(SettingsManagementDbContext ctx)
	    public UserController(SettingsManagementDbContext ctx,User user)
		{
			this.user = user;
			this.context = ctx;
		}

		public IActionResult Index()
	    {
		    return View(this.user.Users(null));
	    }

	    public IActionResult Register()
	    {
		    return View();
	    }

		[HttpPost]
		//[ValidateAntiForgeryToken]
	    public IActionResult Register(TblUser user)
	    {
		    if (ModelState.IsValid)
		    {
			    bool result=this.user.Create(user);
			    if (result)
				    RedirectToAction("Index");
		    }

		    return View(user);
	    }

		/*
	    // GET: User
		public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
		*/
    }
}