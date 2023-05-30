using Microsoft.AspNetCore.Mvc;
using OnlineStore.Application.Categories.Queries.GetCategoryHeaderList;
using OnlineStore.WebMVC.Models.StaticModels;

namespace OnlineStore.WebMVC.Controllers
{
    public class HomeController : BaseController
    {
        public async Task<IActionResult> Index()
        {
            IndexMenuVM.Categorys = await Mediator.Send(new GetCategoryHeaderListQuery());

            return View();
        }

        [HttpGet]
        public IActionResult Сontacts()
        {
            return View();
        }
    }
}
