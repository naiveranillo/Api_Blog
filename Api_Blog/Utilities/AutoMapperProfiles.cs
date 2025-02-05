using Api_Blog.DTOs.Category;
using Api_Blog.DTOs.Comment;
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
            CreateMap<CreateCommentDTO, Comment>();
            //CreateMap<GetIdPostDTO, Post>();

            CreateMap<Post, GetIdPostDTO>()
                .ForMember(opt => opt.Likes, dest => dest.Ignore())
                .ForMember(opt => opt.User, dest => dest.MapFrom(src => new UserDto
                {
                    Id = src.User.Id,
                    Name = src.User.Name,
                    LastName = src.User.LastName,
                    Email = src.User.Email

                }))
                .ForMember(opt => opt.Category, dest => dest.MapFrom(src => new CategoryDto
                {
                    Id = src.Category.Id,
                    Name = src.Category.Name
                }))
                .ForMember(opt => opt.Comments, dest => dest.MapFrom(src => src.Comments.Select(comment => new CommentDto
                {
                    Id = comment.Id,
                    Content = comment.Content,
                    User = new UserDto
                    {
                        Id = comment.User.Id,
                        Name = comment.User.Name,
                        LastName = comment.User.LastName,
                        Email = comment.User.Email
                    }
                }).ToList()));

            //CreateMap<Category, CategoryDto>()
            //    .F

        }
    }
}
