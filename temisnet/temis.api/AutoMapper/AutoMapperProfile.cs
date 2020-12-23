using AutoMapper;
using temis.Api.AutoMapper.Mapper.MemberMapper;

namespace temis.Api.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            MemberMapper.Map(this);
            JudgmentMapper.Map(this);
            ProcessMapper.Map(this);
            PageProcessMapper.Map(this);
        }
    }
}