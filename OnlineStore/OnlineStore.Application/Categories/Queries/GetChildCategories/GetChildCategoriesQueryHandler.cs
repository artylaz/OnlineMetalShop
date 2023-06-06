using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Categories.Queries.GetCategoryList;
using OnlineStore.Application.Interfaces;

namespace OnlineStore.Application.Categories.Queries.GetChildCategories
{
    public class GetChildCategoriesQueryHandler
    : IRequestHandler<GetChildCategoriesQuery, List<CategoryDto>>
    {
        private readonly IOnlineStoreDbContext dbContext;
        private readonly IMapper mapper;
        public GetChildCategoriesQueryHandler(IOnlineStoreDbContext dbContext,
            IMapper mapper) => (this.dbContext, this.mapper) = (dbContext, mapper);

        public async Task<List<CategoryDto>> Handle(GetChildCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await dbContext.Categories
                .Where(c => c.CategoryId != Guid.Empty)
                .ProjectTo<CategoryDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
