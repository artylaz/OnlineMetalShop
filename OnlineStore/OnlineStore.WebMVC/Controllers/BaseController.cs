using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.WebMVC.Controllers
{
    public class BaseController : Controller
    {
        private IMediator mediator;
        protected IMediator Mediator =>
            mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
