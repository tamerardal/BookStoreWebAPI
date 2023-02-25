using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using static CreateGenreCommand;

[ApiController]
[Route("[controller]s")]
public class GenreController : ControllerBase
{
	private readonly BookStoreDbContext _dbContext;
	private readonly IMapper _mapper;

	public GenreController(BookStoreDbContext dbContext, IMapper mapper)
	{
		_dbContext = dbContext;
		_mapper = mapper;
	}
	
	[HttpGet]
	public IActionResult GetGenres()
	{
		GetGenresQuery query = new GetGenresQuery(_dbContext, _mapper);
		return Ok(query.Handle());
	}
	
	[HttpGet("{id}")]
	public IActionResult GetGenreById(int id)
	{
		GetGenreDetailQuery query = new GetGenreDetailQuery(_dbContext, _mapper);
		query.GenreId = id;
		
		return Ok(query.Handle());
	}
	
	[HttpPost]
	public IActionResult AddGenre([FromBody] CreateGenreViewModel newGenre)
	{
		CreateGenreCommand command = new CreateGenreCommand(_dbContext, _mapper);
		
		command.Model = newGenre;
		command.Handle();

		return Ok();
	}
	
	[HttpPut("{id}")]
	public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreCommand.UpdateGenreViewModel updatedGenre)
	{
		UpdateGenreCommand command = new UpdateGenreCommand(_dbContext, _mapper);
		
		command.GenreId = id;
		command.Model = updatedGenre;
		
		command.Handle();
		
		return Ok();
	}
	
	[HttpDelete("{id}")]
	public IActionResult Remove(int id)
	{
		DeleteGenreCommand command = new DeleteGenreCommand(_dbContext);
		
		command.GenreId = id;
		command.Handle();
		
		return Ok();
	}
}