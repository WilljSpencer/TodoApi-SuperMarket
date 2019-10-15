using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TodoApi.Domain.Models;
using TodoApi.Resource;

namespace TodoApi.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            this.CreateMap<Category, CategoryResource>();
        }   
    }
}
