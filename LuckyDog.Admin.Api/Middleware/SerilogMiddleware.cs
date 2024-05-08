
using LuckyDog.Admin.Api.Serilog;
using LuckyDog.Admin.Common.ConfigOptions;
using Serilog;
using Serilog.Events;
namespace LuckyDog.Admin.Api.Middleware
{
    public static class SerilogMiddleware
    {

        public static IHostBuilder UseSerilogMiddleware(this IHostBuilder hostBuilder, IConfiguration configuration) 
        {
            return hostBuilder.UseSerilog((context, loggerconfig) =>
            {

                var configs = configuration.Get<Configs>();
                loggerconfig =  loggerconfig.MinimumLevel.Debug();


                // dev evn


                // write to console 
                loggerconfig.WriteTo.Console();


                //write to debug/info/warning/fatal  files 
                foreach (LogEventLevel logEventLevel in Enum.GetValues(typeof(LogEventLevel)))
                {
                    loggerconfig.WriteToFile(logEventLevel);
                }
             

                
                //weite to database  # need to reduce db access times later
                loggerconfig.WriteToDb();
            });
        }
    }
}
