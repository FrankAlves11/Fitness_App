using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fitness__App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fitness__App.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserRepo repo;

        public UserController(IUserRepo repo)
        {
            this.repo = repo;
        }


        public IActionResult Index()
        {
            var users = repo.GetAllUsers();

            return View(users);
        }

        public IActionResult ViewUser(int id)
        {
            var user = repo.GetUser(id);

            return View(user);
        }

        public IActionResult UpdateUser(int id)
        {
            User us = repo.GetUser(id);

            if (us == null)
            {
                return View("UserNotFound");
            }

            return View(us);
        }

        public IActionResult UpdateUserToDatabase(User user)
        {
            repo.UpdateUser(user);

            return RedirectToAction("ViewUser", new { id = user.ID });
        }

        public IActionResult InsertUserToDatabase(User name)
        {
            repo.InsertUser(name);
            return RedirectToAction("Index");
        }

        public IActionResult InsertUser()
        {
            var user = new User();
            return View(user); 
        }

        public IActionResult DeleteUser(User user) 
        {
            repo.DeleteUser(user);
            return RedirectToAction("Index");
        }

    }
}