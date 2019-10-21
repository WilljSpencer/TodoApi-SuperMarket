using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Domain.Models;

namespace TodoApi.Persistence.Repositories
{
    public class DataGenerator
    {
        public static List<Category> GetCategories(int count)
        {
            var categories = new List<Category>();

            for (var i = 1; i <= count; i++)
            {
                categories.Add(new Category()
                {
                    Id = i,
                    Name = $"First_{i}"
                });
            }

            return categories;
        }
    }
}
