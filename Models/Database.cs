using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace Language.Models {

	public class Database {
		String constructor = "Server=localhost;Uid=root;Pwd=;database=language;charset=utf-8";
		MySqlConnection conn;
		public bool noError = true;
		public Exception ex;

		public Database() {
			try {
				conn = new MySqlConnection(constructor);
				conn.Open();
			}
			catch (Exception ex) {
				noError = false;
				this.ex = ex;
			}
		}

		public bool UserExists(string username) {
			string query = $"SELECT * FROM `user` WHERE username = '{username}'";
			var cmd = conn.CreateCommand();
			cmd.CommandText = query;
			using (var r = cmd.ExecuteReader()) return r.HasRows;
		}

		public bool Login(string username, string userpass) {
			var cmd = conn.CreateCommand();
			cmd.CommandText =
				"SELECT COUNT(*) AS count " +
				"FROM `user` " +
				"WHERE `user`.`username` = @username " +
				"AND `user`.`password` = @password LIMIT 1";

			cmd.Parameters.AddWithValue("@username", username);
			cmd.Parameters.AddWithValue("@password", userpass);

			using (var reader = cmd.ExecuteReader()) {
				reader.Read();
				int val = reader.GetInt32("count");
				if (val == 1) return true;
				else return false;
			}
		}

		public bool AddLanguage(string username, string languageName, string languageDetails) {
			string query =
				"INSERT INTO `language` " +
				"(`username`, `language_id`, `language_name`, `language_details`) " +
				$"VALUES ('{username}', NULL, '{languageName}', '{languageDetails}');";

			var cmd = conn.CreateCommand();
			cmd.CommandText = query;
			try {
				int val = cmd.ExecuteNonQuery();
				return val == 1;
			}
			catch (MySqlException) {
				return false;
			}

		}

		public bool AddWord(Word word) {
			string query =
				"INSERT INTO `word` " +
				"(`word_id`, `language_id`, `contributor`, `word`, `word_detail`) " +
				$"VALUES (NULL, '{word.LanguageId}', '{word.Contributor}', " +
				$"'{word.WordContent}', '{word.WordDescription}')";
			var cmd = conn.CreateCommand();
			cmd.CommandText = query;
			try {
				int row = cmd.ExecuteNonQuery();
				if (row > 0) return true;

			}
			catch (MySqlException ex) {
				return false;
			}
			return false;
		}

		public bool AddTranslation(TranslationA translation) {
			string query =
				"REPLACE INTO `translations` " +
				"(`language_id`, `contributor`, `word_id`, `to_language_id`, `translated_word_id`, `translation_details`) " +
				$"VALUES ('{translation.LanguageId}', '{translation.Contributor}', {translation.WordId}, '{translation.ToLanguageId}'," +
				$" '{translation.TranslatedWordId}', '{translation.Details}');";

			var cmd = conn.CreateCommand();
			cmd.CommandText = query;
			//try {
				int row = cmd.ExecuteNonQuery();
				return row > 0;
			//}
			//catch (MySqlException) {
			//	return false;
			//}
		}

		public bool AddContributor(string username, string languageId) {
			string query = "INSERT INTO `contributor` (`id`, `username`, `language_id`) " +
							$"VALUES (NULL, '{username}', '{languageId}');";

			var cmd = conn.CreateCommand();
			cmd.CommandText = query;
			try {
				int row = cmd.ExecuteNonQuery();
				return row > 0;
			}
			catch(MySqlException) {
				return false;
			}
		}

		public bool AddUser(User user) {
			string query = 
				"INSERT INTO `user` (`username`, `password`) " +
				$"VALUES('{user.Username}', '{user.Password}')";

			var cmd = conn.CreateCommand();
			cmd.CommandText = query;
			return cmd.ExecuteNonQuery() == 1;
		}

		public bool UpdatePassword(string username, string password) {
			string query = $"UPDATE `user` SET `password` = '{password}' WHERE `user`.`username` = '{username}';";
			var cmd = conn.CreateCommand();
			cmd.CommandText = query;
			int row = cmd.ExecuteNonQuery();
			if (row > 0) return true;
			return false;
		}

		public bool DeleteTranslation(string languageId, string wordId, string translatedWordId) {
			string query = "DELETE FROM `translations` " +
				$"WHERE `translations`.`language_id` = {languageId} " +
				$"AND `translations`.`word_id` = {wordId} " +
				$"AND `translations`.`translated_word_id` = {translatedWordId}";

			var cmd = conn.CreateCommand();
			cmd.CommandText = query;
			try {
				return cmd.ExecuteNonQuery() > 0;
			}
			catch (MySqlException) {
				return false;
			}

		}

		public bool DeleteLanguage(string languageId) {
			string contribDelQuer = $"DELETE FROM `contributor` WHERE `language_id` = {languageId}";
			string translationDelQuer = $"DELETE FROM `translations` WHERE `language_id` = {languageId} OR `to_language_id` = {languageId}";
			string wordDelQuer = $"DELETE FROM `word` WHERE `language_id` = {languageId}";
			string langDelQuer = $"DELETE FROM `language` WHERE `language_id` = {languageId}";

			var cmd = conn.CreateCommand();
			cmd.CommandText = contribDelQuer;
			cmd.ExecuteNonQuery();

			var cmd2 = conn.CreateCommand();
			cmd2.CommandText = translationDelQuer;
			cmd2.ExecuteNonQuery();

			var cmd3 = conn.CreateCommand();
			cmd3.CommandText = wordDelQuer;
			cmd3.ExecuteNonQuery();

			var cmd4 = conn.CreateCommand();
			cmd4.CommandText = langDelQuer;
			return cmd4.ExecuteNonQuery() > 0;


		}

		public bool DeleteContributorFromLanguage(string languageId, string contributor) {
			string query = $"DELETE FROM `contributor` WHERE `contributor`.`username` = '{contributor}' " +
							$"AND `contributor`.`language_id` = '{languageId}'";

			var cmd = conn.CreateCommand();
			cmd.CommandText = query;
			//try {

			//}
			return cmd.ExecuteNonQuery() > 0;
		}


		public List<Language> GetLanguages(string username) {
			string query =
				"SELECT * FROM `language` " +
				$"WHERE `username` LIKE '{username}' " +
				"ORDER BY `language_id`";

			var cmd = conn.CreateCommand();
			cmd.CommandText = query;
			List<Language> languages = new List<Language>();
			using (var r = cmd.ExecuteReader()) {
				while (r.Read()) {
					languages.Add(new Language(
						r.GetString("username"),
						r.GetInt32("language_id"),
						r.GetString("language_name"),
						r.GetString("language_details")
						));
				}
			}
			return languages;
		}

		public List<Language> GetLanguages() {
			string query =
				"SELECT * FROM `language` " +
				"WHERE 1 " +
				"ORDER BY `language_id`";

			var cmd = conn.CreateCommand();
			cmd.CommandText = query;
			List<Language> languages = new List<Language>();
			using (var r = cmd.ExecuteReader()) {
				while (r.Read()) {
					languages.Add(new Language(
						r.GetString("username"),
						r.GetInt32("language_id"),
						r.GetString("language_name"),
						r.GetString("language_details")
						));
				}
			}
			return languages;
		}

		public List<Language> GetAllLanguagesWithEx(string languageId) {
			string query = $"SELECT * FROM `language` WHERE language_id != {languageId} ORDER BY `language_name` ASC";
			var cmd = conn.CreateCommand();
			cmd.CommandText = query;
			List<Language> languages = new List<Language>();
			using (var r = cmd.ExecuteReader()) {
				while (r.Read()) {
					languages.Add(new Language(
						r.GetString("username"),
						r.GetInt32("language_id"),
						r.GetString("language_name"),
						r.GetString("language_details")
						));
				}
				r.Close();
			}
			return languages;
		}

		public List<Contributor> GetContributors(string languageId) {
			string query = "" +
				"SELECT contributor.username,language.language_name, " +
				"(SELECT COUNT(*) FROM word " +
					"WHERE word.contributor = contributor.username) AS word_count, " +
				"(SELECT COUNT(*) FROM translations " +
					"WHERE translations.contributor = contributor.username) AS translation_count" +
				" FROM `contributor`, language WHERE contributor.language_id = language.language_id " +
									$"AND contributor.language_id={languageId}";

			var cmd = conn.CreateCommand();
			cmd.CommandText = query;
			List<Contributor> contributors = new List<Contributor>();
			using (var r = cmd.ExecuteReader()) {
				while (r.Read()) {
					contributors.Add(new Contributor(
						r.GetString("username"),
						r.GetInt32("word_count"),
						r.GetInt32("translation_count"),
						r.GetString("language_name")
						));
				}
			}
			return contributors;
		}

		public List<Contribution> GetContributions(string username) {
			string query = $@"
				SELECT contributor.username, language.language_id, language.language_name, 
					(SELECT COUNT(*) FROM translations WHERE translations.contributor = '{username}' 
						AND translations.language_id = language.language_id) 
						AS 'translation_count',
					(SELECT COUNT(*) FROM word WHERE word.contributor = '{username}' AND word.language_id = language.language_id) 
						AS 'word_count'
				FROM language, contributor 
				WHERE contributor.username = 'admin1' AND language.language_id = contributor.language_id
			";

			var cmd = conn.CreateCommand();
			cmd.CommandText = query;
			List<Contribution> contributions = new List<Contribution>();
			using (var r = cmd.ExecuteReader()) {
				while (r.Read()) {
					contributions.Add(
						new Contribution {
							Language = r.GetString("language_name"),
							NumOfWords = r.GetString("word_count"),
							NumOfTranslations = r.GetString("translation_count")
							}
						);
				}
			}
			return contributions;
		}

		public Translation GetTranslation(int fromLanguageId, int toLanguageId, string word) {
			string query =
				"SELECT fromWord.word_id AS fromId, " +
				"toWord.word_id AS toId, fromWord.word As frmWord, toWord.word AS toWord, toWord.contributor " +
				"FROM word fromWord, word toWord, translations " +
				"WHERE fromWord.word_id = translations.word_id " +
				"AND toWord.word_id = translations.translated_word_id " +
				$"AND fromWord.language_id = {fromLanguageId} AND toWord.language_id = {toLanguageId} " +
				$"AND Lower(fromWord.word) = Lower('{word}')";
			var cmd = conn.CreateCommand();
			cmd.CommandText = query;
			Translation translation = null;
			using (var r = cmd.ExecuteReader()) {
				while (r.Read()) {
					translation = new Translation(r.GetInt32("fromId"), r.GetInt32("toId"),
													r.GetString("frmWord"), r.GetString("toWord"),
													r.GetString("contributor"));
				}
			}
			return translation;
		}

		public string GetTranslationS(int fromLanguageId, int toLanguageId, string sentence) {
			if (sentence == null || sentence == "") {
				return "";
			}
			else {
				string[] brokenDown = sentence.Split(" ");
				string translatedSentence = "";
				for (int i = 0; i < brokenDown.Length; i++) {
					Translation translation = this.GetTranslation(fromLanguageId, toLanguageId, brokenDown[i]);
					if (translation != null) {
						translatedSentence += translation.ToWord + " ";
						//translatedSentence = "";
					}
					else {
						translatedSentence += "...";
					}
					
				}
				return translatedSentence;
			}

		}

		public List<Translated> GetTranslationList(string fromLanguageId) {
			string query = 
				@"SELECT 
				fromWord.word_id,
				toWord.word_id AS 'translated_id',
				fromWord.contributor AS 'addedBy',
				fromWord.word AS 'word',
				toWord.word AS 'translation',
				toLang.language_name AS 'toLanguage',
				toWord.contributor AS 'translatedBy'

				FROM word fromWord, word toWord, language fromLang, language toLang, translations 
				WHERE fromWord.word_id = translations.word_id 
				AND toWord.word_id = translations.translated_word_id
				AND fromWord.language_id = fromLang.language_id
				AND toWord.language_id = toLang.language_id "+
				$"AND fromWord.language_id = {fromLanguageId}";

			var cmd = conn.CreateCommand();
			cmd.CommandText = query;
			List<Translated> translatedList = new List<Translated>();
			using (var r = cmd.ExecuteReader()) {
				if (r.HasRows) {
					while (r.Read()) {
						translatedList.Add(new Translated {
							TranslatedWordId = r.GetString("translated_id"),
							WordId = r.GetString("word_id"),
							AddedBy = r.GetString("addedBy"),
							Word = r.GetString("word"),
							Translation = r.GetString("translation"),
							TranslationLanguage = r.GetString("toLanguage"),
							TranslatedBy = r.GetString("translatedBy")
						});
					}
				}
			}
			return translatedList;
		}

		public Language GetLanguage(string languageId) {
			string query = $"SELECT * FROM `language` WHERE language.language_id = {languageId}";
			var cmd = conn.CreateCommand();
			cmd.CommandText = query;
			Language language = null;
			using (var r = cmd.ExecuteReader()) {
				
				while (r.Read()) {
					language = new Language(
						r.GetString("username"),
						r.GetInt32("language_id"),
						r.GetString("language_name"),
						r.GetString("language_details"));
				}
			}

			return language;
		}

		public List<Word> GetWordsByLanguageId(string languageId) {
			string query = $"SELECT * FROM `word` WHERE language_id = {languageId}";
			var cmd = conn.CreateCommand();
			cmd.CommandText = query;
			List<Word> words = new List<Word>();
			using (var r = cmd.ExecuteReader()) {

				while (r.Read()) {
					words.Add(new Word() {
						LanguageId = r.GetInt32("language_id"),
						WordId = r.GetInt32("word_id"),
						Contributor = r.GetString("contributor"),
						WordContent = r.GetString("word"),
						WordDescription = r.GetString("word_detail")
					});
				}
			}
			return words;
		}

		public Account GetAccountInfo(string username) {
			string query = $"SELECT * FROM `user` WHERE user.username = '{username}'";
			var cmd = conn.CreateCommand();
			cmd.CommandText = query;
			Account account = null;
			using (var r = cmd.ExecuteReader()) {
				while (r.Read()) {
					account = new Account {
						Username = r.GetString("username"),
						Password = r.GetString("password")
					};
				}
			}
			return account;
		}

		

		
	}
}
