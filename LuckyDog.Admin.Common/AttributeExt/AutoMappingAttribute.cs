using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.Common.AttributeExt
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AutoMappingAttribute : Attribute
    {

        public AutoMappingAttribute(Type sourceType , Type targetType) 
        {
            SourceType = sourceType;
            TargetType = targetType;

        }

        public Type SourceType { get; }
        public Type TargetType { get; }
    }
}
