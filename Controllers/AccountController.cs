using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Tam.webapp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: /Register
        // POST: /Register

        // GET: /Login
        // POST: /Login
    }
}