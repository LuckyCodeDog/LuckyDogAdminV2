using LuckyDog.Admin.Common.Extention;
using LuckyDog.Admin.Entity.Seed;

namespace LuckyDog.Admin.Api.Extensions
{
    public static class DbSetup
    {
        public static void AddDbSetup(this IServiceCollection services)
        {
            if (services.IsNull()) throw new ArgumentNullException(nameof(services));

            services.AddScoped<DataContext>();
            services.AddScoped<DataSeeder>();
        }
    }
}
