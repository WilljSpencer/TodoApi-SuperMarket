using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Entities;

namespace TodoApi.DTOs
{
    public class Category : CategoryEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
