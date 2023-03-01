using AutoMapper;
using BookStoreApi.Applications.BookOperations.Commands.CreateBook;
using FluentAssertions;
using Xunit;

public class CreateBookCommandTests : IClassFixture<CommonTestFixture>
{
	private readonly BookStoreDbContext _context;
	private readonly IMapper _mapper;
	

	public CreateBookCommandTests(CommonTestFixture testFixture)
	{
		_context = testFixture.Context;
		_mapper = testFixture.Mapper;
	}
	
	[Fact]
	public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn()
	{
		//arrenge
		var book = new Book(){ Title = "WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn", AuthorId = 2, GenreId = 1, PageCount = 120, PublishDate = new DateTime(1645, 1, 1),};
		
		_context.Books.Add(book);
		_context.SaveChanges();
		
		CreateBookCommand command = new CreateBookCommand(_context, _mapper);
		command.Model = new CreateBookCommand.CreateBookViewModel() { Title = book.Title};
		//act & assert
	
		FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Book is already added!");
	}
	[Fact]
	public void WhenValidInputsAreGiven_Book_ShouldBeCreated()
	{
		//arrenge
		CreateBookCommand command = new CreateBookCommand(_context, _mapper);
		CreateBookCommand.CreateBookViewModel model = new CreateBookCommand.CreateBookViewModel() {Title = "Hobbits", PageCount = 1000, PublishDate = DateTime.Now.Date.AddYears(-10), GenreId = 1, AuthorId = 2};
		
		command.Model = model;
		
		//act
		FluentActions.Invoking(() => command.Handle()).Invoke();

		//assert
		var book = _context.Books.SingleOrDefault(book => book.Title == model.Title);
		
		book.Should().NotBeNull();
		book.Title.Should().Be(model.Title);
		book.PageCount.Should().Be(model.PageCount);
		book.PublishDate.Should().Be(model.PublishDate);
		book.GenreId.Should().Be(model.GenreId);
		book.AuthorId.Should().Be(model.AuthorId);
	}
	
}