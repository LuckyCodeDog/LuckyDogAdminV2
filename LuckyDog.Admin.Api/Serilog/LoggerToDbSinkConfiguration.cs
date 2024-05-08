using Serilog;
using Serilog.Sinks.PeriodicBatching;

namespace LuckyDog.Admin.Api.Serilog
{
    public static class LoggerToDbSinkConfiguration
    {
        public static LoggerConfiguration WriteToDb(this LoggerConfiguration configuration)
        {
            var toDbSink = new LoggerToDbSink();

            var batchingOptions = new PeriodicBatchingSinkOptions
            {
                BatchSizeLimit = 500,
                Period = TimeSpan.FromSeconds(1),
                EagerlyEmitFirstEvent = true,
                QueueLimit = 1
            };

            var batchingSink = new PeriodicBatchingSink(toDbSink, batchingOptions);

            return configuration.WriteTo.Sink(batchingSink);
        }
    }
}
