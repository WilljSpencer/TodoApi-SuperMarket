using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Domain.Models;

namespace TodoApi.Domain.Repositories
{
    interface ICategoryRepository
    {
        Task<IEnumerable<Category>> ListAsync();
    }
}
