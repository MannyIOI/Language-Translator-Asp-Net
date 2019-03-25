using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Language.Models {
	public class Translation {
		public int FromId { get; set; }
		public int ToId { get; set; }

		public string FromWord { get; set; }
		public string ToWord { get; set; }
		
		public string Contributor { get; set; }

		public Translation(int FromId, int ToId, string FromWord, string ToWord, string contributor) {
			this.FromWord = FromWord;
			this.ToWord = ToWord;
			this.FromId = FromId;
			this.ToId = ToId;
			this.Contributor = contributor;
		}

		public Translation() {
		}
	}
}
