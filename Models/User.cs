using System.ComponentModel.DataAnnotations;
using AutoMapper;

namespace Angular.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

    }
        public class UserLoginDto
    {
       
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

    }
       public class UserReadDto
    {
        public int Id { get; set; }
        public string Username { get; set; }

    }



    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User , UserLoginDto>();
            CreateMap<User, UserReadDto>();
            CreateMap<UserLoginDto, User>();
            CreateMap<UserLoginDto, User>();
        }
    }
}