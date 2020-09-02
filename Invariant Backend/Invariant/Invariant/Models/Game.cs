using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Invariant.Models
{
	public class Game
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int GameId { get; set; }
		[Required(AllowEmptyStrings = false)]
		public string GameName { get; set; }
		public string GameDescription { get; set; }
	}
}
