using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Language.Models {
	public class Language {

		public Language(string username, int languageId, string languageName, string languageDetails){
			Username = username;
			LanguageId = languageId;
			LanguageName = languageName;
			LanguageDetails = languageDetails;
		}

		public String Username { get; set; }
		public int LanguageId { get; set; }
		public String LanguageName { get; set; }
		public String LanguageDetails { get; set; }
	}
}
