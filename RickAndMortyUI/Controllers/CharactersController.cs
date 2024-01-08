using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RickAndMortyBusiness.Concrete;
using RickAndMortyEntity;
using System.Linq.Expressions;

namespace RickAndMortyUI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CharactersController : ControllerBase
	{
		private readonly CharactersService _charactersService;

		public CharactersController(CharactersService charactersService)
		{
			_charactersService = charactersService;
		}
		[HttpGet]
		public IActionResult Get()
		{
			var characters = _charactersService.GetList();
			return Ok(characters);
		}
		[HttpGet("{id}")]
		public IActionResult GetId(int id)
		{
			var character = _charactersService.TGetById(id);
			if (character == null)
			{
				return NotFound();
			}

			List<SelectListItem> category = _charactersService.GetList().
												   Select(x => new SelectListItem
												   {
													   Text = x.episodes.ToString(),
													   Value = x.Image,
												   }).ToList();
		
			return Ok(character);
		}
		[HttpGet]
		public IActionResult GetFilter(string name = null)
		{
			
			Expression<Func<Characters, bool>> filter = null;

			if (!string.IsNullOrEmpty(name))
			{
				filter = c => c.Name.Contains(name);
			}

			var characters = _charactersService.GetAll(filter);

			return Ok(characters);
		}
		[HttpPost]
		public IActionResult PostCharacter(Characters characters)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			 _charactersService.TAdd(characters);

			return RedirectToAction("Get", "Characters");
		}

		[HttpPut("{id}")]
		public IActionResult PutCharacter(int id, [FromBody] Characters character)
		{
			if (id != character.Id)
			{
				return BadRequest();
			}

			 _charactersService.TUpdate(character);
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteCharacter(int id)
		{
			var character = _charactersService.Get(c => c.Id == id);

			if (character == null)
			{
				return NotFound();
			}

			_charactersService.TDelete(character);
			return Ok(character);
		}
	}
}
