using System;
using System.Collections.Generic;
using System.Text;

namespace PRJ.Service.Products.DTOs
{
    public class ProductOutputDTO
    {
        public int Id { get; set; }
        public string brandName { get; set; }
        public string name { get; set; }
        public List<Article> articles { get; set; }
    }
}
