using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AuthorManager
    {
        Repository<Author> repoauthor = new Repository<Author>();
        public List<Author> GetAll()
        {
            return repoauthor.List();
        }
        public int AddAuthorBL(Author p)
        {
            if (p.AuthorName == "" | p.AuthorAboutShort == "" | p.AuthorTitle == "")
            {
                return -1;
            }
            return repoauthor.Insert(p);
        }
        public Author FindAuthor(int id)
        {
            return repoauthor.Find(x => x.AuthorID == id);
        }

        public int UpdateAuthor(Author p)
        {
            Author author = repoauthor.Find(x => x.AuthorID == p.AuthorID);
            author.AuthorName = p.AuthorName;
            author.AuthorMail = p.AuthorMail;
            author.AuthorImage = p.AuthorImage;
            author.AuthorPhoneNumber = p.AuthorPhoneNumber;
            author.AuthorAbout = p.AuthorAbout;
            author.AuthorAboutShort = p.AuthorAboutShort;
            author.AuthorTitle = p.AuthorTitle;
            author.AuthorPassword = p.AuthorPassword;
            return repoauthor.Update(author);
        }

    }
}
