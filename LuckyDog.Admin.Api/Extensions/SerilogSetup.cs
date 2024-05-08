using Serilog;
using System.Runtime.CompilerServices;

namespace LuckyDog.Admin.Api.Extensions
{
    public static class SerilogSetup
    {
        public static void UseSerilogSetup(this  IServiceCollection services)
        {
             if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddLogging(builder =>
            {
                builder.ClearProviders();
                builder.AddSerilog();
            });
        }
    }
}
