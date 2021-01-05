using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using System.Web.Mvc;
using Microsoft.EntityFrameworkCore;

using RomanianFinancialTimes.Data;
using RomanianFinancialTimes.Models;
using ActionResult = Microsoft.AspNetCore.Mvc.ActionResult;
using Controller = Microsoft.AspNetCore.Mvc.Controller;

namespace RomanianFinancialTimes.Controllers
{
    public class ReadersController : Controller
    {
        private BlogContext context = new BlogContext();

        // GET: /readers/index
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public ActionResult Index()
        {
            ViewData["readers"] = context.Reader.ToList();

            return View();
        }

        // GET: /readers/details/{id}
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public ActionResult Details(int id)
        {
            var reader = context.Reader.Find(id);

            if (reader == null)
            {
                return NotFound();
            }

            return View(reader);
        }

        // GET: /readers/create
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /reader/create
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public ActionResult Create(Reader reader)
        {
            if (ModelState.IsValid)
            {
                context.Reader.Add(reader);

                context.SaveChanges();

                return RedirectToAction("Index", "readers");
            }
    
            return View(reader);
        }

        // GET: /readers/edit/{id}
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public ActionResult Edit(int id)
        {
            var reader = context.Reader.Find(id);

            if (reader == null)
            {
                return NotFound();
            }

            return View(reader);
        }

        // POST: /readers/edit
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public ActionResult Edit(Reader reader)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var oldReader = context.Reader.Find(reader.Id);

                    if (oldReader == null)
                    {
                        return NotFound();
                    }

                    oldReader.FirstName = reader.FirstName;
                    oldReader.LastName = reader.LastName;
                    oldReader.Email = reader.Email;

                    TryUpdateModelAsync(oldReader);

                    context.SaveChanges();

                    return RedirectToAction("Index", "readers");
                }
            }
            catch (Exception e)
            {
                return Json(new { error_message = e.Message }, JsonRequestBehavior.AllowGet);
            }

            return View(reader);
        }

        // GET: /readers/delete/{id}
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public ActionResult Delete(int id)
        {
            var reader = context.Reader.Find(id);

            if (reader == null)
            {
                return NotFound();
            }

            context.Reader.Remove(reader);

            context.SaveChanges();

            return RedirectToAction("Index", "readers");
        }
    }
}