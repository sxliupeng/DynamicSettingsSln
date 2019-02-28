﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicSettings.MVC.Controllers
{
    public class RightController : Controller
    {
        // GET: Right
        public ActionResult Index()
        {
            return View();
        }

        // GET: Right/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Right/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Right/Create
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

        // GET: Right/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Right/Edit/5
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

        // GET: Right/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Right/Delete/5
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
    }
}