using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProject.Controllers
{
    public class CategoryController : Controller
    {

        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            var values = cm.GetAll();
            return View(values);
        }
        [AllowAnonymous]
        public PartialViewResult BlogDetailsCategoryList()
        {
            var values = cm.GetAll();
            return PartialView(values);
        }
        public ActionResult AdminCategoryList()
        {
            var categorylist = cm.GetAll();
            return View(categorylist);
        }
        [HttpGet]
        public ActionResult AdminCategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminCategoryAdd(Category p)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult validationResult = categoryValidator.Validate(p);
            if (validationResult.IsValid)
            {
                cm.CategoryAddBl(p);
                return RedirectToAction("AdminCategoryList");
            }
            else
            {
                foreach (var x in validationResult.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
            }
            return View();


        }
        [HttpGet]
        public ActionResult CategoryUpdate(int id)
        {
            Category category = cm.FindCategory(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult CategoryUpdate(Category p)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult validationResult = categoryValidator.Validate(p);
            if (validationResult.IsValid)
            {
                cm.EditCategory(p);
                return RedirectToAction("AdminCategoryList");
            }
            else
            {
                foreach (var x in validationResult.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
            }
            return View();
           
        }
        public ActionResult CategoryDelete(int id)
        {
            cm.CategoryStatusChangeToFalse(id);
            return RedirectToAction("AdminCategoryList");
        }
        public ActionResult CategoryStatusTrue(int id)
        {
            cm.CategoryStatusChangeToTrue(id);
            return RedirectToAction("AdminCategoryList");
        }
    }
}