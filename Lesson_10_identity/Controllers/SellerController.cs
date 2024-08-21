using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lesson_10_identity.Controllers
{
    [Authorize(Roles = "Seller")]
    public class SellerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
