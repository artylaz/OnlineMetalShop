using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.WebMVC.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult MyAccount()
        {
            return View();
        }
    }
}
