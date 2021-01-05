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
    public class UsersController : Controller
    {
        private BlogContext context = new BlogContext();

        // GET: /users/index
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public ActionResult Index()
        {
            ViewData["users"] = context.User.ToList();

            return View();
        }

        // GET: /users/details/{id}
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public ActionResult Details(int id)
        {
            var user = context.User.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: /users/create
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /user/create
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                context.User.Add(user);

                context.SaveChanges();

                return RedirectToAction("Index", "users");
            }
    
            return View(user);
        }

        // GET: /users/edit/{id}
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public ActionResult Edit(int id)
        {
            var user = context.User.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: /users/edit
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public ActionResult Edit(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var olduser = context.User.Find(user.Id);

                    if (olduser == null)
                    {
                        return NotFound();
                    }

                    olduser.FirstName = user.FirstName;
                    olduser.LastName = user.LastName;
                    olduser.Email = user.Email;

                    TryUpdateModelAsync(olduser);

                    context.SaveChanges();

                    return RedirectToAction("Index", "users");
                }
            }
            catch (Exception e)
            {
                return Json(new { error_message = e.Message }, JsonRequestBehavior.AllowGet);
            }

            return View(user);
        }

        // GET: /users/delete/{id}
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public ActionResult Delete(int id)
        {
            var user = context.User.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            context.User.Remove(user);

            context.SaveChanges();

            return RedirectToAction("Index", "users");
        }
    }
}