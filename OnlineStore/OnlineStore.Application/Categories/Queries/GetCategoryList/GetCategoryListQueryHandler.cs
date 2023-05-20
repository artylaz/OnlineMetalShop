using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Interfaces;

namespace OnlineStore.Application.Categories.Queries.GetCategoryList
{
    public class GetCategoryListQueryHandler
        : IRequestHandler<GetCategoryListQuery, CategoryListVm>
    {
        private readonly IOnlineStoreDbContext dbContext;
        private readonly IMapper mapper;
        public GetCategoryListQueryHandler(IOnlineStoreDbContext dbContext,
            IMapper mapper) => (this.dbContext, this.mapper) = (dbContext, mapper);
        public async Task<CategoryListVm> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var categoryListVm = new CategoryListVm();
            if (request.CategoryId != null)
                categoryListVm.Categories = await dbContext.Categories
                    .Where(c => c.CategoryId == request.CategoryId)
                    .ProjectTo<CategoryDto>(mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
            else
                categoryListVm.Categories = await dbContext.Categories
                    .ProjectTo<CategoryDto>(mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

            return categoryListVm;
        }
    }
}
