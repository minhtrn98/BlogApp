using BlogApp.Api.Services;
using BlogApp.Application.Services;
using OfficeOpenXml;

namespace BlogApp.Api
{
    public static class Extensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ILoggedInUserService, LoggedInUserService>();

            return services;
        }

        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            return services;
        }

        public static void AddConfigureCors(this IServiceCollection services)
        {
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy",
            //            builder => builder.AllowAnyHeader()
            //            .AllowAnyMethod()
            //            .SetIsOriginAllowed(origin => origin == "http://localhost:4200")
            //            .AllowCredentials());
            //});
        }
    }
}