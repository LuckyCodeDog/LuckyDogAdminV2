using LuckyDog.Admin.Common.ClassLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LuckyDog.Admin.Common.Extention
{
    public static partial class  ObjectExt
	{

		/// <summary>
		/// 判断是否为Null或者空
		/// </summary>
		/// <param name="obj">对象</param>
		/// <returns></returns>
		public static bool IsNullOrEmpty(this object obj)
        {
            if(obj == null) return true;
            string? str = obj.ToString(); 
            return string.IsNullOrEmpty(str);  
        }


		/// <summary>
		/// 不等于NULL？
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static bool IsNotNull(this object obj)
		{
			return obj!=null;	
		}


		/// <summary>
		/// 等于NULL？
		/// </summary>
		/// <param name="obj">对象</param>
		/// <returns></returns>
		public static bool IsNull(this object obj)
		{
			return obj==null;
		}

	    public static string ToJson(this object obj)
		{
			var serializerSettings = new JsonSerializerSettings
			{
				ContractResolver = new CustomContractResolver(),
				DateFormatString = "yyyy-MM-dd HH:mm:ss",
				ReferenceLoopHandling = ReferenceLoopHandling.Ignore

			};
			return JsonConvert.SerializeObject(obj, serializerSettings);

        }
    }
}
