using System.Collections.Generic;
using Language.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;

namespace Language.Controllers {
	public class AccountController : Controller {
		
		public IActionResult Home() {
			//string username = HttpContext.Session.GetString("username");

			//ViewData["username"] = username;
			Setup();
			
			return View();
			
			//return Content("" + list.Count);

			//return View();
		}

		public IActionResult Back(string username) {
			Setup();
			ViewData["username"] = username;
			return View("Home");
		}


		public IActionResult Languages(string languageId, string admin) {
			HttpContext.Session.SetString("languageId", languageId);
			HttpContext.Session.SetString("admin", admin);
			return RedirectToAction("Index","Language");
		}

		public IActionResult Edit() {
			ViewData["user"] = HttpContext.Session.GetString("username");
			return View();
		}


		public void Setup() {
			string username = HttpContext.Session.GetString("username");

			List<Models.Language> list = Utility.db.GetLanguages(username);
			List<Contribution> contributions = Utility.db.GetContributions(username);
			ViewData["language_list"] = list;
			ViewData["contribution_list"] = contributions;
		}

		[HttpPost]
		public IActionResult Edit(string oldPassword, string newPassword, string conPassword) {
			string username = HttpContext.Session.GetString("username");
			Account account = Utility.db.GetAccountInfo(username);
			bool error = false;
			if (oldPassword != account.Password) {
				ViewData["input_error"] = "* Incorrect old password";
				error = true;
			}
			else if (newPassword == oldPassword) {
				ViewData["input_error"] = "* New password and old password are the same";
				error = true;
			}
			else if (conPassword != newPassword) {
				ViewData["input_error"] = "* Please make sure the passwords are similar";
				error = true;
			}
			if (error) return View();
			else {
				ViewData["input_error"] = "";
				Utility.db.UpdatePassword(username, newPassword);
				return View();
			}
		}

		[HttpPost]
		public IActionResult NewLanguage(string languageName, string languageDetails) {
			string username = HttpContext.Session.GetString("username");
			if (Utility.db.AddLanguage(username, languageName, languageDetails)) {
				ViewData["language_add_success"] = "true";
			}
			else {
				ViewData["language_add_success"] = "false";
			}

			Setup();
			return View("Home");

		}

		[HttpPost]
		public IActionResult DeleteLanguage(string languageId) {
			Utility.db.DeleteLanguage(languageId);
			Setup();
			return View("Home");
		}
	}
}