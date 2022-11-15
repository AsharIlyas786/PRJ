using NUnit.Framework;
using PRJ.API.Controllers;
using PRJ.Service.Products;

namespace TestProject
{
    [TestFixture]
    public class Tests
    {
        private ProductService _products;
        private HomeController _homeController;
        [SetUp]
        public void Setup()
        {
            _products=new ProductService();
            _homeController = new HomeController(_products);
        }

        [Test]
        public void Test1()
        {
            var result = _homeController.GetProducts();
            Assert.Pass("Passed", result);
        }
    }
}