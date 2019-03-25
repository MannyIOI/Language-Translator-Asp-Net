using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Language.Models {
	public class Movie {
		public int Id { get; set; }

		[Required]
		[StringLength(255)]
		public String Name { get; set; }

	}
}
