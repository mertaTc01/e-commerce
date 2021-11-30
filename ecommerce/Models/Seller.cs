using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Models
{
    public class Seller
    {
        public string SellerName { get; set; }       
       
        [Key]
        public int SellerId { get; set; }
        
        public string SellerImgUrl { get; set; }    
        
        //relations
        public List<Product> Products { get; set; }
       
    }
}
