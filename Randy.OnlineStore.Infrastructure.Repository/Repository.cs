using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Randy.OnlineStore.Domain.Interfaces;
using System.Data.Entity;
using System.Linq.Expressions;
using Randy.OnlineStore.Infrastructure.DataModel;

namespace Randy.OnlineStore.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context = new OnlineStoreEntities();

        public void Add(T entity)
        {
            if (_context.Entry<T>(entity).State != System.Data.Entity.EntityState.Detached)
                _context.Entry<T>(entity).State = System.Data.Entity.EntityState.Added;
            else
                _context.Set<T>().Add(entity);
        }

        public IEnumerable<T> All()
        {
            return _context.Set<T>();
        }

        public IQueryable<T> AsQueryable()
        {
            return _context.Set<T>().AsQueryable();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).FirstOrDefault();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Modify(T entity)
        {
            if (_context.Entry<T>(entity).State == System.Data.Entity.EntityState.Detached)
                _context.Set<T>().Attach(entity);
            _context.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public void Remove(T entity)
        {
            if (_context.Entry<T>(entity).State == System.Data.Entity.EntityState.Detached)
                _context.Set<T>().Attach(entity);
            _context.Entry<T>(entity).State = System.Data.Entity.EntityState.Deleted;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
