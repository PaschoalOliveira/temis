using AutoMapper;
using temis.Api.Models.DTO.MemberDto;
using temis.Api.Models.DTO.ViewModel;
using temis.Core.Models;

namespace temis.Api.AutoMapper.Mapper.MemberMapper
{
    public static class MemberMapperResponse
    {
        public static void Map(Profile profile)
        {
            if (profile != null)
                profile.CreateMap<Member, MemberViewModel>();
        }


    }
}