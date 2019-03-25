using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Language.Models {
	public class Word {
		public int WordId { get; set; }
		public int LanguageId { get; set; }
		public string Contributor { get; set; }
		public string WordContent { get; set; }
		public string WordDescription { get; set; }
	}
}
