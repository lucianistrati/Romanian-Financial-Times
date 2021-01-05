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
    public class WritersController : Controller
    {
        private BlogContext context = new BlogContext();

        // GET: /Writers/index
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public ActionResult Index()
        {
            ViewData["Writers"] = context.Writer.ToList();

            return View();
        }

        // GET: /Writers/details/{id}
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public ActionResult Details(int id)
        {
            var writer = context.Writer.Find(id);

            if (writer == null)
            {
                return NotFound();
            }

            return View(writer);
        }

        // GET: /Writers/create
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Writer/create
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public ActionResult Create(Writer writer)
        {
            if (ModelState.IsValid)
            {
                context.Writer.Add(writer);

                context.SaveChanges();

                return RedirectToAction("Index", "Writers");
            }
    
            return View(writer);
        }

        // GET: /Writers/edit/{id}
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public ActionResult Edit(int id)
        {
            var writer = context.Writer.Find(id);

            if (writer == null)
            {
                return NotFound();
            }

            return View(writer);
        }

        // POST: /Writers/edit
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public ActionResult Edit(Writer writer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var oldWriter = context.Writer.Find(writer.Id);

                    if (oldWriter == null)
                    {
                        return NotFound();
                    }

                    oldWriter.FirstName = writer.FirstName;
                    oldWriter.LastName = writer.LastName;
                    oldWriter.Email = writer.Email;

                    TryUpdateModelAsync(oldWriter);

                    context.SaveChanges();

                    return RedirectToAction("Index", "Writers");
                }
            }
            catch (Exception e)
            {
                return Json(new { error_message = e.Message }, JsonRequestBehavior.AllowGet);
            }

            return View(writer);
        }

        // GET: /Writers/delete/{id}
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public ActionResult Delete(int id)
        {
            var writer = context.Writer.Find(id);

            if (writer == null)
            {
                return NotFound();
            }

            context.Writer.Remove(writer);

            context.SaveChanges();

            return RedirectToAction("Index", "Writers");
        }
    }
}