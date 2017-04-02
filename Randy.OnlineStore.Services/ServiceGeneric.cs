using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Randy.OnlineStore.Domain.Entities;
using Randy.OnlineStore.Domain.Interfaces;
using Randy.OnlineStore.ServiceInterfaces;

namespace Randy.OnlineStore.Services
{
    public class ServiceGeneric<T> : IServiceGeneric<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public ServiceGeneric(IRepository<T> repository)
        {
            _repository = repository;
        }

        public void Add(T entity)
        {
            _repository.Add(entity);
            _repository.Save();
        }

        public IEnumerable<T> All()
        {
            return _repository.All();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Modify(T entity)
        {
            _repository.Modify(entity);
            _repository.Save();
        }

        public void Remove(T entity)
        {
            _repository.Remove(entity);
            _repository.Save();
        }
    }
}
