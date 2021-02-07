using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tam.webapp.Db;
using Tam.webapp.Models;

namespace Tam.webapp.Controllers
{
    // TODO: Refactoring 😎
    public class HomeController : Controller
    {
        public static string[] active_user;

        private readonly TamDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, TamDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.CurrentUser = HttpContext.Session.GetString("Name");
            ViewBag.CurrentUserId = HttpContext.Session.GetInt32("Id");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}