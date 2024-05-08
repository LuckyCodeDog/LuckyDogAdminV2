using Autofac;
using Autofac.Extras.DynamicProxy;
using LuckyDog.Admin.Api.AOP;
using LuckyDog.Admin.Business.Base;
using LuckyDog.Admin.Common.ConfigOptions;
using LuckyDog.Admin.Common.Global;
using LuckyDog.Admin.IBusiness.Base;
using LuckyDog.Admin.Repository.SugarHandler;
using LuckyDog.Admin.Repository.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace LuckyDog.Admin.Api.Extensions
{
    public class AutofacRegister : Module
    {
        private readonly IConfiguration _configuration;

        public AutofacRegister(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            var configs = _configuration.Get<Configs>();

            //事务 缓存 AOP
            var registerType = new List<Type>();
            if(configs.Aop.Tran.Enabled)
            {
                builder.RegisterType<TransactionAop>();
                registerType.Add(typeof(TransactionAop));

            }
        

            builder.RegisterGeneric(typeof(SugarRepository<>)).As(typeof(ISugarRepository<>))
                .InstancePerDependency();
            builder.RegisterGeneric(typeof(BaseService<>)).As(typeof(IBaseServices<>)).InstancePerDependency();

            //注册业务层
            builder.RegisterAssemblyTypes(GlobalData.GetBusinessAssembly())
                .AsImplementedInterfaces()
                .InstancePerDependency()
                .PropertiesAutowired()
                .EnableInterfaceInterceptors()
                .InterceptedBy(registerType.ToArray());

            // 注册仓储层
            builder.RegisterAssemblyTypes(GlobalData.GetRepositoryAssembly())
                .AsImplementedInterfaces()
                .PropertiesAutowired()
                .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .PropertiesAutowired();


            //注册控制器
            var controllerBaseType = typeof(ControllerBase);
            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
                .Where(t => controllerBaseType.IsAssignableFrom(t) && t != controllerBaseType)
                .PropertiesAutowired();
        }
    }
}
