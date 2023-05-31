using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Baskets.Commands.AddToBasket;
using OnlineStore.Application.Baskets.Commands.DeleteBasket;
using OnlineStore.Application.Baskets.Queries.ShowBasket;
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

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> AddToBasket(Guid productId, int amountProduct)
        {
            var addToBasket = new AddToBasketCommand
            {
                UserId = UserId,
                ProductId = productId,
                AmountProduct = amountProduct
            };
            var (category, countBasket) = await Mediator.Send(addToBasket);

            ViewData["AmountBasket"] = countBasket;

            return RedirectToAction("ShowProducts", category);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ShowBasket()
        {
            var vm = await Mediator.Send(new ShowBasketQuery { UserId = UserId });

            return View(vm);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> RemoveBasket(DeleteBasketCommand model)
        {
            await Mediator.Send(model);

            return RedirectToAction("ShowBasket");
        }
    }
}
