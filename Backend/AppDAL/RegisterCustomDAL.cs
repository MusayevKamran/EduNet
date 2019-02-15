using AppContract;
using Microsoft.Extensions.DependencyInjection;

namespace AppService
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IArticleDAL, ArticleDAL>();
            services.AddScoped<ICategoryDAL, CategoryDAL>();
            services.AddScoped<IArticleCategoryDAL, ArticleCategoryDAL>();
            services.AddScoped<IUnitService, UnitService>();
            services.AddScoped<IUserDAL, UserDAL>();

            return services;
        }
    }
}

