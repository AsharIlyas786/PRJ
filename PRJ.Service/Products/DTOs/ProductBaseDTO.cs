using System;
using System.Collections.Generic;
using System.Text;

namespace PRJ.Service.Products.DTOs
{
    public class ProductDTO
    {
        public List<ProductOutputDTO> GetProducts { get; set; }
        public List<ProductOutputDTO> GetExpensiveAndCheapestBeer { get; set; }
        public List<ProductOutputDTO> GetBeerByCost { get; set; }
        public List<ProductOutputDTO> GetSortedProducts { get; set; }
        public List<ProductOutputDTO> GetProductinBottles { get; set; }
    }
}
