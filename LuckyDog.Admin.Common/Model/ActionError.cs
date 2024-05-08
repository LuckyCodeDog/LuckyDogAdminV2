﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.Common.Model
{
    public class ActionError
    {

        public Dictionary<string, string>? Errors { get; set; }

        public string? GetFirstError()
        {
            return Errors != null && Errors.Any() ? Errors.First().Value : "";
        }
    }
}
