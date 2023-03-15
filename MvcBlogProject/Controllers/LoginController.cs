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
    [AllowAnonymous]
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserLogin(Author p)
        {
            Context c = new Context();
            var values = c.Authors.FirstOrDefault(x => x.AuthorMail == p.AuthorMail && x.AuthorPassword == p.AuthorPassword);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.AuthorMail, false);
                Session["AuthorMail"] = values.AuthorMail.ToString();
                return RedirectToAction("Index", "User");
            }
            else
            {
                return RedirectToAction("UserLogin", "Login");
            }

        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            Context c = new Context();
            var values = c.Admins.FirstOrDefault(x => x.Username == p.Username && x.Password == p.Password);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.Username, false);
                Session["Username"] = values.Username.ToString();
                return RedirectToAction("AdminBlogList", "Blog");
            }
            else
            {
                return RedirectToAction("AdminLogin", "Login");
            }

        }
   
    }
}