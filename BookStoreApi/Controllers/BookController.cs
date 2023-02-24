using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using static CreateBookCommand;


[ApiController]
[Route("[controller]s")]
public class BookController : ControllerBase 
{
	private readonly BookStoreDbContext? _context; // readonly uygulama içerisinden değiştirilemez. Sadece constructor üzerinden değiştirilebilir.
	private readonly IMapper _mapper;
	public BookController(BookStoreDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}
	
	[HttpGet]
	public IActionResult GetBooks()
	{		
		GetBooksQuery query = new GetBooksQuery(_context, _mapper);
		return Ok(query.Handle());
	}
	
	[HttpGet("{id}")]
	public IActionResult GetById(int id)
	{
		GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);
		
		try
		{
			query.BookId = id;
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
		
		
		return Ok(query.Handle());
	}
	
	[HttpPost]
	public IActionResult AddBook([FromBody] CreateBookVModel newBook)
	{
		CreateBookCommand command = new CreateBookCommand(_context, _mapper);
		
		try
		{
			command.Model = newBook;
			command.Handle();
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}

		return Ok();
	}
	
	[HttpPut("{id}")]
	public IActionResult UpdateResult(int id, [FromBody] UpdateBookVModel updatedBook)
	{
		
		try
		{
			UpdateBookCommand command = new UpdateBookCommand(_context);
			command.BookId = id;
			command.Model = updatedBook;
			command.Handle();
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}		
		
		return Ok();
	}
	
	[HttpDelete("{id}")]
	public IActionResult DeleteResult(int id)
	{
		
		try
		{
			DeleteBookCommand command = new DeleteBookCommand(_context);
			command.BookId = id;
			command.Handle();
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
		
		return Ok();
	}
}