using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MVC_OnlineCourse.Models.MSSQL
{
    public class MSSQLRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public MSSQLRepository(CourseModel db)
        {
            if (db == null) return;
            _dbContext = db;
            _dbSet = db.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Edit(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public IQueryable<T> GetList()
        {
            return _dbSet;
        }

        public IQueryable<T> GetList(Expression<Func<T, bool>> e)
        {
            return _dbSet.Where(e);
        }

        public T SingleRecord(Expression<Func<T, bool>> e)
        {
            return _dbSet.Where(e).FirstOrDefault();
        }

        public T SingleRecord(object id)
        {
            return _dbSet.Find(id);
        }
    }
}