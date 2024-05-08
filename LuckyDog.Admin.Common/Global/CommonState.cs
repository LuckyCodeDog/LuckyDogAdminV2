using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.Common.Global
{
    public enum CommonState
    {
    }

    public enum EnabledState
    {
        [Display(Name = "Enabled")]
        Enabled = 1,

        [Display(Name = "Disabled")]
        Disabled = 0
    }

    public enum BoolState
    {
        [Display(Name = "True")]
        True = 1,

        [Display(Name = "False")]
        False = 0
    }

}

