using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Randy.OnlineStore.Domain.Interfaces;
using Randy.OnlineStore.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Randy.OnlineStore.Domain.Entities;
using Randy.OnlineStore.ServiceInterfaces;
using Randy.OnlineStore.Services;

namespace Randy.OnlineStore.Test
{
    [TestClass]
    public class UnitTest1
    {
        private IServiceGeneric<Category> _service;

        [TestInitialize]
        public void Initialize()
        {
            _service = new ServiceGeneric<Category>(new Repository<Category>());
        }

        [TestMethod]
        public void CategoryRepositoryDontReturnNull()
        {
            var data = _service.All();
            Assert.AreNotEqual(null, data);
        }

        [TestMethod]
        public void CategoryRepositoryReturnListOfCategory()
        {
            var data = _service.All().ToList();

            if (data is IEnumerable<Category>)
            {
                var dataNew = data as List<Category>;
                foreach(var item in dataNew)
                {
                    System.Console.WriteLine("ID: {0} Name: {1} ", item.CategoryID, item.CategoryName);
                }

                Assert.AreEqual(8, dataNew.Count);
            }

           
        }

    }
}
