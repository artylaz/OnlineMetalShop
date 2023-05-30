using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Categories.Queries.GetCategoryList;
using OnlineStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
namespace OnlineStore.Application.Categories.Queries.GetCategoryHeaderList
{
    public class GetCategoryHLQueryHandler
    : IRequestHandler<GetCategoryHeaderListQuery, List<CategoryHeaderDto>>
    {
        private readonly IOnlineStoreDbContext dbContext;
        private readonly IMapper mapper;

        public GetCategoryHLQueryHandler(IOnlineStoreDbContext dbContext,
            IMapper mapper) => (this.dbContext, this.mapper) = (dbContext, mapper);
        public async Task<List<CategoryHeaderDto>> Handle(GetCategoryHeaderListQuery request, 
            CancellationToken cancellationToken)
        {
            return await dbContext.Categories
                .Where(c => c.CategoryId == null)
                .Include(c => c.InverseCategoryNavigation)
                .ProjectTo<CategoryHeaderDto>(mapper.ConfigurationProvider)
                .OrderBy(c=>c.Name)
                .ToListAsync(cancellationToken);
        }
    }
}
