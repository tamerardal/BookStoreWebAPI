using AutoMapper;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]s")]
public class MovieController : ControllerBase
{
	private readonly IMovieStoreDbContext _context;
	private readonly IMapper _mapper;

	public MovieController(IMovieStoreDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}
	
	[HttpGet]
	public IActionResult GetMovies()
	{
		GetMoviesQuery query = new GetMoviesQuery(_context, _mapper);
		
		return Ok(query.Handle());
	}
}