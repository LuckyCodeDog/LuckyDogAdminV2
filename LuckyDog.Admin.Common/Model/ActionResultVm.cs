using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
namespace LuckyDog.Admin.Common.Model
{
    public class ActionResultVm
    {
        /// <summary>
        /// status code
        /// </summary>
        public int Status {  get; set; } = StatusCodes.Status200OK;

        public ActionError? ActionError { get; set; }

        /// <summary>
        /// msg returned
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// timestamp
        /// </summary>
        public string? TimeStamp {  get; set; }
        /// <summary>
        /// request path
        /// </summary>
        public string? Path { get; set; }


    }
}
