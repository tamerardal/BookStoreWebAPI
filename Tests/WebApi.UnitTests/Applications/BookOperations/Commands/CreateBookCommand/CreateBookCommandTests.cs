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
}