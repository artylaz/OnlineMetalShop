using Microsoft.AspNetCore.Mvc;
using OnlineStore.Application.Categories.Queries.GetCategoryHeaderList;
using OnlineStore.Application.Products.Queries.DTO;
using OnlineStore.Application.Products.Queries.FilterSortPaginOfProducts;
using OnlineStore.Application.Products.Queries.FilterSortPaginOfProducts.DTO;
using OnlineStore.Application.Products.Queries.GetProductDetails;
using OnlineStore.Application.Products.Queries.GetProductList;
using OnlineStore.Domain;

namespace OnlineStore.WebMVC.Controllers
{
    public class ShoppingController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> ShowProducts(CategoryHeaderDto category,
            List<CharacteristicDto> characteristics, string priceFilter = "0 P - 10000 P",
            SortState sortOrder = SortState.NameAsc, int page = 1)
        {
            var productListQuery = new GetProductListQuery
            {
                CategoryId = category.Id,
            };
            var products = await Mediator.Send(productListQuery);

            var filterSortPaginQuery = new FilterSortPaginQuery
            {
                Products = products,
                Category = category,
                CheckedCharacteristics = characteristics,
                Page = page,
                PriceFilter = priceFilter,
                SortOrder = sortOrder
            };

            var vm = await Mediator.Send(filterSortPaginQuery);

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> ShowProduct(GetProductDetailsQuery query)
        {
            var vm = await Mediator.Send(query);
            return View(vm);
        }
    }
}
