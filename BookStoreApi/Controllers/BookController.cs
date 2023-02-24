using Microsoft.AspNetCore.Mvc;
using static CreateBookCommand;

[ApiController]
[Route("[controller]s")]
public class BookController : ControllerBase 
{
	private readonly BookStoreDbContext? _context; // readonly uygulama içerisinden değiştirilemez. Sadece constructor üzerinden değiştirilebilir.
	
	public BookController(BookStoreDbContext context)
	{
		_context = context;
	}
	
	// private static List<Book> BookList = new List<Book>()
	// {
	// 	new Book
	// 	{
	// 		Id = 1,
	// 		Title = "Book of 5 Rings",
	// 		Author = "Miyamoto Musashi",
	// 		GenreId = 5, //	Philosophy
	// 		PageCount = 128,
	// 		PublishDate = new DateTime(1645, 1, 1),
	// 	},
	// 	new Book
	// 	{
	// 		Id = 2,
	// 		Title = "Meditations",
	// 		Author = "Marcus Aurelius",
	// 		GenreId = 5, //	Philosophy
	// 		PageCount = 112,
	// 		PublishDate = new DateTime(54, 1, 1),
	// 	},
	// 	new Book
	// 	{
	// 		Id = 3,
	// 		Title = "Dune",
	// 		Author = "Frank Herbert",
	// 		GenreId = 2, //	Science-Fiction
	// 		PageCount = 879,
	// 		PublishDate = new DateTime(2001, 1, 1),
	// 	}
	// };
	
	[HttpGet]
	public IActionResult GetBooks()
	{		
		GetBooksQuery query = new GetBooksQuery(_context);
		return Ok(query.Handle());
	}
	
	[HttpGet("{id}")]
	public IActionResult GetById(int id)
	{
		GetBookDetailQuery query = new GetBookDetailQuery(_context);
		
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
	public IActionResult AddBook([FromBody] CreateBookModel newBook)
	{
		CreateBookCommand command = new CreateBookCommand(_context);
		
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
	public IActionResult UpdateResult(int id, [FromBody] UpdateBookModel updatedBook)
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