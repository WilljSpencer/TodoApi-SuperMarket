using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TodoApi.Controllers;
using TodoApi.Domain.Models;
using TodoApi.Domain.Repositories;
using TodoApi.Domain.Services;
using TodoApi.Persistence.Contexts;
using TodoApi.Persistence.Repositories;
using Moq;
using Xunit;

namespace TodoApi.UnitTest
{
    public class ControllerTest
    {
        private readonly AppDbContext context;

        private readonly ServiceProvider provider;

        private readonly IMapper mapper;

        private readonly ICategoryService service;

        private readonly IUnitOfWork unitOfWork;

        public ControllerTest()
        {
            var services = new ServiceCollection();
            this.provider = services
                .AddEntityFrameworkInMemoryDatabase()
                .AddDbContext<AppDbContext>(
                    (service, options) =>
                    {
                        options.UseInMemoryDatabase(Guid.NewGuid().ToString()).EnableSensitiveDataLogging()
                            .UseInternalServiceProvider(service);
                    })
                .AddAutoMapper(typeof(Startup))
                .BuildServiceProvider();

            provider = services.BuildServiceProvider();
            mapper = this.provider.GetService<IMapper>();
            context = this.provider.GetService<AppDbContext>();
            // GetService<ICategoryService>??!?!?!
            // What does GetService do


            context.AddRange(DataGenerator.GetCategories(100));
            context.SaveChanges();
        }

        [Fact]
        public async Task TestGetEmployees()
        {
            // ARRANGE
            var repo = new CategoryRepository(this.context);
            var service = new CategoryService(repo, unitOfWork);
            var controller = new CategoriesController(service, this.mapper);

            // ACT
            var result = await controller.GetAllAsyncTest();

            // ASSERT
            var viewResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<IActionResult>(viewResult);
            // Mock no worky
            var model = Assert.IsAssignableFrom<List<Category>>(viewResult.Value);
            Assert.NotEmpty(model);
        }
    }
}
