using Microsoft.Practices.Unity;
using Randy.OnlineStore.Domain.Entities;
using Randy.OnlineStore.Domain.Interfaces;
using Randy.OnlineStore.Infrastructure.Repository;
using Randy.OnlineStore.ServiceInterfaces;
using Randy.OnlineStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Randy.OnlineStore.Site.App_Start
{
    public static class IocConfig
    {
        public static void InitializeUnityContainer()
        {
            IUnityContainer container = new UnityContainer();

            RegisterUnityServices(container);

            DependencyResolver.SetResolver(new MyDependencyResolver(container));
        }

        private static void RegisterUnityServices(IUnityContainer container)
        {
                        
            //Resolving Services 
            container.RegisterType<IServiceGeneric<Category>, ServiceGeneric<Category>>();
            container.RegisterType<IServiceGeneric<Customer>, ServiceGeneric<Customer>>();
            container.RegisterType<IServiceGeneric<CustomerDemographic>, ServiceGeneric<CustomerDemographic>>();
            container.RegisterType<IServiceGeneric<Employee>, ServiceGeneric<Employee>>();
            container.RegisterType<IServiceGeneric<Order>, ServiceGeneric<Order>>();
            container.RegisterType<IServiceGeneric<Order_Detail>, ServiceGeneric<Order_Detail>>();
            container.RegisterType<IServiceGeneric<Product>, ServiceGeneric<Product>>();
            container.RegisterType<IServiceGeneric<Region>, ServiceGeneric<Region>>();
            container.RegisterType<IServiceGeneric<Shipper>, ServiceGeneric<Shipper>>();
            container.RegisterType<IServiceGeneric<Supplier>, ServiceGeneric<Supplier>>();
            container.RegisterType<IServiceGeneric<Territory>, ServiceGeneric<Territory>>();

            //Resolving Repositories 
            container.RegisterType<IRepository<Category>, Repository<Category>>();
            container.RegisterType<IRepository<Customer>, Repository<Customer>>();
            container.RegisterType<IRepository<CustomerDemographic>, Repository<CustomerDemographic>>();
            container.RegisterType<IRepository<Employee>, Repository<Employee>>();
            container.RegisterType<IRepository<Order>, Repository<Order>>();
            container.RegisterType<IRepository<Order_Detail>, Repository<Order_Detail>>();
            container.RegisterType<IRepository<Product>, Repository<Product>>();
            container.RegisterType<IRepository<Region>, Repository<Region>>();
            container.RegisterType<IRepository<Shipper>, Repository<Shipper>>();
            container.RegisterType<IRepository<Supplier>, Repository<Supplier>>();
            container.RegisterType<IRepository<Territory>, Repository<Territory>>();
        }
    }
}