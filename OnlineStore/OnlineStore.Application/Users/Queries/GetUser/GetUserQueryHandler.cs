using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Common.Exceptions;
using OnlineStore.Application.Interfaces;
using OnlineStore.Domain;

namespace OnlineStore.Application.Users.Queries.GetUser
{
    public class GetUserQueryHandler
    : IRequestHandler<GetUserQuery, UserVm>
    {
        private readonly IOnlineStoreDbContext dbContext;
        private readonly IMapper mapper;
        public GetUserQueryHandler(IOnlineStoreDbContext dbContext,
            IMapper mapper) => (this.dbContext, this.mapper) = (dbContext, mapper);

        public async Task<UserVm> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await dbContext.Users
                .FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

            if (user == null)
                throw new NotFoundException(nameof(User), request.Id);

            return mapper.Map<UserVm>(user);
        }
    }
}
