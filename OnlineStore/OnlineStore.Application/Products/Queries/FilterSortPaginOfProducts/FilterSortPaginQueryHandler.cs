using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Interfaces;
using OnlineStore.Application.Products.Queries.DTO;
using OnlineStore.Application.Products.Queries.FilterSortPaginOfProducts.DTO;

namespace OnlineStore.Application.Products.Queries.FilterSortPaginOfProducts
{
    public class FilterSortPaginQueryHandler : IRequestHandler<FilterSortPaginQuery, ShowProductsVm>
    {
        private readonly IOnlineStoreDbContext dbContext;
        private readonly IMapper mapper;
        public FilterSortPaginQueryHandler(IOnlineStoreDbContext dbContext,
            IMapper mapper) => (this.dbContext, this.mapper) = (dbContext, mapper);

        public async Task<ShowProductsVm> Handle(FilterSortPaginQuery request, CancellationToken cancellationToken)
        {
            var showProductsVM = new ShowProductsVm();

            var characteristics = request.Products
                .SelectMany(p=> p.Characteristics)
                .ToList();

            //Фильтрация
            var productsF = new List<ProductDto>();
            if (request.CheckedCharacteristics.Count() == 0)
                productsF = request.Products;
            else
                foreach (var item in request.CheckedCharacteristics)
                {
                    productsF
                        .AddRange(request.Products
                        .Where(p => p.Characteristics.Any(ph => ph.Id == item.Id) == true));
                }

            string[] stringArr = new string[6];
            if (request.PriceFilter != null)
                stringArr = request.PriceFilter.Split(new char[] { ' ' });

            if (stringArr[0] != null && stringArr[3] != null)
                productsF = productsF
                    .Where(p => p.Price >= int.Parse(stringArr[0]) &&
                    p.Price <= int.Parse(stringArr[3])).ToList();

            //Сортировка
            productsF = request.SortOrder switch
            {
                SortState.NameAsc => productsF.OrderBy(s => s.Name).ToList(),
                SortState.NameDesc => productsF.OrderByDescending(s => s.Name).ToList(),
                SortState.PriceAsc => productsF.OrderBy(s => s.Price).ToList(),
                SortState.PriceDesc => productsF.OrderByDescending(s => s.Price).ToList(),
                _ => productsF.OrderBy(s => s.Name).ToList(),
            };

            showProductsVM.CoutProduct = productsF.Count;

            //Пагинация
            int pageSize = 9;
            var count = productsF.Count;
            productsF = productsF.Skip((request.Page - 1) * pageSize).Take(pageSize).ToList();

            showProductsVM.Products = productsF;
            showProductsVM.Category = request.Category;
            showProductsVM.CheckedCharacteristics = request.CheckedCharacteristics;
            showProductsVM.Characteristics = await dbContext.Characteristics
                .ProjectTo<CharacteristicDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            showProductsVM.SortOrder = request.SortOrder;
            showProductsVM.Page = new Page(count, request.Page, pageSize);
            showProductsVM.PriceFilter = stringArr[0] + " P - " + stringArr[3] + " P";

            return showProductsVM;
        }
    }
}
