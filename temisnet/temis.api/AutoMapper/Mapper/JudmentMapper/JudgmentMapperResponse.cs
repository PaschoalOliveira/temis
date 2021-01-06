using AutoMapper;
using temis.Api.Models.ViewModel;
using temis.Core.Models;

namespace temis.Api.AutoMapper.Mapper.MemberMapper
{
    public static class JudgmentMapperResponse
    {
        public static void Map(Profile profile)
        {
            if (profile != null)
                profile.CreateMap<Judgment, JudgmentViewModel>();
        }


    }
}