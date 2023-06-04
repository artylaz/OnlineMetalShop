using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Application.Baskets.Queries.GetBasketCount;
using OnlineStore.Application.Orders.Queries.GetPurchaseHistory;
using OnlineStore.Application.Users.Commands.UpdateUser;
using OnlineStore.Application.Users.Queries.GetUser;
using OnlineStore.WebMVC.Models.ClientViewModel;

namespace OnlineStore.WebMVC.Controllers
{
    public class ClientController : BaseController
    {
        public async Task<IActionResult> MyAccount()
        {
            ViewData["AmountBasket"] = await Mediator.Send(new GetBasketCountQuery { UserId = UserId });

            var vm = new MyAccountVm
            {
                PurchaseHistories = await Mediator.Send(new GetPurchaseHistoryQuery { UserId = UserId }),
                User = await Mediator.Send(new GetUserQuery { Id = UserId }),
            };
            return View(vm);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> EditAccount(UserVm model)
        {
            ViewData["AmountBasket"] = await Mediator.Send(new GetBasketCountQuery { UserId = UserId });

            if (ModelState.IsValid)
            {
                UpdateUserCommand command = new()
                {
                    Id = model.Id,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    IsAccess = true,
                    LastName = model.LastName,
                    Password = model.Password,
                    Phone = model.Phone
                };
                await Mediator.Send(command);
            }
            else
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");

            return RedirectToAction("MyAccount");
        }
    }
}
