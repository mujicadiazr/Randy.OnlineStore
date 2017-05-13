using Randy.OnlineStore.Domain.Entities;
using Randy.OnlineStore.Infrastructure.Repository;
using Randy.OnlineStore.ServiceInterfaces;
using Randy.OnlineStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Randy.OnlineStore.WebAPI
{
    public class WebAPISecurity : IDisposable
    {
        private IServiceGeneric<User> _service;

        public WebAPISecurity()
        {
            _service = new ServiceGeneric<User>(new Repository<User>());
        }

        public void Dispose()
        {
            _service.Dispose();
        }

        public bool Login(string username, string password)
        {
            return _service.All().Any(user => user.Userame.Equals(username, StringComparison.OrdinalIgnoreCase) && user.Password == password);
        }
    }
}