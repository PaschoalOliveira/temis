using AutoMapper;
using temis.Api.Models.DTO;
using temis.Api.Models.ViewModel;
using temis.Core.Models;

namespace temis.Api.AutoMapper.Mapper.MemberMapper
{
    public static class PageProcessMapperResponse
    {
        public static void Map(Profile profile)
        {
            if (profile != null)
                profile.CreateMap<Process, ProcessViewModel>();
        }


    }
}