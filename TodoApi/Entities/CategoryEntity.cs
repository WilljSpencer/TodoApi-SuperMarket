using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Domain.Models;

namespace TodoApi.Entities
{
    public class CategoryEntity
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual IList<Product> Products { get; set; } = new List<Product>();
    }
}
