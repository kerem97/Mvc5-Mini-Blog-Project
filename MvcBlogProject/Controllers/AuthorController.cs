using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProject.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        BlogManager bm = new BlogManager();
        AuthorManager aum = new AuthorManager();
        [AllowAnonymous]
        public PartialViewResult AuthorAbout(int id)
        {
            var authordetail = bm.GetBlogByID(id);
            return PartialView(authordetail);
        }
        [AllowAnonymous]
        public PartialViewResult AuthorPopularPost(int id)
        {
            var value = bm.GetAll().Where(x => x.BlogID == id).
                Select(y => y.AuthorID).
                FirstOrDefault();         
            var authorblogs = bm.GetBlogByAuthor(value);
            return PartialView(authorblogs);
        }
      
        public ActionResult AuthorList()
        {
            var values = aum.GetAll();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAuthor(Author author)
        {
            aum.AddAuthorBL(author);
            return RedirectToAction("AuthorList");
        }
        [HttpGet]
        public ActionResult AuthorUpdate(int id)
        {
            Author author = aum.FindAuthor(id);
            return View(author);
        }
        [HttpPost]
        public ActionResult AuthorUpdate(Author p)
        {
            aum.UpdateAuthor(p);
            return RedirectToAction("AuthorList");
        }
    }
}