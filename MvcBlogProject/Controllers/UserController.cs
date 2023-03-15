﻿using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcBlogProject.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        UserProfileManager userProfile = new UserProfileManager();
        BlogManager bm = new BlogManager();
        public ActionResult Index()
        {

            return View();
        }
        public PartialViewResult Partial1(string p)
        {
            p = (string)Session["AuthorMail"];
            var values = userProfile.GetAuthorByMail(p);
            return PartialView(values);
        }
        public ActionResult UpdateUserProfile(Author p)
        {
            userProfile.UpdateAuthor(p);
            return RedirectToAction("Index");
        }
        public ActionResult BlogList(string p)
        {

            p = (string)Session["AuthorMail"];
            Context c = new Context();
            int id = c.Authors.Where(x => x.AuthorMail == p).Select(y => y.AuthorID).FirstOrDefault();
            var blogs = userProfile.GetBlogByAuthor(id);
            return View(blogs);
        }

        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            Context c = new Context();
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.values = values;

            List<SelectListItem> values2 = (from x in c.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.AuthorName,
                                                Value = x.AuthorID.ToString()
                                            }).ToList();
            ViewBag.values2 = values2;
            Blog blog = bm.FindBlog(id);
            return View(blog);
        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog p)
        {
            bm.UpdateBlog(p);
            return RedirectToAction("BlogList");
        }

        [HttpGet]
        public ActionResult AddNewBlog()
        {
            Context c = new Context();
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.values = values;

            List<SelectListItem> values2 = (from x in c.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.AuthorName,
                                                Value = x.AuthorID.ToString()
                                            }).ToList();
            ViewBag.values2 = values2;
            return View();
        }
        [HttpPost]
        public ActionResult AddNewBlog(Blog blog)
        {
            bm.BlogAddBL(blog);
            return RedirectToAction("BlogList");
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("UserLogin", "Login");
        }


    }
}