using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Models
{
    public class Buyer
    {
        [Key]
        public int BuyerId { get; set; }

        public string BuyerName { get; set; }
        public string BuyerImgUrl { get; set; }
        public string BuyerMail { get; set; }
        public string BuyerPassword { get; set; }

        //relations
        public List<BuyerBasket> BuyerBaskets { get; set; }


   
    }
}
