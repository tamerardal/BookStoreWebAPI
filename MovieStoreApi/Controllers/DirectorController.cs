using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using static CreateDirectorCommand;

namespace MovieStoreApi.Controllers
{
	[ApiController]
	[Route("[controller]s")]
	public class DirectorController : ControllerBase
	{
		private readonly IMovieStoreDbContext _context;
		private readonly IMapper _mapper;

		public DirectorController(IMovieStoreDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}
		
		[HttpGet]
		public IActionResult GetDirectors()
		{
			GetDirectorsQuery query = new GetDirectorsQuery(_context, _mapper);
			
			return Ok(query.Handle());
		}
		
		[HttpGet("{id}")]
		public IActionResult GetDirector(int id)
		{
			GetDirectorDetailQuery query = new GetDirectorDetailQuery(_context, _mapper);
			
			query.DirectorId = id;
			
			return Ok(query.Handle());
		}
		
		[HttpPost]
		public IActionResult AddDirector([FromBody] CreateDirectorViewModel newDirector)
		{
			CreateDirectorCommand command = new CreateDirectorCommand(_context, _mapper);
			
			command.Model = newDirector;
			command.Handle();

			return Ok();
		}
		
		[HttpDelete("{id}")]
		public IActionResult DeleteDirector(int id)
		{
			DeleteDirectorCommand command = new DeleteDirectorCommand(_context);
			
			command.DirectorId = id;
			command.Handle();
			
			return Ok();
		}
	}
}