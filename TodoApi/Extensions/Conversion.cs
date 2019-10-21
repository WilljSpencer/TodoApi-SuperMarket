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
        public static DTOs.CategoryDTO ToDto(this Entities.CategoryEntity category)
        {
            return new DTOs.CategoryDTO()
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

        public static DTOs.CategoryDTO ObjToDto(this Category category)
        {
            return ToDto(ToEntity(category));
        }
    }

}
