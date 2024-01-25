using Microsoft.EntityFrameworkCore;
using RickAndMortyEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMortyDataAccess.Concrete
{
	public class Context : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseSqlServer("Server=;Database=RickAndMorty;");

		}
		public DbSet<Characters> Characters { get; set; }
		public DbSet<Episodes> Episodes { get; set; }
	}
}
