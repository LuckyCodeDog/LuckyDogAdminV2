using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.Common.Model
{
    public class ActionResultVm<T>
    {
        /// <summary>
        /// content returned
        /// </summary>
        public List<T>? Content { get; set; }

        /// <summary>
        /// total elements returned
        /// </summary>
        public int TotalElements {  get; set; }
    }

}
