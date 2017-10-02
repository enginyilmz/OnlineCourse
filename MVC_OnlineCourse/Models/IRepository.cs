using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVC_OnlineCourse.Models
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetList();
        IQueryable<T> GetList(Expression<Func<T, bool>> e);
        T SingleRecord(object id);
        T SingleRecord(Expression<Func<T, bool>> e);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void Save();
    }
}
