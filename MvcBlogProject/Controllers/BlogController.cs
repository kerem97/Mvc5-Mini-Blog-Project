using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProject.Controllers
{
    
    public class BlogController : Controller
    {
        // GET: Blog
        BlogManager bm = new BlogManager();
        UserProfileManager userProfile = new UserProfileManager();

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult BlogList(int page = 1)
        {
            var value = bm.GetAll().ToPagedList(page, 6);
            return PartialView(value);
        }
        [AllowAnonymous]
        public PartialViewResult FeaturedBlogs()
        {
            //1.Post
            var postTitle1 = bm.GetAll().OrderByDescending(z => z.BlogID).
                Where(x => x.CategoryID == 1).
                Select(y => y.BlogTitle).
                FirstOrDefault();
            var postImage1 = bm.GetAll().OrderByDescending(z => z.BlogID).
                Where(x => x.CategoryID == 1).
                Select(y => y.BlogImage).
                FirstOrDefault();
            var blogDate1 = bm.GetAll().OrderByDescending(z => z.BlogID).
                Where(x => x.CategoryID == 1).
                Select(y => y.BlogDate).
                FirstOrDefault();
            var blogpostid1 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogID).FirstOrDefault();
            ViewBag.postTitle1 = postTitle1;
            ViewBag.postImage1 = postImage1;
            ViewBag.blogDate1 = blogDate1;
            ViewBag.blogpostid1 = blogpostid1;




            //2.Post
            var postTitle2 = bm.GetAll().OrderByDescending(z => z.BlogID).
                Where(x => x.CategoryID == 2).
                Select(y => y.BlogTitle).
                FirstOrDefault();
            var postImage2 = bm.GetAll().OrderByDescending(z => z.BlogID).
                Where(x => x.CategoryID == 2).
                Select(y => y.BlogImage).
                FirstOrDefault();
            var blogDate2 = bm.GetAll().OrderByDescending(z => z.BlogID).
                Where(x => x.CategoryID == 2).
                Select(y => y.BlogDate).
                FirstOrDefault();
            var blogpostid2 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(y => y.BlogID).FirstOrDefault();
            ViewBag.blogpostid2 = blogpostid2;
            ViewBag.postTitle2 = postTitle2;
            ViewBag.postImage2 = postImage2;
            ViewBag.blogDate2 = blogDate2;

            //3.Post
            var postTitle3 = bm.GetAll().OrderByDescending(z => z.BlogID).
                Where(x => x.CategoryID == 3).
                Select(y => y.BlogTitle).
                FirstOrDefault();
            var postImage3 = bm.GetAll().OrderByDescending(z => z.BlogID).
                Where(x => x.CategoryID == 3).
                Select(y => y.BlogImage).
                FirstOrDefault();
            var blogDate3 = bm.GetAll().OrderByDescending(z => z.BlogID).
                Where(x => x.CategoryID == 3).
                Select(y => y.BlogDate).
                FirstOrDefault();
            var blogpostid3 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogID).FirstOrDefault();
            ViewBag.blogpostid3 = blogpostid3;
            ViewBag.postTitle3 = postTitle3;
            ViewBag.postImage3 = postImage3;
            ViewBag.blogDate3 = blogDate3;

            //4.Post
            var postTitle4 = bm.GetAll().OrderByDescending(z => z.BlogID).
                Where(x => x.CategoryID == 4).
                Select(y => y.BlogTitle).
                FirstOrDefault();
            var postImage4 = bm.GetAll().OrderByDescending(z => z.BlogID).
                Where(x => x.CategoryID == 4).
                Select(y => y.BlogImage).
                FirstOrDefault();
            var blogDate4 = bm.GetAll().OrderByDescending(z => z.BlogID).
                Where(x => x.CategoryID == 4).
                Select(y => y.BlogDate).
                FirstOrDefault();
            var blogpostid4 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogID).FirstOrDefault();
            ViewBag.blogpostid4 = blogpostid4;
            ViewBag.postTitle4 = postTitle4;
            ViewBag.postImage4 = postImage4;
            ViewBag.blogDate4 = blogDate4;

            //5.Post
            var postTitle5 = bm.GetAll().OrderByDescending(z => z.BlogID).
                Where(x => x.CategoryID == 5).
                Select(y => y.BlogTitle).
                FirstOrDefault();
            var postImage5 = bm.GetAll().OrderByDescending(z => z.BlogID).
                Where(x => x.CategoryID == 5).
                Select(y => y.BlogImage).
                FirstOrDefault();
            var blogDate5 = bm.GetAll().OrderByDescending(z => z.BlogID).
                Where(x => x.CategoryID == 5).
                Select(y => y.BlogDate).
                FirstOrDefault();
            var blogpostid5 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 5).Select(y => y.BlogID).FirstOrDefault();
            ViewBag.blogpostid5 = blogpostid5;
            ViewBag.postTitle5 = postTitle5;
            ViewBag.postImage5 = postImage5;
            ViewBag.blogDate5 = blogDate5;

            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult OtherFeaturedBlogs()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public ActionResult BlogDetails()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult BlogCover(int id)
        {
            var values = bm.GetBlogByID(id);
            return PartialView(values);
        }
        [AllowAnonymous]
        public PartialViewResult BlogReadAll(int id)
        {
            var values = bm.GetBlogByID(id);
            return PartialView(values);
        }
        [AllowAnonymous]
        public ActionResult BlogByCategory(int id)
        {
            var BlogListByCategory = bm.GetBlogByCategory(id);
            var CategoryName = bm.GetBlogByCategory(id).Select(y => y.Category.CategoryName).FirstOrDefault();
            ViewBag.CategoryName = CategoryName;
            var CategoryDesc = bm.GetBlogByCategory(id).Select(y => y.Category.CategoryDescription).FirstOrDefault();
            ViewBag.CategoryDesc = CategoryDesc;
            return View(BlogListByCategory);
        }
        [Authorize]
        public ActionResult AdminBlogList()
        {
            var bloglist = bm.GetAll();
            return View(bloglist);
        }
        [Authorize]
        public ActionResult AdminBlogList2()
        {
            var bloglist = bm.GetAll();
            return View(bloglist);
        }
        [Authorize(Roles ="A")]
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
        [Authorize]
        public ActionResult AddNewBlog(Blog blog)
        {
            bm.BlogAddBL(blog);
            return RedirectToAction("AdminBlogList");
        }
        [Authorize]
        public ActionResult DeleteBlog(int id)
        {
            bm.DeleteBlog(id);
            return RedirectToAction("AdminBLogList");
        }
        [HttpGet]
        [Authorize]
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
        [Authorize]
        public ActionResult UpdateBlog(Blog p)
        {
            bm.UpdateBlog(p);
            return RedirectToAction("AdminBlogList");
        }
        [Authorize]
        public ActionResult GetCommentByBlog(int id)
        {
            CommentManager cm = new CommentManager();
            var commentlist = cm.CommentByBlog(id);
            return View(commentlist);
        }
        public ActionResult UserBlogList(int id)
        {

            
        
            var blogs = bm.GetBlogByAuthor(id);
            return View(blogs);
        }

    }
}