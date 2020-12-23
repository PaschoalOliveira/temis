using AutoMapper;
using temis.Api.Models.DTO.MemberDto;
using temis.Core.Models;

namespace temis.Api.AutoMapper.Mapper.MemberMapper
{
    public static class MemberMapper
    {
        public static void Map(Profile profile)
        {
            if (profile != null)
                profile.CreateMap<Member, MemberDto>();
        }


    }
}