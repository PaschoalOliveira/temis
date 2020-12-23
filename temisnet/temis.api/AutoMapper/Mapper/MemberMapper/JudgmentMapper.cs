using AutoMapper;
using temis.Api.Models.DTO.JudgmentDto;
using temis.Core.Models;

namespace temis.Api.AutoMapper.Mapper.MemberMapper
{
    public static class JudgmentMapper
    {
        public static void Map(Profile profile)
        {
            if (profile != null)
                profile.CreateMap<Judgment, JudgmentDto>();
        }


    }
}