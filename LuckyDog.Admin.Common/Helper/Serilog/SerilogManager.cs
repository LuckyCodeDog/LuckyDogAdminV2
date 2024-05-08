using Serilog;
using System;

using System.Threading.Tasks;
namespace LuckyDog.Admin.Common.Helper.Serilog
{
    public class SerilogManager
    {
        public static ILogger GetLogger(Type type)
        {
            return Log.ForContext("SourceContext", type.FullName);
        }
    }
}
