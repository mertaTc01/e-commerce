using ecommerce.Data;
using ecommerce.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Models
{
    public class Product
    {
        public string ProductName { get; set; }
        
        [Key]
        public int ProductId { get; set; }
        
        public string ProductImgUrl { get; set; }
        public string ProductColor { get; set; }
        public string ProductSize { get; set; }
        public string ProductDetail { get; set; }
        public string ProductPrice { get; set; }

        public ProductCategory ProductCategory { get; set; }

        //RELATÝON
        public List<BuyerBasket> BuyerBaskets { get; set; }

        //category
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        
        //Seller
        public int SellerId { get; set; }
        [ForeignKey("SellerId")]
        public Seller Seller { get; set; }



    }
}
