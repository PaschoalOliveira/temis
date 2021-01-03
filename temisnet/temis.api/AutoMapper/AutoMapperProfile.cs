using AutoMapper;
using temis.Api.AutoMapper.Mapper.MemberMapper;

namespace temis.Api.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            MemberMapperRequest.Map(this);
            JudgmentMapperRequest.Map(this);
            ProcessMapperRequest.Map(this);
            PageProcessMapperRequest.Map(this);
            MemberMapperResponse.Map(this);
            JudgmentMapperResponse.Map(this);
            ProcessMapperResponse.Map(this);
            PageProcessMapperResponse.Map(this);
        }
    }
}