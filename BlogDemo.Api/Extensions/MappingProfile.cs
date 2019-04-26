using AutoMapper;
using BlogDemo.Core;
using BlogDemo.Core.Entities;
using BlogDemo.Infrastructure.Resources;

namespace BlogDemo.Api.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Post, PostResource>()
                .ForMember(dest=>dest.UpdateDateTime, opt=>opt.MapFrom(src=>src.LastModified));
            CreateMap<PostResource, Post>();
            CreateMap<PostAddResource, Post>();
            CreateMap<PostUpdateResource, Post>();
        }
    }
}
