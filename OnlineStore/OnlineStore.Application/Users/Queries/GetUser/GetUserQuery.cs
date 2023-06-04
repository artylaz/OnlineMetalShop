using MediatR;

namespace OnlineStore.Application.Users.Queries.GetUser
{
    public class GetUserQuery : IRequest<UserVm>
    {
        public Guid Id { get; set; }
    }
}
