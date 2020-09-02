using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Invariant.Models
{
	public class GameDto
	{
		public int GameId { get; set; }
		public string GameName { get; set; }
		public string GameDescription { get; set; }
	}
}
