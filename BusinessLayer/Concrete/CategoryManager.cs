using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        Repository<Category> repocategory = new Repository<Category>();

        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            return repocategory.List();
        }
        public int CategoryAddBl(Category p)
        {
            if (p.CategoryName == "" | p.CategoryDescription == "" | p.CategoryName.Length <= 4 | p.CategoryName.Length >= 20)
            {
                return -1;
            }
            return repocategory.Insert(p);
        }
        public Category FindCategory(int id)
        {
            return repocategory.Find(x => x.CategoryID == id);
        }
        public int EditCategory(Category p)
        {
            Category category = repocategory.Find(x => x.CategoryID == p.CategoryID);
            if (p.CategoryName == "" | p.CategoryName.Length <= 4 | p.CategoryName.Length >= 30)
            {
                return -1;
            }
            category.CategoryName = p.CategoryName;
            category.CategoryDescription = p.CategoryDescription;
            return repocategory.Update(category);
        }
        public int CategoryStatusChangeToFalse(int id)
        {
            Category category = repocategory.Find(x => x.CategoryID == id);
            category.CategoryStatus = false;
            return repocategory.Update(category);

        }
        public int CategoryStatusChangeToTrue(int id)
        {
            Category category = repocategory.Find(x => x.CategoryID == id);
            category.CategoryStatus = true;
            return repocategory.Update(category);
        }

        public List<Category> GetList()
        {
            return _categoryDal.List();
        }

        public void CategoryAdd(Category category)
        {
            _categoryDal.Insert(category);
        }

        public Category GetByID(int id)
        {
            return _categoryDal.GetByID(id);
        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
