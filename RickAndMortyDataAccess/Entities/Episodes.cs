using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMortyEntity
{
	public class Episodes
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime air_date { get; set; }
        public string Episode { get; set; }
        
        public ICollection<Characters> characters { get; set; }
    }
}
