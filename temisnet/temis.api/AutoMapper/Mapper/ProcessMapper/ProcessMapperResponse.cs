using AutoMapper;
using temis.Api.Models.DTO;
using temis.Api.Models.ViewModel;
using temis.Core.Models;

namespace temis.Api.AutoMapper.Mapper.MemberMapper
{
    public class ProcessMapperResponse
    {
        public static void Map(Profile profile)
        {
            if (profile != null)
                profile.CreateMap<Process, ProcessDto>();
        }

    }
}