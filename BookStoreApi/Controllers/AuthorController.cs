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
}