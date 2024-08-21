using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lesson_10_identity.Controllers
{
    [Authorize(Roles = "Buyer")]
    public class BuyerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
