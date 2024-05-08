using LuckyDog.Admin.Common.DI;
using LuckyDog.Admin.Common.SnowflakeIdHelper;
using LuckyDog.Admin.Entity.Monitor;
using Serilog.Events;
using Serilog.Sinks.PeriodicBatching;
using SqlSugar;
using System.Security.AccessControl;

namespace LuckyDog.Admin.Api.Serilog
{
    public class LoggerToDbSink : IBatchedLogEventSink
    {
        public async Task EmitBatchAsync(IEnumerable<LogEvent> batch)
        {
           ISqlSugarClient sqlSugarClient=  AutofacHelper.GetService<ISqlSugarClient>();

           await RecordLog(sqlSugarClient, batch);
        }

        public   Task OnEmptyBatchAsync()
        {
            return Task.CompletedTask;
        }

       // write info | warning | error | fatal in their tables 
        private async Task RecordLog(ISqlSugarClient sqlSugarClient , IEnumerable<LogEvent> logEvents)
        {

            foreach(LogEvent logEvent in logEvents)
            {
               if (logEvent.Level == LogEventLevel.Information)
               {
                    InformationLog infoLogo = new InformationLog()
                    {
                        Id = IdHelper.GetLongId(),
                        CreateTime = logEvent.Timestamp.DateTime,
                        Level = logEvent.Level.ToString(),
                        Message = logEvent.RenderMessage(),
                        MessageTemplate = logEvent.MessageTemplate.ToString(),
                        Properties = logEvent.Properties.ToString()
                    };

                    try
                    {
                      await  sqlSugarClient.Insertable<InformationLog>(infoLogo).ExecuteCommandAsync();
                    }catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
               }

               if(logEvent.Level == LogEventLevel.Warning) 
               {
                    WarningLog warningLogo = new WarningLog()
                    {
                        Id = IdHelper.GetLongId(),
                        CreateTime = logEvent.Timestamp.DateTime,
                        Level = logEvent.Level.ToString(),
                        Message = logEvent.RenderMessage(),
                        MessageTemplate = logEvent.MessageTemplate.ToString(),
                        Properties = logEvent.Properties.ToString()
                    };
                    try
                    {
                        await sqlSugarClient.Insertable<WarningLog>(warningLogo).ExecuteCommandAsync();
                    }catch(Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
               }

               if(logEvent.Level == LogEventLevel.Error)
               {
                    ErrorLog errorLogo = new ErrorLog()
                    {
                        Id = IdHelper.GetLongId(),
                        CreateTime = logEvent.Timestamp.DateTime,
                        Level = logEvent.Level.ToString(),
                        Message = logEvent.RenderMessage(),
                        MessageTemplate = logEvent.MessageTemplate.ToString(),
                        Properties = logEvent.Properties.ToString()
                    };
                    try
                    {
                        await sqlSugarClient.Insertable<ErrorLog>(errorLogo).ExecuteCommandAsync();
                    }catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
               }

               if(logEvent.Level == LogEventLevel.Fatal)
                {
                    FatalLog fatalLogo = new FatalLog()
                    {
                        Id = IdHelper.GetLongId(),
                        CreateTime = logEvent.Timestamp.DateTime,
                        Level = logEvent.Level.ToString(),
                        Message = logEvent.RenderMessage(),
                        MessageTemplate = logEvent.MessageTemplate.ToString(),
                        Properties = logEvent.Properties.ToString()
                    };
                    try
                    {
                        await sqlSugarClient.Insertable<FatalLog>(fatalLogo).ExecuteCommandAsync();
                    }catch(Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }

           
        }  
    }
}
