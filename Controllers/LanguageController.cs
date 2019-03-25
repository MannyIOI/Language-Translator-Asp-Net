using System;
using System.Collections.Generic;
using Language.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Language.Controllers {
	public class LanguageController : Controller {

		public IActionResult Index() {

			setup();
			return View();
			//return Content(languageId);
		}


		public IActionResult NewWord(string newWord, int langId, string details) {
			string username = HttpContext.Session.GetString("username");



			Word word = new Word {
				Contributor = username,
				LanguageId = langId,
				WordContent = newWord,
				WordDescription = details,
			};


			if (Utility.db.AddWord(word)) {
				setup();
				ViewData["notification"] = "good";
				ViewData["notification_message"] = "You have successfully Added a Word";
				return View("Index");
			}
			else {
				setup();
				ViewData["notification"] = "bad";
				ViewData["notification_message"] = "Sorry That word already exists";
				return View("Index");
			}
		}

		public IActionResult NewContributor(string langId, string contributorId) {
			if (Utility.db.AddContributor(contributorId, langId)) {
				setup();
				ViewData["notification"] = "good";
				ViewData["notification_message"] = $"{contributorId} has been successfully Added to your language!";
				return View("Index");
				//return RedirectToAction("Index","Language");
			}
			else {
				setup();
				ViewData["notification"] = "bad";
				ViewData["notification_message"] = $"OOps!! Please check your contributors username or if he is already in your project";
				return View("Index");
			}
		}

		[HttpPost]
		public IActionResult DeleteTranslation(string languageId, string wordId, string translatedWordId) {
			if (Utility.db.DeleteTranslation(languageId, wordId, translatedWordId)) {
				setup();
				ViewData["notification"] = "good";
				ViewData["notification_message"] = "You have successfully deleted the translation";
				return View("Index");
			}
			else {
				setup();
				ViewData["notification"] = "bad";
				ViewData["notification_message"] = $"OOps!! Something happened during the deleting of the translation. Please try again";
				return View("Index");
			}
		}

		public string setup() {
			string languageId = HttpContext.Session.GetString("languageId");
			ViewData["admin"] = HttpContext.Session.GetString("admin") == "true";
			ViewData["language_list"] = Utility.db.GetAllLanguagesWithEx(languageId);
			ViewData["word_list"] = Utility.db.GetWordsByLanguageId(languageId);
			ViewData["contributor_list"] = Utility.db.GetContributors(languageId);
			ViewData["translated_list"] = Utility.db.GetTranslationList(languageId);
			ViewData["language"] = Utility.db.GetLanguage(languageId);
			return languageId;
		}

		public IActionResult NewTranslation(string toLangId, string word,
												string newTranslation, string details) {
			string username = HttpContext.Session.GetString("username");
			string languageId = HttpContext.Session.GetString("languageId");

			//return Content(toLangId);
			TranslationA translation = new TranslationA {
				LanguageId = languageId,
				Contributor = username,
				WordId = word,
				TranslatedWordId = newTranslation,
				ToLanguageId = toLangId,
				Details = details
			};


			if (Utility.db.AddTranslation(translation)) {
				setup();
				ViewData["notification"] = "good";
				ViewData["notification_message"] = "You have successfully Added a Translation";
				return View("Index");
			}
			else {
				setup();
				ViewData["notification"] = "bad";
				ViewData["notification_message"] = "OOPs!! Wrong Translation input.";
				return View("Index");
				//return PartialView()
			}


			//return Content(languageId +", " + username + ", " + word + ", " + newTranslation + ", "+ details);
		}

		public IActionResult DeleteContributor(string contributorId) {
			string languageId = HttpContext.Session.GetString("languageId");
			if (Utility.db.DeleteContributorFromLanguage(languageId, contributorId)) {
				setup();
				ViewData["notification"] = "good";
				ViewData["notification_message"] = "You have Successfully Deleted the contributor "+ contributorId;
				return View("Index");
			}
			else {
				setup();
				ViewData["notification"] = "bad";
				ViewData["notification_message"] = "OOPs!! An Error occured in the deletion process. Please try again";
				return View("Index");
			}
			//return Content(contributorId);
		}

		public JsonResult GetWordList(string criteria) {
			List<Word> wordList = Utility.db.GetWordsByLanguageId(criteria);
			List<string> x = new List<string>();
			for (int i = 0; i < wordList.Count; i++) {
				x.Add(wordList[i].WordContent);
				x.Add(""+wordList[i].WordId);
			}
			return Json(x);
		}
	}
}