using Microsoft.AspNetCore.Mvc;
using CrudApp.Models;

namespace CrudApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Index(Login login)
        {
            if (login.Email == "admin@test.com" && login.Password == "123456")
            {
                return RedirectToAction("Index", "Users");
            }

            ViewBag.Error = "Credenciales inválidas";
            return View();
        }
    }
}
