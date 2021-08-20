using AFirmasi.MyNotes.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AFirmasi.MyNotes.Business.Abstract
{
    public interface INoteService
    {
        List<Note> GetAll();
        List<Note> GetEx(Expression<Func<Note, bool>> predicate);
        Note GetById(int id);
        void Add(Note entity);
        void Update(Note entity);
        void Delete(Note entity);  

    }
}
