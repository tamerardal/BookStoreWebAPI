using AutoMapper;
using BookStoreApi.BookOperations.CreateBook;
using BookStoreApi.BookOperations.DeleteBook;
using BookStoreApi.BookOperations.GetBookDetail;
using BookStoreApi.BookOperations.GetBooks;
using BookStoreApi.BookOperations.UpdateBook;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using static BookStoreApi.BookOperations.CreateBook.CreateBookCommand;


[ApiController]
[Route("[controller]s")]
public class BookController : ControllerBase 
{
	private readonly BookStoreDbContext _context; // readonly uygulama içerisinden değiştirilemez. Sadece constructor üzerinden değiştirilebilir.
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
			GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
			validator.ValidateAndThrow(query);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
		
		
		return Ok(query.Handle());
	}
	
	[HttpPost]
	public IActionResult AddBook([FromBody] CreateBookViewModel newBook)
	{
		CreateBookCommand command = new CreateBookCommand(_context, _mapper);
		
		try
		{
			command.Model = newBook;
			CreateBookCommandValidator validator = new CreateBookCommandValidator();
			validator.ValidateAndThrow(command);
			
			// if (!result.IsValid)
			// 	foreach (var failure in result.Errors)
			// 		Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
			// else
			command.Handle();
				
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}

		return Ok();
	}
	
	[HttpPut("{id}")]
	public IActionResult UpdateResult(int id, [FromBody] UpdateBookViewModel updatedBook)
	{
		
		try
		{
			UpdateBookCommand command = new UpdateBookCommand(_context, _mapper);
			command.Model = updatedBook;
			command.BookId = id;
			
			UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
			validator.ValidateAndThrow(command);

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
			
			DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
			validator.ValidateAndThrow(command);
			
			command.Handle();
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
		
		return Ok();
	}
}