using AppEntity.Models.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace AppService
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IArticle, ArticleService>();
            services.AddScoped<ICategory, CategoryService>();
            services.AddScoped<IArticleCategory, ArticleCategoryService>();
            services.AddScoped<IUnitService, UnitService>();
            services.AddScoped<IUser, UserService>();

            return services;
        }
    }
}

