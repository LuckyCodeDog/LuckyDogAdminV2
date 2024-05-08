using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.Common.ConfigOptions
{
    public class Cors
    {
        public string? Name {  get; set; }   

        public bool EnableAll {  get; set; }    


        public List<Policy>? Policy { get; set; }
    }

    public class Policy
    {
        public string? Name { get; set; }

        public string? Domain { get; set; }
    }
}
