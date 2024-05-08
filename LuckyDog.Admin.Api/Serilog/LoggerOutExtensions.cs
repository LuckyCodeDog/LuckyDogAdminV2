using Serilog;
using Serilog.Events;

namespace LuckyDog.Admin.Api.Serilog
{
    public static class LoggerOutExtensions
    {

        //writte to files info | warnning |  fatal 
        public static LoggerConfiguration WriteToFile(this LoggerConfiguration configuration, LogEventLevel logEventLevel)
        {
            // write to files based onn log event level
            return  configuration.WriteTo.Logger(lg =>
            {
                lg.Filter.ByIncludingOnly(p => p.Level == logEventLevel).WriteTo.Async(s =>
                {
                    s.File(Path.Combine("Logs", logEventLevel.ToString(), ".log"),
                        rollingInterval: RollingInterval.Day,
                        outputTemplate: LoggerProperty.MessageTemplate,
                        encoding: System.Text.Encoding.UTF8);
                });
            }
          );

        }


    }
}
