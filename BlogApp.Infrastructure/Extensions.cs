using BlogApp.Domain;
using BlogApp.Domain.Repositories;
using BlogApp.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BlogApp.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BlogAppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            })
            .AddDbContextFactory<BlogAppDbContext>(lifetime: ServiceLifetime.Scoped)
            .AddRepositories();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(IRepository<,>), typeof(Repository<,>))
                .AddScoped<ITagRepository, TagRepository>();
        }
    }
}
