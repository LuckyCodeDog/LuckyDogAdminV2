using AutoMapper;
using LuckyDog.Admin.Common.AttributeExt;
using LuckyDog.Admin.Common.Global;
using System.Reflection;

namespace LuckyDog.Admin.Api.AutoMapper
{
    public class CustomProfile: Profile
    {

        public CustomProfile() {

            initAutoMapper();
        }

        private void initAutoMapper()
        {
            List<(Type Source, Type Target)> list  = new List<(Type Source, Type Target)> ();

            var attrs =  GlobalData.GetGetIBusinessAssembly().GetTypes()
                .Where(t => t.IsDefined(typeof(AutoMappingAttribute), false))
                .Select(t => t.GetCustomAttribute<AutoMappingAttribute>());


            foreach ( var attr in attrs )
            {
                if (attr != null)
                {
                    list.Add((attr.SourceType, attr.TargetType));
                    list.Add((attr.TargetType,attr.SourceType));
                }
            }

            list.ForEach(map=>CreateMap(map.Source, map.Target));   



        }
    }
}
