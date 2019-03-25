using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Language.Models {
	public class Translated {
		public string AddedBy { get; set; }
		public string Word { get; set; }
		public string Translation { get; set; }
		public string TranslationLanguage { get; set; }
		public string TranslatedBy { get; set; }
		public string WordId { get; set; }
		public string TranslatedWordId { get; set; }
	}
}
