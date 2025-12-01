using Microsoft.AspNetCore.Mvc;
using CrudApp.Models;

namespace CrudApp.Controllers
{
    public class UsersController : Controller
    {
        private static List<User> Users = new List<User>();
        private static int idCounter = 1;

        public IActionResult Index() => View(Users);

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(User user)
        {
            user.Id = idCounter++;
            Users.Add(user);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var user = Users.FirstOrDefault(x => x.Id == id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            var u = Users.First(x => x.Id == user.Id);
            u.Nombre = user.Nombre;
            u.Email = user.Email;
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var user = Users.First(x => x.Id == id);
            Users.Remove(user);
            return RedirectToAction("Index");
        }
    }
}
