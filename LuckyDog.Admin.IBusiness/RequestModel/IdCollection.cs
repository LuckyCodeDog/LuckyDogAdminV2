using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.IBusiness.RequestModel
{
    /// <summary>
    /// id模型(log)
    /// </summary>
    public class IdCollection
    {
        /// <summary>
        /// ids
        /// </summary>
        [Required]
        public HashSet<long>? IdArray { get; set; }
    }

}
