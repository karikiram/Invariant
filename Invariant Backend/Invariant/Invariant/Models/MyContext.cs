using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invariant.Models;

namespace Invariant.Models
{
	public class MyContext : DbContext
	{
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }

        public DbSet<Game> Game { get; set; }

    }
}
