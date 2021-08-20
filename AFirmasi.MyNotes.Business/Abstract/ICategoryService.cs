using AFirmasi.MyNotes.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AFirmasi.MyNotes.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        List<Category> GetEx(Expression<Func<Category, bool>> predicate);
        Category GetById(int id);
        void Add(Category entity);
        void Update(Category entity);
        void Delete(Category entity);
    
    }
}
