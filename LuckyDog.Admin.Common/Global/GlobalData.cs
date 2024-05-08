using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.Common.Global
{
    public static class GlobalData
    {
        public static Assembly GetEntityAssembly()
        {
           string basePath  =  AppContext.BaseDirectory;
           string dllPath =  Path.Combine(basePath, "LuckyDog.Admin.Entity.dll");
           if( !File.Exists(dllPath))
            {
                throw new System.Exception("Cant Find LuckyDog.Admin.Entity.dll");
            }

           return Assembly.LoadFrom(dllPath);
        }

        public static Assembly GetGetIBusinessAssembly()
        {
            string basePath = AppContext.BaseDirectory;
            string dllPath = Path.Combine(basePath, "LuckyDog.Admin.IBusiness.dll");
            if( !File.Exists(dllPath))
            {
                throw new System.Exception("Cant Find LuckyDog.Admin.IBusiness.dll");
            }
            return Assembly.LoadFrom(dllPath);
        }

        public static Assembly GetBusinessAssembly()
        {
            string basePath = AppContext.BaseDirectory;
            string dllPath = Path.Combine(basePath, "LuckyDog.Admin.Business.dll");
            if (!File.Exists(dllPath))
            {
                throw new System.Exception("Cant Find LuckyDog.Admin.Business.dll");
            }
            return Assembly.LoadFrom(dllPath);
        }


        public static Assembly GetRepositoryAssembly()
        {
            var basePath = AppContext.BaseDirectory;
            var dllFile = Path.Combine(basePath, "LuckyDog.Admin.Repository.dll");
            if (!File.Exists(dllFile))
            {
                throw new System.Exception("Cant Find LuckyDog.Admin.Repository.dll");
            }

            return Assembly.LoadFrom(dllFile);
        }

        public static Assembly GetApiAssembly()
        {
            var basePath = AppContext.BaseDirectory;
            var dllFile = Path.Combine(basePath, "LuckyDog.Admin.Api.dll");
            if (!File.Exists(dllFile))
            {
                throw new System.Exception("Cant Find LuckyDog.Admin.Api.dll");
            }

            return Assembly.LoadFrom(dllFile);
        }
    }
}
