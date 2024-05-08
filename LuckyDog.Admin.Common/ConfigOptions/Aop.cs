using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.Common.ConfigOptions
{
    public class Aop
    {
        public Tran? Tran {  get; set; }
    }


    public class Tran
    {
        public bool Enabled { get; set; }

    }
}
