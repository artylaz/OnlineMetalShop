using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Categories.Queries.GetCategoryList;
using OnlineStore.Application.Interfaces;

namespace OnlineStore.Application.Categories.Queries.GetParentCategories
{
    public class GetParentCategoriesQueryHandler
    : IRequestHandler<GetParentCategoriesQuery, List<CategoryDto>>
    {
        private readonly IOnlineStoreDbContext dbContext;
        private readonly IMapper mapper;
        public GetParentCategoriesQueryHandler(IOnlineStoreDbContext dbContext,
            IMapper mapper) => (this.dbContext, this.mapper) = (dbContext, mapper);

        public async Task<List<CategoryDto>> Handle(GetParentCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await dbContext.Categories
                .Where(c => c.CategoryId == null)
                .ProjectTo<CategoryDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
