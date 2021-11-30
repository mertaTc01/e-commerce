using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Models
{
    public class BuyerBasket
    {
        [Key]
        public string BuyerBasketId { get; set; }

        public int BuyerId { get; set; }

        public Buyer Buyer { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public List<Product> Products { get; set; }


       
    }
}
