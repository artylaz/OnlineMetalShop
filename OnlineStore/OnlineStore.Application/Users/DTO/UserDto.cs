using AutoMapper;
using OnlineStore.Application.Common.Mappings;
using OnlineStore.Domain;

namespace OnlineStore.Application.Users.DTO
{
    public class UserDto : IMapWith<User>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool IsAccess { get; set; }
        public string RoleName { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDto>()
                .ForMember(userDto => userDto.Id,
                    opt => opt.MapFrom(user => user.Id))
                .ForMember(userDto => userDto.FirstName,
                    opt => opt.MapFrom(user => user.FirstName))
                .ForMember(userDto => userDto.Email,
                    opt => opt.MapFrom(user => user.Email))
                .ForMember(userDto => userDto.IsAccess,
                    opt => opt.MapFrom(user => user.IsAccess))
                .ForMember(userDto => userDto.RoleName,
                    opt => opt.MapFrom(user => user.Role.Name));

        }
    }
}
