using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Characteristics.DTO;
using OnlineStore.Application.Interfaces;

namespace OnlineStore.Application.Characteristics.Queries
{
    public class GetCharacteristicListQueryHandler
    : IRequestHandler<GetCharacteristicListQuery, List<CharacteristicDto>>
    {
        private readonly IOnlineStoreDbContext dbContext;
        private readonly IMapper mapper;
        public GetCharacteristicListQueryHandler(IOnlineStoreDbContext dbContext,
            IMapper mapper) => (this.dbContext, this.mapper) = (dbContext, mapper);

        public async Task<List<CharacteristicDto>> Handle(GetCharacteristicListQuery request, CancellationToken cancellationToken)
        {
            if (request.ProductId == null || request.ProductId == Guid.Empty)
                return await dbContext.Characteristics
                    .ProjectTo<CharacteristicDto>(mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
            else
                return await dbContext.Characteristics
                    .Where(ch=>ch.ProductId== request.ProductId)
                                    .ProjectTo<CharacteristicDto>(mapper.ConfigurationProvider)
                                    .ToListAsync(cancellationToken);
        }
    }
}
