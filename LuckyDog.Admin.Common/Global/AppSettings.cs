using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.Common.Global
{
    /// <summary>
    /// appsettings helper
    /// </summary>
    public class AppSettings
    {
        public static IConfiguration? Configuration { get; set; }

        /// <summary>
        /// app root path 
        /// </summary>
        public static string? ContentRootPath {  get; set; }
        /// <summary>
        /// webroot path 
        /// </summary>
        public static string? WebRootPath { get; set; }

        public static bool IsDevelopment {  get; set; }

        public AppSettings(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            ContentRootPath = webHostEnvironment.ContentRootPath;
            WebRootPath = webHostEnvironment.WebRootPath;
            IsDevelopment = webHostEnvironment.IsDevelopment();
            Configuration = configuration;
        }
        

        public static string? GetValue(string key)
        {
            try
            {
                return Configuration?[key];
            }
            catch
            {
                //ignore
            }

            return "";
        }

       
    }
}
