using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PRJ.Service.Products.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace PRJ.Service.Products
{
    public class ProductService : IProductService
    {
        public string EndPoint = "https://flapotest.blob.core.windows.net/";
        public static List<ProductOutputDTO> ProductList { get; set; }
        public static List<Article> Articles { get; set; }
        public  List<ProductOutputDTO> GetBeerByCost(double Cost)
        {
            var articles=ProductList.SelectMany(x=>x.articles.Where(y=>y.price.Equals(Cost))).ToList();
            var products= from article in articles
                          join product in ProductList
                          on article.id equals product.articles.First().id
                          select product;

            return products.ToList();
        }

        public  List<ProductOutputDTO> GetExpensiveAndCheapestBeer()
        {
            List<ProductOutputDTO> products=new List<ProductOutputDTO>();
            Articles=ProductList.SelectMany(x=>x.articles).ToList();

            foreach (var article in Articles)
                article.pricePerUnit = article.pricePerUnitText.Replace(',', '.');

           Articles=Articles.OrderByDescending(x=>x.pricePerUnit).ToList();

            foreach(var pro in ProductList)
            {
                var isExpensive=pro.articles.Where(x => x.id == Articles.FirstOrDefault().id || x.id == Articles.LastOrDefault().id).ToList();
                if (isExpensive.Count()>0)
                    products.Add(pro);
            }

            return products;

        }

        public  List<ProductOutputDTO> GetProductinBottles()
        {
            var products = from product in ProductList where product.articles.Any(x => EF.Functions.Like(x.shortDescription.ToUpper(), "%GLAS%")) select product;
            return products.ToList();
        }

        public  List<ProductOutputDTO> GetProducts()
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.BaseAddress = EndPoint;
                var json = webClient.DownloadString("test/ProductData.json");
                var list = JsonConvert.DeserializeObject<List<ProductOutputDTO>>(json);
                ProductList = list.ToList();
               
                return ProductList;
            }
        }
        public  List<ProductOutputDTO> GetSortedProducts()
        {
            var products = from product in ProductList orderby product.articles.Max(x=>x.pricePerUnit) ascending select product;
            return products.ToList();
        }

        public ProductDTO GetAllRoutes()
        {
            ProductDTO productDTO = new ProductDTO();
            productDTO.GetProducts = GetProducts();
            productDTO.GetExpensiveAndCheapestBeer = GetExpensiveAndCheapestBeer();
            productDTO.GetBeerByCost = GetBeerByCost(17.99);
            productDTO.GetSortedProducts = GetSortedProducts();
            productDTO.GetProductinBottles= GetProductinBottles();
            return productDTO;
            
        }
    }
}
