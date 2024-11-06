using ClothingPro.BusinessLayer.BusinessService;
using ClothingPro.BusinessLayer.Interface;
using ClothingPro.BusinessLayer.Repository;
using ClothingPro.DataAccessLayer.DbAccess;

namespace ClothingPro.BusinessLayer.Helper;
public class ConfigService
{
    public static void ConfigureIService(IServiceCollection services)
    {
        // Register other repositories and services
        services.AddScoped<UnitOfWork>();
        services.AddScoped<StockRepository>();
        services.AddScoped<MenuHeaderRepository>();
        services.AddScoped<CompanyRepository>();
        services.AddScoped<BannerRepository>();
        services.AddScoped<ColorImagesRepository>();

        // Register SettingRepository
        services.AddScoped<SettingRepository>(); // Add this line

        // Register services
        services.AddScoped<IStockService, StockService>();
        services.AddScoped<IMenuHeaderService, MenuHeaderService>();
        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<IBannerService, BannerService>();
        services.AddScoped<IColorImagesService, ColorImagesService>();

        // Register MVCHelper
        services.AddScoped<MVCHelper>();
    }


}
