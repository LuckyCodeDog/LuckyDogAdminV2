using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
namespace LuckyDog.Admin.Common.Exception
{
    public class BadRequestException : System.Exception
    {
        public int StatusCode { get; set; } = StatusCodes.Status400BadRequest;

        public Dictionary<string, string>? Error { get; set; }   

        public BadRequestException(string message , Dictionary<string,string>? errors = null) :base(message) 
        { 

        }
    }
}
