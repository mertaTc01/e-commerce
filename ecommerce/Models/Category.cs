using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Models
{
    public class Category
    {
        public string CategoryName { get; set; }
        
        [Key]
        public int CategoryId { get; set; }
       
       //relations

        public List<Product> Products { get; set; } 
    }
}
