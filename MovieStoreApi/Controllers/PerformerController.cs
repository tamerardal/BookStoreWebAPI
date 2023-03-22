using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using static CreatePerformerCommand;

[ApiController]
[Route("[controller]s")]
public class PerformerController : ControllerBase
{
	private readonly IMovieStoreDbContext _context;
	private readonly IMapper _mapper;

	public PerformerController(IMovieStoreDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}
	
	[HttpGet("{id}")]
	public IActionResult GetPerformerDetail(int id)
	{
		GetPerformerDetailQuery query = new GetPerformerDetailQuery(_context, _mapper);
		
		query.PerformerId = id;
	
		return Ok(query.Handle());
	}
	[HttpPost]
	public IActionResult AddPerformer([FromBody] CreatePerformerViewModel newPerformer)
	{
		CreatePerformerCommand command = new CreatePerformerCommand(_context, _mapper);
		command.Model = newPerformer;
		
		command.Handle();
		return Ok();
	}
}