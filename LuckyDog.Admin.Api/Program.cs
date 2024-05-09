
using LuckyDog.Admin.Api.AutoMapper;
using LuckyDog.Admin.Common.ConfigOptions;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using LuckyDog.Admin.Api.Extensions;
using LuckyDog.Admin.Entity.Seed;
using Microsoft.Extensions.Logging;
using LuckyDog.Admin.IBusiness.Interface.Permission;
using LuckyDog.Admin.Common.DI;
using SqlSugar;
using LuckyDog.Admin.Repository.UnitOfWork;
using LuckyDog.Admin.Common.Global;
using LuckyDog.Admin.Common.Webapp;
using Autofac.Core;
using LuckyDog.Admin.Api.Middleware;
using LuckyDog.Admin.Common.SnowflakeIdHelper;
namespace LuckyDog.Admin.Api
{
    public class Program
    {
        public static  void Main(string[] args)
        {
           IConfiguration  configuration = null;
            var builder = WebApplication.CreateBuilder(args);
            new IdHelperBootstrapper().SetWorkderId(1).Boot();
            var configString = builder.Environment.IsDevelopment() ? "appsettings.Development.json" : "appsettings.json";
            //congig container 
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    configuration = hostingContext.Configuration;
                    config.Sources.Clear();
                    config.AddJsonFile(configString,
                        optional: true, reloadOnChange: false);
                })
                .UseSerilogMiddleware(configuration)
                .ConfigureContainer<ContainerBuilder>(builder => { builder.RegisterModule(new AutofacRegister(configuration));});
            // Add services to the container.
            // Add S
            builder.Services.AddControllers();
            // Add   Services
            //  Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); //http context acceessor 
            builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();  // action context accessor
            builder.Services.AddSingleton(new AppSettings(builder.Configuration, builder.Environment));
            builder.Services.Configure<Configs>(configuration);
            var configs =  configuration.Get<Configs>();
            builder.Services.AddSqlSugarSetup(configs);
            builder.Services.AddDbSetup();
            builder.Services.AddAutoMapperSetup();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ApeContext>();

           builder.Services.AddScoped<IHttpUser, HttpUser>();
            var app = builder.Build();

            AutofacHelper.Container = app.Services.GetAutofacRoot();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {

                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
      
           var dataContext = app.Services.GetRequiredService<DataContext>();    

           app.UseDataSeederMiddleware(dataContext);

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
