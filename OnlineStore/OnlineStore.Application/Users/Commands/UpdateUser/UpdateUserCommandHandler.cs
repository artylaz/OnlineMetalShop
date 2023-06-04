using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Common.Exceptions;
using OnlineStore.Application.Interfaces;
using OnlineStore.Domain;

namespace OnlineStore.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler
    : IRequestHandler<UpdateUserCommand>
    {
        private readonly IOnlineStoreDbContext dbContext;
        public UpdateUserCommandHandler(IOnlineStoreDbContext dbContext)
            => this.dbContext = dbContext;

        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await dbContext.Users
                .FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

            if (user == null)
                throw new NotFoundException(nameof(User), request.Id);

            user.IsAccess = request.IsAccess;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.Password = request.Password;
            user.Phone = request.Phone;
            if (request.RoleId != Guid.Empty)
                user.RoleId = request.RoleId;

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
