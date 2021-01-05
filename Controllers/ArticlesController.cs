using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using System.Web.Mvc;
//using System.Web.Mvc;
using Microsoft.EntityFrameworkCore;
using RomanianFinancialTimes.Data;
using RomanianFinancialTimes.Models;
using ActionResult = Microsoft.AspNetCore.Mvc.ActionResult;
using Controller = Microsoft.AspNetCore.Mvc.Controller;

namespace RomanianFinancialTimes.Controllers
{
    public class ArticlesController : Controller
    {
        private BlogContext context = new BlogContext();

        // GET: /Articles/index
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public ActionResult Index()
        {
            ViewData["Articles"] = context.Article.ToList();

            return View();
        }

        // GET: /Articles/details/{id}
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public ActionResult Details(int id)
        {
            var article = context.Article.Find(id);

            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // GET: /Articles/create
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Article/create
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public ActionResult Create(Article article)
        {
            if (ModelState.IsValid)
            {
                context.Article.Add(article);

                context.SaveChanges();

                return RedirectToAction("Index", "Articles");
            }
    
            return View(article);
        }

        // GET: /Articles/edit/{id}
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public ActionResult Edit(int id)
        {
            var article = context.Article.Find(id);

            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: /Articles/edit
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public ActionResult Edit(Article article)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var oldArticle = context.Article.Find(article.Id);

                    if (oldArticle == null)
                    {
                        return NotFound();
                    }

                 
                    oldArticle.Id = article.Id;
                    oldArticle.Title = article.Title;
                    oldArticle.Content = article.Content;
                    oldArticle.Timestamp = article.Timestamp;
                    oldArticle.WriterId = article.WriterId;
                    
                    TryUpdateModelAsync(oldArticle);

                    context.SaveChanges();

                    return RedirectToAction("Index", "Articles");
                }
            }
            catch (Exception e)
            {
                return Json(new { error_message = e.Message }, JsonRequestBehavior.AllowGet);
            }

            return View(article);
        }

        // GET: /Articles/delete/{id}
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public ActionResult Delete(int id)
        {
            var article = context.Article.Find(id);

            if (article == null)
            {
                return NotFound();
            }

            context.Article.Remove(article);

            context.SaveChanges();

            return RedirectToAction("Index", "Articles");
        }
    }
}