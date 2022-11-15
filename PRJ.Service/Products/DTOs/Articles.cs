using System;
using System.Collections.Generic;
using System.Text;

namespace PRJ.Service.Products.DTOs
{
    public class Article
    {
        public int id { get; set; }
        public string shortDescription { get; set; }
        public double price { get; set; }
        public string unit { get; set; }
        public string pricePerUnitText { get; set; }
        public string pricePerUnit { get; set; } 
        public string image { get; set; }
    }
}
