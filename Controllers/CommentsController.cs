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
    public class CommentsController : Controller
    {
        private BlogContext context = new BlogContext();

        // GET: /Comments/index
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public ActionResult Index()
        {
            ViewData["Comments"] = context.Comment.ToList();

            return View();
        }

        // GET: /Comments/details/{id}
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public ActionResult Details(int id)
        {
            var comment = context.Comment.Find(id);

            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // GET: /Comments/create
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /comment/create
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public ActionResult Create(Comment comment)
        {
            if (ModelState.IsValid)
            {
                context.Comment.Add(comment);

                context.SaveChanges();

                return RedirectToAction("Index", "Comments");
            }
    
            return View(comment);
        }

        // GET: /Comments/edit/{id}
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public ActionResult Edit(int id)
        {
            var comment = context.Comment.Find(id);

            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // POST: /Comments/edit
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public ActionResult Edit(Comment comment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var oldcomment = context.Comment.Find(comment.Id);

                    if (oldcomment == null)
                    {
                        return NotFound();
                    }


                    oldcomment.Id = comment.Id;
                    oldcomment.Content = comment.Content;
                    oldcomment.Timestamp = comment.Timestamp;

                    TryUpdateModelAsync(oldcomment);
                    

                    context.SaveChanges();

                    return RedirectToAction("Index", "Comments");
                }
            }
            catch (Exception e)
            {
                return Json(new { error_message = e.Message }, JsonRequestBehavior.AllowGet);
            }

            return View(comment);
        }

        // GET: /Comments/delete/{id}
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public ActionResult Delete(int id)
        {
            var comment = context.Comment.Find(id);

            if (comment == null)
            {
                return NotFound();
            }

            context.Comment.Remove(comment);

            context.SaveChanges();

            return RedirectToAction("Index", "Comments");
        }
    }
}