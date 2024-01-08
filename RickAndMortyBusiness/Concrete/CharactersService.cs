using Microsoft.EntityFrameworkCore;
using RickAndMortyBusiness.Abstract;
using RickAndMortyEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMortyBusiness.Concrete
{
	public class CharactersService : GenericService<Characters>
	{
		public CharactersService(DbContext context) : base(context)
		{
		}
	}
}
