using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using static CreatePerformerCommand;
using static UpdatePerformerCommand;

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
	
	[HttpGet]
	public IActionResult GetPerformers()
	{
		GetPerformersQuery query = new GetPerformersQuery(_context, _mapper);
	
		return Ok(query.Handle());
	}
	[HttpGet("{id}")]
	public IActionResult GetPerformerDetail(int id)
	{
		GetPerformerDetailQuery query = new GetPerformerDetailQuery(_context, _mapper);
		
		query.PerformerId = id;
		
		GetPerformerDetailQueryValidator validator = new GetPerformerDetailQueryValidator();
		validator.ValidateAndThrow(query);
	
		return Ok(query.Handle());
	}
	[HttpPost]
	public IActionResult AddPerformer([FromBody] CreatePerformerViewModel newPerformer)
	{
		CreatePerformerCommand command = new CreatePerformerCommand(_context, _mapper);
		command.Model = newPerformer;
		
		CreatePerformerCommandValidator validator = new CreatePerformerCommandValidator();
		validator.ValidateAndThrow(command);
		
		command.Handle();
		return Ok();
	}
	[HttpDelete("{id}")]
	public IActionResult DeletePerformer(int id)
	{
		DeletePerformerCommand command = new DeletePerformerCommand(_context);
		command.PerformerId = id;
		
		command.Handle();
		return Ok();
	}
	[HttpPut("{id}")]
	public IActionResult UpdatePerformer(int id, [FromBody] UpdatePerformerViewModel updatedPerformer)
	{
		UpdatePerformerCommand command = new UpdatePerformerCommand(_context, _mapper);
		command.PerformerId = id;
		command.Model = updatedPerformer;
		
		UpdatePerformerCommandValidator validator = new UpdatePerformerCommandValidator();
		validator.ValidateAndThrow(command);
		
		command.Handle();
		
		return Ok();
	}
}