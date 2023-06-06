using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Application.Baskets.Commands.AddToBasket;
using OnlineStore.Application.Baskets.Commands.DeleteBasket;
using OnlineStore.Application.Baskets.Queries.GetBasketCount;
using OnlineStore.Application.Baskets.Queries.ShowBasket;
using OnlineStore.Application.Categories.Queries.GetCategoryHeaderList;
using OnlineStore.Application.Characteristics.DTO;
using OnlineStore.Application.Orders.Commands.CreateOrder;
using OnlineStore.Application.Orders.Queries.DTO;
using OnlineStore.Application.Products.Queries.FilterSortPaginOfProducts;
using OnlineStore.Application.Products.Queries.FilterSortPaginOfProducts.DTO;
using OnlineStore.Application.Products.Queries.GetProductDetails;
using OnlineStore.Application.Products.Queries.GetProductList;
using OnlineStore.Application.Users.Queries.GetUser;
using OnlineStore.WebMVC.Models.ShoppingModels;

namespace OnlineStore.WebMVC.Controllers
{
    public class ShoppingController : BaseController
    {
        private readonly IMapper mapper;

        public ShoppingController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ShowProducts(CategoryHeaderDto category,
            List<CharacteristicDto> characteristics, string priceFilter = "0 P - 10000 P",
            SortState sortOrder = SortState.NameAsc, int page = 1)
        {
            if (User.Identity.IsAuthenticated)
                ViewData["AmountBasket"] = await Mediator.Send(new GetBasketCountQuery { UserId = UserId });

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
            if (User.Identity.IsAuthenticated)
                ViewData["AmountBasket"] = await Mediator.Send(new GetBasketCountQuery { UserId = UserId });

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

            return RedirectToAction("ShowProducts", category);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ShowBasket()
        {
            if (User.Identity.IsAuthenticated)
                ViewData["AmountBasket"] = await Mediator.Send(new GetBasketCountQuery { UserId = UserId });

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

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ShowOrder(ShowBasketVM model)
        {
            if (User.Identity.IsAuthenticated)
                ViewData["AmountBasket"] = await Mediator.Send(new GetBasketCountQuery { UserId = UserId });

            var vm = new ShowOrderVm();
            vm.User = await Mediator.Send(new GetUserQuery { Id = UserId });
            vm.OrderItems = mapper.Map<List<OrderItemDto>>(model.Baskets);
            vm.BasketPrice = model.TotalPrice;
            return View(vm);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateOrder(ShowOrderVm model)
        {
            if (User.Identity.IsAuthenticated)
                ViewData["AmountBasket"] = await Mediator.Send(new GetBasketCountQuery { UserId = UserId });

            await Mediator.Send(new CreateOrderCommand 
            { 
                UserId = UserId, 
                OrderItems = mapper.Map<List<CreateOrderItem>>(model.OrderItems) 
            });
            return RedirectToAction("ShowBasket");
        }
    }
}
