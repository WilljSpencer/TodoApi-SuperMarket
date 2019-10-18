using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TodoApi.Domain.Models;
using TodoApi.Domain.Services;
using TodoApi.Persistence.Contexts;
using Xunit;

namespace TodoApi.UnitTest
{
    public class ControllerTest
    {
        private readonly AppDbContext context;

        private readonly CategoryService service;

        private readonly IMapper mapper;

        [Fact]
        public void Test1()
        {
            var services = new ServiceCollection();
            this.service = services
                .AddEntityFrameworkInMemoryDatabase()
                .AddDbContext<Category>(
                    (service, options) =>
                    {
                        options.UseInMemoryDatabase(Guid.NewGuid().ToString()).EnableSensitiveDataLogging()
                            .UseInternalServiceProvider(service);
                    })
                .AddAutoMapper(typeof(Startup))
                .BuildServiceProvider();

            this.service = services.BuildServiceProvider();
            this.mapper = this.service.GetService<IMapper>();
            this.context = this.service.GetService<EmployeeDataContext>();

            this.context.AddRange(DataGenerator.GetEmployee(100));
            this.context.SaveChanges();
        }
    }
}
