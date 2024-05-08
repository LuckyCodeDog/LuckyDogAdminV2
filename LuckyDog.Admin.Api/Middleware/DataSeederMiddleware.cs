using LuckyDog.Admin.Common.Helper.Serilog;
using Serilog.Settings.Configuration;
using Serilog;
using ILogger = Serilog.ILogger;
using LuckyDog.Admin.Entity.Seed;
namespace LuckyDog.Admin.Api.Middleware
{
    public static class DataSeederMiddleware
    {
        private static readonly ILogger Logger = SerilogManager.GetLogger(typeof(DataSeederMiddleware));


        public static async void UseDataSeederMiddleware(this WebApplication app , DataContext dataContext) 
        {
            if(app == null) throw new ArgumentNullException("app");

            if(dataContext.Configs.IsInitData == true)
            {
                try
                {
                   await  DataSeeder.InitSystemDataAsync(dataContext, dataContext.Configs.IsInitData, dataContext.Configs.IsQuickDebug);

                }catch (Exception ex)
                {
                    Logger.Error($"Failed to init database{ex.Message}");
                    throw ex;
                }

            }
            
        }
    }
}
