using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace netCore.Multilanguage.Controllers
{
    /// <summary>
    ///  this controller shows how to implement localizer for getting values.
    /// </summary>
    public class HomeController : Controller
    {
        private IStringLocalizer<HomeController> _localizer;
        /// <summary>
        ///  It's necessary to inject  IStringLocalizer for translating the information
        /// </summary>
        /// <param name="localizer">dependency injection of localizer</param>
        public HomeController(IStringLocalizer<HomeController> localizer)
        {
            _localizer = localizer;
        }
        public IActionResult Index()
        {
            ViewData["fromController"] = _localizer["fromController"];

            return View();
        }
    }
}