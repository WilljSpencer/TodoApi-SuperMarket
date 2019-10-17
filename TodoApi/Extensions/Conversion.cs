using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoApi.Domain.Models;
using TodoApi.Entities;

namespace TodoApi.Extensions
{
    public static class Conversion
    {
        public static DTOs.Category ToDto(this Entities.CategoryEntity category)
        {
            return new DTOs.Category()
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public static Entities.CategoryEntity ToEntity(this Category category)
        {
            return new CategoryEntity()
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public static DTOs.Category ObjToDto(this Category category)
        {
            return ToDto(ToEntity(category));
        }
    }

}
