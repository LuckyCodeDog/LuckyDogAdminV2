using LuckyDog.Admin.Common.Global;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.Entity.Monitor
{

    [SugarTable("FatalLog")]
    public class FatalLog : SerilogBase
    {
    }
}
