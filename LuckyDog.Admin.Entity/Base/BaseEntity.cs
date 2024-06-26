﻿using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.Entity.Base
{
    /// <summary>
    /// 实体基类
    /// </summary>
    public class BaseEntity : RootKey<long>
    {
        /// <summary>
        /// 创建者名称
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string? CreateBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public DateTime CreateTime { get; set; } =  DateTime.Now;

        /// <summary>
        /// 更新者名称
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string? UpdateBy { get; set; } 

        /// <summary>
        /// 最后更新时间
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public DateTime? UpdateTime { get; set; } = DateTime.Now;
    }
}
