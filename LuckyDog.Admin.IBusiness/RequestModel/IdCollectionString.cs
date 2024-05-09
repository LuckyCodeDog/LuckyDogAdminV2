using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.IBusiness.RequestModel
{
    /// <summary>
    /// id模型(string)
    /// </summary>
    public class IdCollectionString
    {
        [Required]
        public HashSet<string>? IdArray { get; set; }
    }

}
