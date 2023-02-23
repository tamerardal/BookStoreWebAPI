using Microsoft.AspNetCore.Mvc;

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
	public Book GetById(int id)
	{
		return _context.Books.Where(book => book.Id == id).SingleOrDefault();
	}
	
	[HttpPost]
	public IActionResult AddBook([FromBody] Book newBook)
	{
		if((_context.Books.SingleOrDefault(x => x.Title == newBook.Title)) is not null)
		{
			return BadRequest();
		} 
		_context.Books.Add(newBook);
		_context.SaveChanges();
		return Ok();
	}
	
	[HttpPut("{id}")]
	public IActionResult UpdateResult(int id, [FromBody] Book updatedBook)
	{
		var book = _context.Books.SingleOrDefault(x => x.Id == id);
		if(book is null)
		{
			return BadRequest();
		}
		
		book.GenreId = updatedBook.GenreId != default ? updatedBook.GenreId : book.GenreId;
		book.Author = updatedBook.Author != default ? updatedBook.Author : book.Author;
		book.PageCount = updatedBook.PageCount != default ? updatedBook.PageCount : book.PageCount;
		book.Title = updatedBook.Title != default ? updatedBook.Title : book.Title;
		book.PublishDate = updatedBook.PublishDate != default ? updatedBook.PublishDate : book.PublishDate;
		
		_context.SaveChanges();
		return Ok();
	}
	
	[HttpDelete("{id}")]
	public IActionResult DeleteResult(int id)
	{
		var book = _context.Books.SingleOrDefault(x => x.Id == id);
		
		if (book is null)
		{
			return BadRequest();
		}
		
		_context.Books.Remove(book);
		_context.SaveChanges();
		
		return Ok();
	}
}