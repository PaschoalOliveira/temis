using AutoMapper;
using temis.Api.Models.DTO.ProcessDto;
using temis.Core.Models;

namespace temis.Api.AutoMapper.Mapper.MemberMapper
{
    public static class ProcessMapper
    {
        public static void Map(Profile profile)
        {
            if (profile != null)
                profile.CreateMap<Process, ProcessDto>();
        }

    }
}