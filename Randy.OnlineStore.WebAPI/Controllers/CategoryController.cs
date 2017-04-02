using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Randy.OnlineStore.Domain.Entities;
using Randy.OnlineStore.Infrastructure.DataModel;
using Randy.OnlineStore.ServiceInterfaces;

namespace Randy.OnlineStore.WebAPI.Controllers
{
    public class CategoryController : ApiController
    {
        private IServiceGeneric<Category> _service;

        CategoryController(IServiceGeneric<Category> service)
        {
            _service = service;
        }

        // GET: api/Category
        public IQueryable<Category> GetCategories()
        {
            return _service.All().AsQueryable();
        }

        // GET: api/Category/5
        [ResponseType(typeof(Category))]
        public IHttpActionResult GetCategory(int id)
        {
            Category category = _service.GetById(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // PUT: api/Category/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategory(int id, Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category.CategoryID)
            {
                return BadRequest();
            }

            try
            {
                _service.Modify(category);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Category
        [ResponseType(typeof(Category))]
        public IHttpActionResult PostCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _service.Add(category);

            return CreatedAtRoute("DefaultApi", new { id = category.CategoryID }, category);
        }

        // DELETE: api/Category/5
        [ResponseType(typeof(Category))]
        public IHttpActionResult DeleteCategory(int id)
        {
            Category category = _service.GetById(id);
            if (category == null)
            {
                return NotFound();
            }

            _service.Remove(category);

            return Ok(category);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        private bool CategoryExists(int id)
        {
            return _service.All().Count(e => e.CategoryID == id) > 0;
        }
    }
}