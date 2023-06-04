using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Baskets.Queries.ShowBasket.DTO;
using OnlineStore.Application.Interfaces;
using OnlineStore.Application.Orders.Queries.GetOrder;

namespace OnlineStore.Application.Orders.Queries.GetPurchaseHistory
{
    public class GetPurchaseHistoryQueryHandler
    : IRequestHandler<GetPurchaseHistoryQuery, List<PurchaseHistoryDto>>
    {
        private readonly IOnlineStoreDbContext dbContext;
        private readonly IMapper mapper;
        public GetPurchaseHistoryQueryHandler(IOnlineStoreDbContext dbContext,
            IMapper mapper) => (this.dbContext, this.mapper) = (dbContext, mapper);

        public async Task<List<PurchaseHistoryDto>> Handle(GetPurchaseHistoryQuery request, CancellationToken cancellationToken)
        {
            var orders = await dbContext.Orders
                .Where(o => o.UserId == request.UserId)
                .Include(o => o.OrderItems)
                .ThenInclude(oI => oI.Product)
                .ThenInclude(p => p.Pictures)
                .Include(o => o.OrderItems)
                .ThenInclude(oI => oI.Product)
                .ThenInclude(p => p.PriceChanges)
                .ToListAsync(cancellationToken);

            var listPurchaseHistoryDto = new List<PurchaseHistoryDto>();

            foreach (var order in orders)
            {
                foreach (var orderItem in order.OrderItems)
                {
                    var product = new ProductDto
                    {
                        Id = orderItem.Product.Id,
                        Name = orderItem.Product.Name,
                        Price = orderItem.Product.PriceChanges.Max(pr => pr.NewPrice),
                        PathImg = orderItem.Product.Pictures.First().Path
                    };
                    listPurchaseHistoryDto.Add(new PurchaseHistoryDto
                    {
                        DatePurchase = order.CreationDate,
                        AmountProduct = orderItem.ProductCount,
                        Product = product,
                        ProductId = orderItem.ProductId,
                        OrderItemPrice = orderItem.ProductPrice * orderItem.ProductCount
                    });
                }
            }

            return listPurchaseHistoryDto;
        }
    }
}
