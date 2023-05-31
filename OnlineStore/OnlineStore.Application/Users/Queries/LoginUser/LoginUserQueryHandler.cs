using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Interfaces;
using OnlineStore.Application.Users.DTO;

namespace OnlineStore.Application.Users.Queries.LoginUser
{
    public class LoginUserQueryHandler
    : IRequestHandler<LoginUserQuery, UserDto>
    {
        private readonly IOnlineStoreDbContext dbContext;
        private readonly IMapper mapper;
        public LoginUserQueryHandler(IOnlineStoreDbContext dbContext,
            IMapper mapper) => (this.dbContext, this.mapper) = (dbContext, mapper);

        public async Task<UserDto> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = await dbContext.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email == request.Email && 
                u.Password == request.Password, cancellationToken);

            return mapper.Map<UserDto>(user);
        }
    }
}
