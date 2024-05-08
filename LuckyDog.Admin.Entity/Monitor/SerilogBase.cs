using LuckyDog.Admin.Common.Model;
using LuckyDog.Admin.Entity.Base;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.Entity.Monitor
{
    /// <summary>
    /// Serilog日志基类
    /// </summary>
    public class SerilogBase : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// 
        /// </summary>
        [SplitField]
        [SugarColumn(IsNullable = true)]
        public new DateTime CreateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string Level { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [SugarColumn(IsNullable = true, ColumnDataType = "longtext,text,clob")]
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [SugarColumn(IsNullable = true, ColumnDataType = "longtext,text,clob")]
        public string MessageTemplate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [SugarColumn(IsNullable = true, ColumnDataType = "longtext,text,clob")]
        public string Properties { get; set; }


        public bool IsDeleted { get ; set ; }
    }
}
