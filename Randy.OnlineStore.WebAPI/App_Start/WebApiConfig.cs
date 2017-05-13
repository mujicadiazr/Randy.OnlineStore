using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Microsoft.Practices.Unity;
using Randy.OnlineStore.WebAPI.App_Start;
using Randy.OnlineStore.ServiceInterfaces;
using Randy.OnlineStore.Domain.Entities;
using Randy.OnlineStore.Services;
using Randy.OnlineStore.Domain.Interfaces;
using Randy.OnlineStore.Infrastructure.Repository;
using WebApiContrib.Formatting.Jsonp;
using System.Web.Http.Cors;

namespace Randy.OnlineStore.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            #region Unity Container Configuration
            //Unity container stuff
            var container = new UnityContainer();
            //Registering all the stuff
            RegisterUnityServices(container);
            config.DependencyResolver = new MyDependencyResolver(container);
            #endregion

            #region Serializer Configuration
            //Setting up the JSON serializing format
            //and removing the XML serializer            

            //Remove a formatter
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            //Set JSON Formetter indented
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;

            //Set Camel Case style to properties 
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            #endregion

            #region Web API routes
            // Web API routes
            config.MapHttpAttributeRoutes();
 
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            #endregion

            #region Register HTTPS filter
            //config.Filters.Add(new RequireHttpsAttribute());
            #endregion

            #region  For enabling Cross-Origin Resource Sharing  
            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            //Jsonp for enabling CORS
            //var jsonpFormatter = new JsonpMediaTypeFormatter(config.Formatters.JsonFormatter);
            //config.Formatters.Insert(0, jsonpFormatter);
            #endregion

            #region Enable Basic Authentication
            //config.Filters.Add(new BasicAuthenticationAttribute());
            #endregion
        }

        private static void RegisterUnityServices(UnityContainer container)
        {
            //Resolving Services 
            container.RegisterType<IServiceGeneric<Category>, ServiceGeneric<Category>>(new HierarchicalLifetimeManager());
            container.RegisterType<IServiceGeneric<Customer>, ServiceGeneric<Customer>>(new HierarchicalLifetimeManager());
            container.RegisterType<IServiceGeneric<CustomerDemographic>, ServiceGeneric<CustomerDemographic>>(new HierarchicalLifetimeManager());
            container.RegisterType<IServiceGeneric<Employee>, ServiceGeneric<Employee>>(new HierarchicalLifetimeManager());
            container.RegisterType<IServiceGeneric<Order>, ServiceGeneric<Order>>(new HierarchicalLifetimeManager());
            container.RegisterType<IServiceGeneric<Order_Detail>, ServiceGeneric<Order_Detail>>(new HierarchicalLifetimeManager());
            container.RegisterType<IServiceGeneric<Product>, ServiceGeneric<Product>>(new HierarchicalLifetimeManager());
            container.RegisterType<IServiceGeneric<Region>, ServiceGeneric<Region>>(new HierarchicalLifetimeManager());
            container.RegisterType<IServiceGeneric<Shipper>, ServiceGeneric<Shipper>>(new HierarchicalLifetimeManager());
            container.RegisterType<IServiceGeneric<Supplier>, ServiceGeneric<Supplier>>(new HierarchicalLifetimeManager());
            container.RegisterType<IServiceGeneric<Territory>, ServiceGeneric<Territory>>(new HierarchicalLifetimeManager());
            container.RegisterType<IServiceGeneric<User>, ServiceGeneric<User>>(new HierarchicalLifetimeManager());


            //Resolving Repositories 
            container.RegisterType<IRepository<Category>, Repository<Category>>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepository<Customer>, Repository<Customer>>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepository<CustomerDemographic>, Repository<CustomerDemographic>>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepository<Employee>, Repository<Employee>>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepository<Order>, Repository<Order>>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepository<Order_Detail>, Repository<Order_Detail>>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepository<Product>, Repository<Product>>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepository<Region>, Repository<Region>>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepository<Shipper>, Repository<Shipper>>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepository<Supplier>, Repository<Supplier>>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepository<Territory>, Repository<Territory>>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepository<User>, Repository<User>>(new HierarchicalLifetimeManager());
        }
    }
}
