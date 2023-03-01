using AutoMapper;
using BookStoreApi.Applications.BookOperations.Commands.UpdateBook;
using FluentAssertions;
using Xunit;

public class UpdateBookCommandTests : IClassFixture<CommonTestFixture>
{
	private readonly BookStoreDbContext _context;
	private readonly IMapper _mapper;

	public UpdateBookCommandTests(CommonTestFixture testFixture)
	{
		_context = testFixture.Context;
		_mapper = testFixture.Mapper;
	}
	
	[Fact]
	public void WhenNonValidIdIsGiven_Book_ShoulBeReturn()
	{
		UpdateBookCommand command = new UpdateBookCommand(_context, _mapper);
		
		
		FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Book doesn't exist!");
	}
	
	[Fact]
	public void WhenValidInputsAreGiven_Book_ShouldBeUpdated()
	{
		UpdateBookCommand command = new UpdateBookCommand(_context, _mapper);
		UpdateBookViewModel model = new UpdateBookViewModel() { Title = "Hobbits", PageCount = 1000, PublishDate = DateTime.Now.Date.AddYears(-10), GenreId = 1, AuthorId = 2 };
		command.BookId = 1;
		command.Model = model;
		
		FluentActions.Invoking(() => command.Handle()).Invoke();
		
		var book = _context.Books.SingleOrDefault(book => book.Id == command.BookId);
		book.Should().NotBeNull();
		book.Title.Should().Be(book.Title);
		book.PageCount.Should().Be(book.PageCount);
		book.PublishDate.Should().Be(book.PublishDate);
		book.GenreId.Should().Be(book.GenreId);
		book.AuthorId.Should().Be(book.AuthorId);
	}
}