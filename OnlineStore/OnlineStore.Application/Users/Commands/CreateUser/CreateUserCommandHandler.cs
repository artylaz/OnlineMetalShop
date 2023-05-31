using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Interfaces;
using OnlineStore.Application.Users.DTO;
using OnlineStore.Domain;

namespace OnlineStore.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler
    : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IOnlineStoreDbContext dbContext;
        public CreateUserCommandHandler(IOnlineStoreDbContext dbContext)
            => this.dbContext = dbContext;

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var role = await dbContext.Roles
                .FirstOrDefaultAsync(r => r.Name == "Client", cancellationToken);

            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                FirstName = request.FirstName,
                IsAccess = true,
                LastName = request.LastName,
                Password = request.Password,
                Phone = request.Phone,
                RegistrationDate = DateTime.UtcNow,
                RoleId = role.Id,
            };

            await dbContext.Users.AddAsync(user, cancellationToken);

            await dbContext.SaveChangesAsync(cancellationToken);

            var userDto = new UserDto
            {
                Email = user.Email,
                FirstName = user.FirstName,
                Id = user.Id,
                RoleName = role.Name
            };

            return userDto;
        }
    }
}
