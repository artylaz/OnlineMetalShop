using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineStore.Application.Interfaces;

namespace OnlineStore.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<OnlineStoreDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
            services.AddScoped<IOnlineStoreDbContext>(provider =>
                provider.GetService<OnlineStoreDbContext>());
            return services;
        }
    }
}
