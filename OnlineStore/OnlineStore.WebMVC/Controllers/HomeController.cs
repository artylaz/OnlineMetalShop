using Microsoft.AspNetCore.Mvc;
using OnlineStore.Application.Baskets.Queries.GetBasketCount;
using OnlineStore.Application.Categories.Queries.GetCategoryHeaderList;
using OnlineStore.WebMVC.Models.StaticModels;

namespace OnlineStore.WebMVC.Controllers
{
    public class HomeController : BaseController
    {
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
                ViewData["AmountBasket"] = await Mediator.Send(new GetBasketCountQuery { UserId = UserId });

            IndexMenuVM.Categorys = await Mediator.Send(new GetCategoryHeaderListQuery());

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Сontacts()
        {
            if (User.Identity.IsAuthenticated)
                ViewData["AmountBasket"] = await Mediator.Send(new GetBasketCountQuery { UserId = UserId });

            return View();
        }
    }
}
