using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Randy.OnlineStore.Domain.Entities;

namespace Randy.OnlineStore.ServiceInterfaces
{
    public interface IServiceGeneric<T>
    {
        IEnumerable<T> All();
        T GetById(int id);

        void Add(T entity);
        void Modify(T entity);
        void Remove(T entity);
        void Dispose();
        void Save();
    }
}
