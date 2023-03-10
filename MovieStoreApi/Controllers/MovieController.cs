using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using static CreateMovieCommand;

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
	
	[HttpGet("{id}")]
	public IActionResult GetMovieDetail(int id)
	{
		GetMovieDetailQuery query = new GetMovieDetailQuery(_context, _mapper);
		
		query.MovieId = id;
		
		GetMovieDetailQueryValidator validator = new GetMovieDetailQueryValidator();
		validator.ValidateAndThrow(query);
		
		var result = query.Handle();
		
		return Ok(result);
	}
	
	[HttpPost]
	public IActionResult AddMovie([FromBody] CreateMovieViewModel newMovie)
	{
		CreateMovieCommand command = new CreateMovieCommand(_context, _mapper);
		command.Model = newMovie;
		
		CreateMovieCommandValidator validator = new CreateMovieCommandValidator();
		validator.ValidateAndThrow(command);
		
		command.Handle();
		
		return Ok();
	}
	
	[HttpPut("{id}")]
	public IActionResult UpdateMovie(int id, [FromBody]UpdateMovieViewModel updatedMovie)
	{
		UpdateMovieCommand command = new UpdateMovieCommand(_context, _mapper);
		command.MovieId = id;
		
		command.Model = updatedMovie;
		
		UpdateMovieCommandValidator validator = new UpdateMovieCommandValidator();
		validator.ValidateAndThrow(command);
		
		command.Handle();
		
		return Ok();
	}
	
	[HttpDelete("{id}")]
	public IActionResult DeleteMovie(int id)
	{
		DeleteMovieCommand command = new DeleteMovieCommand(_context);
		command.MovieId = id;
		
		DeleteMovieCommandValidator validator = new DeleteMovieCommandValidator();
		validator.ValidateAndThrow(command);
		
		command.Handle();
		return Ok();
	}
}