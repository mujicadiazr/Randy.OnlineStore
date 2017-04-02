using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace Randy.OnlineStore.Site.App_Start
{
    internal class MyDependencyResolver : IDependencyResolver
    {
        private IUnityContainer _container;

        public MyDependencyResolver(IUnityContainer container)
        {
            _container = container;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _container.Resolve(serviceType);
            }catch(Exception e)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _container.ResolveAll(serviceType);
            }
            catch (Exception e)
            {
                return new List<object>();
            }
        }
    }
}