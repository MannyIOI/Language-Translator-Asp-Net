using System;
using Language.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Language.Controllers {
	public class LoginController : Controller {
		public IActionResult Index() {

			return View(new User());
		}

		[HttpPost]
		public IActionResult Create(User user) {
			if (!ModelState.IsValid) return View("index", user);
			try {
				if (Utility.db.Login(user.Username, user.Password)) {
					ViewData["error_message"] = "";
					//Version["username"] = user.Username;
					HttpContext.Session.SetString("username",user.Username);
					return RedirectToAction("Home", "Account");
				}
				else {
					ViewData["error_message"] = "Incorrect username or password";
					return View("index");
				}
			}
			catch(Exception ex){
				return Content("Connection to server failed please try again");
			}
		}

		public IActionResult SignUp() {
			return View();
		}

		[HttpPost]
		public IActionResult SignUp(string username, string password, string conPassword) {
			ViewData["input_error"] = "";
			bool error = false;
			if (password != conPassword) {
				ViewData["input_error"] = "* Passwords do not match";
				error = true;
			}
			if (password.Length < 5) {
				ViewData["input_error1"] = "* Must Be greater than 5 characters";
				error = true;
			}

			if (Utility.db.UserExists(username)) {
				ViewData["input_error2"] = "* Username taken";
				error = true;
			}
			//return View;
			if (error == true) return View();
			Utility.db.AddUser(
				new User {
					Username = username,
					Password = password
				}
			);
			return View("Index");

		}
	}
}