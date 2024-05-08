using LuckyDog.Admin.Common.ConfigOptions;
using LuckyDog.Admin.Common.Extention;
using LuckyDog.Admin.Common.Global;
using SqlSugar;
using System.Runtime.CompilerServices;

namespace LuckyDog.Admin.Api.Extensions
{
    public static class SqlSugarSetup
    {

        public static void AddSqlSugarSetup(this IServiceCollection services, Configs configs)
        {
            if (services.IsNull())
            {
                throw new ArgumentNullException(nameof(services));
            }

            var  dataConnection = configs.DataConnection;
            if (!dataConnection.ConnectionItem.Any())
            {
                throw new InvalidOperationException("Please Config DB Connetion First");
            }
   
            var allConnectionItem = dataConnection.ConnectionItem.Where(c => c.Enabled && c.ConnId != configs.LogDataBase).ToList();
            //tell if connection is null or 
            if(!allConnectionItem.Any() || allConnectionItem.All(c=>c.ConnId!=configs.DefaultDataBase) )
            {
                throw new Exception($"Please Makre Sure Main DB:{configs.DefaultDataBase}  Configed Properly");           
            }

            List<ConnectionConfig> connectionConfigs = new List<ConnectionConfig>();

            ConnectionConfig? masterDb = null;

            List<SlaveConnectionConfig>? slaveDb = null; 

            foreach( var connectionItem in allConnectionItem ) 
            {
                if(connectionItem.DbType ==(int) DataBaseType.Sqlite)
                {
                    connectionItem.ConnectionString = "DataSource=" + Path.Combine(AppSettings.ContentRootPath,
                    connectionItem.ConnectionString ?? string.Empty);
                }
                
                List<ConnectionItem> connectionSlaves  = new List<ConnectionItem>();

                // 读写分离
                if (configs.IsCqrs)
                {
                    slaveDb = new List<SlaveConnectionConfig>();

                    connectionSlaves.ForEach(db =>
                    {
                        slaveDb.Add(new SlaveConnectionConfig()
                        {
                            HitRate = db.HitRate,
                            ConnectionString = db.ConnectionString,
                        });
                    });
                }

                masterDb = new ConnectionConfig()
                {
                    ConfigId = connectionItem.ConnId,
                    ConnectionString = connectionItem.ConnectionString,
                    DbType = (DbType)connectionItem.DbType,
                    LanguageType = LanguageType.Default,
                    IsAutoCloseConnection  = true,
                    MoreSettings = new ConnMoreSettings()
                    {
                        IsAutoRemoveDataCache = true,
                        SqlServerCodeFirstNvarchar = true,
                    },
                    ConfigureExternalServices = new ConfigureExternalServices
                    {
                        EntityService = (c, p) =>
                        {
                            p.DbColumnName = UtilMethods.ToUnderLine(p.DbColumnName); //字段使用驼峰转下划线，不需要请注释
                            if ((DbType)connectionItem.DbType == DbType.MySql && p.DataType == "varchar(max)")
                            {
                                p.DataType = "longtext";
                            }

                            /***低版本C#写法***/
                            // int?  decimal?这种 isnullable=true 不支持string(下面.NET 7支持)
                            if (p.IsPrimarykey == false && c.PropertyType.IsGenericType &&
                                c.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                            {
                                p.IsNullable = true;
                            }

                            /***高版C#写法***/
                            //支持string?和string  
                            // if (p.IsPrimarykey == false && new NullabilityInfoContext()
                            //         .Create(c).WriteState is NullabilityState.Nullable)
                            // {
                            //     p.IsNullable = true;
                            // }
                        },
                      
                    },
                    SlaveConnectionConfigs = slaveDb
                };
                connectionConfigs.Add(masterDb);
            }
         
            var sugar = new SqlSugarScope(connectionConfigs);
            services.AddSingleton<ISqlSugarClient>(sugar);
        } 


        /// add log later
    }
}
