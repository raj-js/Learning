using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace AspNetCoreLocalization.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<HomeController> _localizer;

        public HomeController(IStringLocalizer<HomeController> localizer)
        {
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            return View("Index", _localizer["say something"].Value);
        }
    }
}