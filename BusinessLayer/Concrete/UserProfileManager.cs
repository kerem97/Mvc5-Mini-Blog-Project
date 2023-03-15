﻿using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserProfileManager
    {
        Repository<Author> repouser = new Repository<Author>();
        Repository<Blog> repouserblog = new Repository<Blog>();
        public List<Author> GetAuthorByMail(string p)
        {
            return repouser.List(x => x.AuthorMail == p);
        }
        public List<Blog> GetBlogByAuthor(int id)
        {
            return repouserblog.List(x => x.AuthorID == id);
        }
        public int UpdateAuthor(Author p)
        {
            Author author = repouser.Find(x => x.AuthorID == p.AuthorID);
            author.AuthorName = p.AuthorName;
            author.AuthorMail = p.AuthorMail;
            author.AuthorImage = p.AuthorImage;
            author.AuthorPhoneNumber = p.AuthorPhoneNumber;
            author.AuthorAbout = p.AuthorAbout;
            author.AuthorAboutShort = p.AuthorAboutShort;
            author.AuthorTitle = p.AuthorTitle;
            author.AuthorPassword = p.AuthorPassword;
            return repouser.Update(author);
        }
    }
}
