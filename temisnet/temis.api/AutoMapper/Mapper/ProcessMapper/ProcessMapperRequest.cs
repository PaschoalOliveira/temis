using AutoMapper;
using temis.Api.Models.DTO;
using temis.Core.Models;

namespace temis.Api.AutoMapper.Mapper.MemberMapper
{
    public static class ProcessMapperRequest
    {
        public static void Map(Profile profile)
        {
            if (profile != null)
                profile.CreateMap<ProcessDto, Process>();
        }

    }
}