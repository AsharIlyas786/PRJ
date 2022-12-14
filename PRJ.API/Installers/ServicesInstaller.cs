using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PRJ.Service.Products;

namespace PRJ.API.Installers
{
    public class ServicesInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IProductService, ProductService>();
        }
    }
}
