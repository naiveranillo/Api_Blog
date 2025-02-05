using Api_Blog.DTOs.Category;
using Api_Blog.DTOs.Post;
using Api_Blog.DTOs.User;
using Api_Blog.Entities;
using AutoMapper;

namespace Api_Blog.Utilities
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CreateCategoryDTO, Category>();
            CreateMap<CreatePostDTO, Post>();
            CreateMap<CreateUserDTO, User>();
            CreateMap<GetIdPostDTO, Post>();
        }
    }
}
