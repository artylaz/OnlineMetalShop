using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Common.Exceptions;
using OnlineStore.Application.Interfaces;
using OnlineStore.Domain;

namespace OnlineStore.Application.Orders.Queries.GetOrder
{
    public class GetOrderQueryHandler
    : IRequestHandler<GetOrderQuery, OrderVm>
    {
        private readonly IOnlineStoreDbContext dbContext;
        private readonly IMapper mapper;
        public GetOrderQueryHandler(IOnlineStoreDbContext dbContext,
            IMapper mapper) => (this.dbContext, this.mapper) = (dbContext, mapper);

        public async Task<OrderVm> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await dbContext.Orders
                .Include(o=>o.OrderItems)
                .FirstOrDefaultAsync(o => o.UserId == request.UserId,cancellationToken);

            if (order == null)
                throw new NotFoundException(nameof(Order), request.UserId);

            return mapper.Map<OrderVm>(order);
        }
    }
}
