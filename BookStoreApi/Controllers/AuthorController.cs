using AutoMapper;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]s")]
public class AuthorController : ControllerBase
{
	private readonly BookStoreDbContext _context; 
	private readonly IMapper _mapper;
	public AuthorController(BookStoreDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}
	
	[HttpGet]
	public IActionResult GetAuthors()
	{
		GetAuthorsQuery query = new GetAuthorsQuery(_context, _mapper);
		return Ok(query.Handle());
	}
	
	[HttpGet("{id}")]
	public IActionResult GetAuthorById(int id)
	{
		GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context, _mapper);
		
		query.AuthorId = id;
		
		return Ok(query.Handle());
	}
}