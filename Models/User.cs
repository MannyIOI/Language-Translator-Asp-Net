using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Language.Models {
	public class User {

		[Required]
		[StringLength(25)]
		public String Username { get; set; }
		public String Password { get; set; }
	}
}
