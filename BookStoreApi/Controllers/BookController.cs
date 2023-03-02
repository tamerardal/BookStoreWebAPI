using AutoMapper;
using BookStoreApi.Applications.BookOperations.Commands.CreateBook;
using BookStoreApi.Applications.BookOperations.Commands.DeleteBook;
using BookStoreApi.Applications.BookOperations.Commands.GetBookDetail;
using BookStoreApi.Applications.BookOperations.Commands.GetBooks;
using BookStoreApi.Applications.BookOperations.Commands.UpdateBook;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BookStoreApi.Applications.BookOperations.Commands.CreateBook.CreateBookCommand;

[Authorize]
[ApiController]
[Route("[controller]s")]
public class BookController : ControllerBase 
{
	private readonly IBookStoreDbContext _context; // readonly uygulama içerisinden değiştirilemez. Sadece constructor üzerinden değiştirilebilir.
	private readonly IMapper _mapper;
	public BookController(IBookStoreDbContext context, IMapper mapper)
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
	public IActionResult GetBookById(int id)
	{
		GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);
		
		query.BookId = id;
		GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
		validator.ValidateAndThrow(query);
		
		return Ok(query.Handle());
	}
	
	[HttpPost]
	public IActionResult AddBook([FromBody] CreateBookViewModel newBook)
	{
		CreateBookCommand command = new CreateBookCommand(_context, _mapper);
		
		command.Model = newBook;
		CreateBookCommandValidator validator = new CreateBookCommandValidator();
		validator.ValidateAndThrow(command);

		command.Handle();

		return Ok();
	}
	
	[HttpPut("{id}")]
	public IActionResult UpdateBook(int id, [FromBody] UpdateBookViewModel updatedBook)
	{	
		UpdateBookCommand command = new UpdateBookCommand(_context, _mapper);
		command.Model = updatedBook;
		command.BookId = id;
			
		UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
		validator.ValidateAndThrow(command);

		command.Handle();	
		
		return Ok();
	}
	
	[HttpDelete("{id}")]
	public IActionResult DeleteBook(int id)
	{		
		DeleteBookCommand command = new DeleteBookCommand(_context);
		command.BookId = id;
			
		DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
		validator.ValidateAndThrow(command);
			
		command.Handle();
		
		return Ok();
	}
}