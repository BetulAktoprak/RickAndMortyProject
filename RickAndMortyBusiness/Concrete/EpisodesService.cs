using Microsoft.EntityFrameworkCore;
using RickAndMortyEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMortyBusiness.Concrete
{
	public class EpisodesService : GenericService<Episodes>
	{
		public EpisodesService(DbContext context) : base(context)
		{
		}
	}
}
