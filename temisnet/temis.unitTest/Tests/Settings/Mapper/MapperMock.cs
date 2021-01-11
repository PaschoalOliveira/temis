using AutoMapper;
using temis.Api.AutoMapper;

namespace temis.unitTest.Settings
{
    public class MapperMock
    {
        public static IMapper Create()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new AutoMapperProfile());
            });
            
            return config.CreateMapper();
        }
    }
 }