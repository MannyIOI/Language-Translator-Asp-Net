using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Language.Models;
using MySql.Data.MySqlClient;

namespace Language.Controllers {
	public class HomeController : Controller {
		public IActionResult Index() {
			Setup();
			return View(new Translation());
		}

		[HttpPost]
		public IActionResult Translate(string fromWord, int fromLangId, int toLangId) {
			//try {
			ViewData["translated"] = Utility.db.GetTranslationS(fromLangId, toLangId, fromWord);
			if ((string)ViewData["translated"] == "") {
				ViewData["translated"] = "...";
				//return Content((string)ViewData["translated"]);
			}

			return View("index");
		}

		public IActionResult About() {
			ViewData["Message"] = "Your application description page.";

			return View();
		}

		public IActionResult Contact() {
			ViewData["Message"] = "Your contact page.";

			return View();
		}

		public IActionResult Privacy() {
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error() {
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		public JsonResult GetTranslationJSON(string fromWord, int fromLangId, int toLangId) {
			//List<Word> wordList = Utility.db.GetWordsByLanguageId(criteria);
			List<string> x = new List<string> {
				Utility.db.GetTranslationS(fromLangId, toLangId, fromWord)
			};
			return Json(x);
		}

		public void Setup() {
			ViewData["languages"] = Utility.db.GetLanguages();
		}

		//public IActionResult 
	}
}
