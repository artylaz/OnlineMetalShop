using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace OnlineStore.WebMVC.Controllers
{
    public class BaseController : Controller
    {
        private IMediator mediator;
        protected IMediator Mediator =>
            mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        internal Guid UserId
        {
            get
            {
                if(User == null)
                    return Guid.Empty;

                return !User.Identity.IsAuthenticated
                            ? Guid.Empty
                            : Guid.Parse(User.Claims.First().Value);
            }
        }

    }
}
