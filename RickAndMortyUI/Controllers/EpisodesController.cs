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
	public class EpisodesController : ControllerBase
	{
		private readonly EpisodesService _episodesService;

		public EpisodesController(EpisodesService episodesService)
		{
			_episodesService = episodesService;
		}
		[HttpGet]
		public IActionResult Get()
		{
			var episodes = _episodesService.GetList();
			return Ok(episodes);
		}
		[HttpGet("{id}")]
		public IActionResult GetId(int id)
		{
			var episodes = _episodesService.TGetById(id);
			if (episodes == null)
			{
				return NotFound();
			}

			List<SelectListItem> episode = _episodesService.GetList().
												   Select(x => new SelectListItem
												   {
													   Text = x.Name,
													   Value = x.Episode,
												   }).ToList();

			return Ok(episodes);
		}
		[HttpGet]
		public IActionResult GetFilter(string name = null)
		{

			Expression<Func<Episodes, bool>> filter = null;

			if (!string.IsNullOrEmpty(name))
			{
				filter = c => c.Name.Contains(name);
			}

			var episodes = _episodesService.GetAll(filter);

			return Ok(episodes);
		}
	}
}
