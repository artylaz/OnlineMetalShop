using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Interfaces;
using OnlineStore.Domain;

namespace OnlineStore.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler
    : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IOnlineStoreDbContext dbContext;
        private readonly IMapper mapper;
        public CreateOrderCommandHandler(IOnlineStoreDbContext dbContext,
            IMapper mapper) => (this.dbContext, this.mapper) = (dbContext, mapper);

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var ordetStatus = await dbContext.OrderStatuses
                .FirstOrDefaultAsync(or => or.Name == "Cоздан");

            var order = new Order
            {
                Id = Guid.NewGuid(),
                CreationDate = DateTime.UtcNow,
                OrderStatusId = ordetStatus.Id,
                UserId = request.UserId,
                OrderItems = mapper.Map<List<OrderItem>>(request.OrderItems)
            };

            await dbContext.Orders.AddAsync(order,cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}
