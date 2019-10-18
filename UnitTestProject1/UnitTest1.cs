using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TodoApi.Controllers;
using TodoApi.Domain.Models;
using TodoApi.Domain.Repositories;
using TodoApi.Domain.Services;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private ICategoryService categoryService;

        [TestMethod]
        public void TestingPUT()
        {
            var controller = new CategoriesController(new CategoryService());

            // act
            var result = controller.GetAllAsyncTest();
            var okResult = result as OkObjectResult;

            // assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        private List<Category> GetTestCategory()
        {
            var testCategory = new List<Category>();
            testCategory.Add(new Category { Id = 1, Name = "Demo1"});
            testCategory.Add(new Category { Id = 2, Name = "Demo2"});
            testCategory.Add(new Category { Id = 3, Name = "Demo3"});
            testCategory.Add(new Category { Id = 4, Name = "Demo4"});

            return testCategory;
        }
    }
}
