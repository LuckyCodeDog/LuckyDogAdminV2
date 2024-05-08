namespace LuckyDog.Admin.Api.Serilog
{
    public class LoggerProperty
    {
        public static readonly string MessageTemplate =
       "{NewLine}Time:{Timestamp:yyyy-MM-dd HH:mm:ss.fff}{NewLine}Class:{SourceContext}{NewLine}Level:{Level}{NewLine}Message:{Message}{NewLine}{Exception}";

    }
}
