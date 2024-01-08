using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMortyEntity
{
	public class Characters
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string? Species { get; set; }
        public string? Type { get; set; }
        public string? Gender { get; set; }
        public string? Origin { get; set; }
        public string Url { get; set; }
        public string? Location { get; set; }
        public string Image { get; set; }
        public DateTime? Created { get; set; }
        
        public ICollection<Episodes> episodes { get; set; }
	}
}
