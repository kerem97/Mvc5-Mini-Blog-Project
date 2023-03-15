using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProject.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager();
        [AllowAnonymous]
        public ActionResult Index()
        {

            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult SendMessage()
        {

            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult SendMessage(Contact c)
        {
            cm.BLContactAdd(c);
            return View();
        }
        public ActionResult Inbox()
        {
            var values = cm.GetAll();
            return View(values);
        }
        public ActionResult MessageDetails(int id)
        {
            Contact contact = cm.GetContactDetails(id);
            return View(contact);
        }
      
    
    }
}