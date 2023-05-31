using MediatR;
using OnlineStore.Application.Users.DTO;

namespace OnlineStore.Application.Users.Queries.LoginUser
{
    public class LoginUserQuery : IRequest<UserDto>
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
