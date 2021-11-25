using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Product
    {
        [DisplayName("SL No")]
        [Required]
        public int ID { get; set; }
        [DisplayName("Product Name")]
        [Required]
        public string ProductName { get; set; }
        [DisplayName("Product Price")]
        [Required]
        public string Price { get; set; }
    }
}