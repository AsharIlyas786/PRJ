using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRJ.Service.Products;
using System.Threading.Tasks;

namespace PRJ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class HomeController : ControllerBase
    {
        private readonly IProductService _Products;
        public HomeController(IProductService Products)
        {
            _Products = Products;
        }
        [HttpGet]
        [Route("GetProducts")]
        public  IActionResult GetProducts()
        {
            return Ok( _Products.GetProducts());
        }
        [HttpGet]
        [Route("GetExpensiveAndCheapestBeer")]
        public  IActionResult GetExpensiveAndCheapestBeer()
        {
            return Ok( _Products.GetExpensiveAndCheapestBeer());
        }
        [HttpGet]
        [Route("GetBeerByCost")]
        public  IActionResult GetBeerByCost()
        {
            return Ok( _Products.GetBeerByCost(17.99));
        }
        [HttpGet]
        [Route("GetSortedProducts")]
        public  IActionResult GetSortedProducts()
        {
            return Ok( _Products.GetSortedProducts());
        }
        [HttpGet]
        [Route("GetProductinBottles")]
        public  IActionResult GetProductinBottles()
        {
            return Ok( _Products.GetProductinBottles());
        }
        [HttpGet]
        [Route("GetAllRoutes")]
        public IActionResult GetAllRoutes()
        {
            return Ok(_Products.GetAllRoutes());
        }


    }
}
