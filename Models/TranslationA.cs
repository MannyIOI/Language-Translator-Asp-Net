using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Language.Models {
	public class TranslationA {
		public string LanguageId { get; set; }
		public string Contributor { get; set; }
		public string WordId{ get; set; }
		public string ToLanguageId { get; set; }
		public string TranslatedWordId { get; set; }
		public string Details { get; set; }
	}
}
