using PRJ.Service.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PRJ.Service.Products
{
    public interface IProductService
    {
        public List<ProductOutputDTO> GetProducts();
        public List<ProductOutputDTO> GetExpensiveAndCheapestBeer();
        public List<ProductOutputDTO> GetBeerByCost(double Cost);
        public List<ProductOutputDTO> GetSortedProducts();
        public List<ProductOutputDTO> GetProductinBottles();
        public ProductDTO GetAllRoutes();
    }
}
