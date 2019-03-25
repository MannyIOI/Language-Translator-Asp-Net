namespace Language.Models {
	public class Contributor {

		public Contributor(string username, int numberOfWords, int numberOfTranslations, string language) {
			Username = username;
			NumberOfWords = numberOfWords;
			NumberOfTranslations = numberOfTranslations;
			Language = language;
		}

		public string Language { get; set; }

		public string Username { get; set; }

		public int NumberOfWords  { get; set; }

		public int NumberOfTranslations { get; set; }
	}
}
