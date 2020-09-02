using AutoMapper;
using Invariant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invariant.Extensions
{
	public class AutoMapping : Profile
	{
		public AutoMapping()
		{
			CreateMap<Game, GameDto>();
		}
	}
}
