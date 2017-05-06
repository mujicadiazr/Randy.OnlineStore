using Randy.OnlineStore.Domain.Entities;
using Randy.OnlineStore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Randy.OnlineStore.WebAPI.Controllers
{
    public class CategoriesController : ApiController
    {
        IServiceGeneric<Category> _service;
        public CategoriesController(IServiceGeneric<Category> service)
        {
            _service = service;
        }

        public HttpResponseMessage Get(string contain="All")
        {
            switch (contain.ToLower())
            {
                case "all":
                    return Request.CreateResponse(HttpStatusCode.OK, _service.All());                    
                default:
                    var items = _service.All().Where(c => c.Description.Contains(contain.ToLower()));
                    if (items == null)
                    {
                        Request.CreateErrorResponse(HttpStatusCode.NotFound, "Category's decription contain " + contain + " not found");
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, items);
            }            
        }

        public HttpResponseMessage Get(int id)
        {
            var entity = _service.GetById(id);
            if (entity != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Category with ID " + id.ToString() + " not found");

        }

        public HttpResponseMessage Post([FromBody]Category entity)
        {
            try
            {
                _service.Add(entity);
                var message = Request.CreateResponse(HttpStatusCode.Created, entity);
                message.Headers.Location = new Uri(Request.RequestUri + entity.CategoryID.ToString());
                return message;
            } catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }            
        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var entity = _service.GetById(id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Category with ID " + id.ToString() + " not found");
                }
                else
                {
                    _service.Remove(entity);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            } catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }           
            
        }

        public HttpResponseMessage Put(int id,[FromBody]Category entity)
        {
            try
            {
                var entityOld = _service.GetById(id);
                if (entityOld == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Category with ID " + id.ToString() + " not found");
                }
                else
                {
                    //Second approach - WORK !!
                    entityOld.CategoryName = entity.CategoryName;
                    entityOld.Description = entity.Description;
                    entityOld.Picture = entity.Picture;
                    entityOld.Products = entity.Products;

                    _service.Save();

                    //First approach - Didn't work
                    //_service.Modify(entity);
                    return Request.CreateResponse(HttpStatusCode.OK, entityOld);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
