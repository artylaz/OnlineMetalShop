using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Interfaces;
using OnlineStore.Application.Pictures.DTO;

namespace OnlineStore.Application.Pictures.Queries.GetPictures
{
    public class GetPicturesQueryHandler
    : IRequestHandler<GetPicturesQuery, List<PictureDto>>
    {
        private readonly IOnlineStoreDbContext dbContext;
        private readonly IMapper mapper;
        public GetPicturesQueryHandler(IOnlineStoreDbContext dbContext,
            IMapper mapper) => (this.dbContext, this.mapper) = (dbContext, mapper);

        public async Task<List<PictureDto>> Handle(GetPicturesQuery request, CancellationToken cancellationToken)
        {
            return await dbContext.Pictures
                .Include(p=>p.Product)
                .ProjectTo<PictureDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
