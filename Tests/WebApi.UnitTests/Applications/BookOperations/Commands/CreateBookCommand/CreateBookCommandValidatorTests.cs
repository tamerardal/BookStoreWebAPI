using BookStoreApi.Applications.BookOperations.Commands.CreateBook;
using FluentAssertions;
using Xunit;

public class CreateBookCommandValidatorTest : IClassFixture<CommonTestFixture>
{
	CreateBookCommand command = new CreateBookCommand(null, null);
	CreateBookCommandValidator validator = new CreateBookCommandValidator();
	
	
	[Theory]
	[InlineData("Lord of the Rings", 0, 0)]
	[InlineData("Lord of the Rings", 0, 1)]
	[InlineData("Lord of the Rings", 1, 0)]
	[InlineData("Lo", 0, 0)]
	[InlineData("", 110, 1)]
	[InlineData(" ", 100000, 21)]
	public void WhenInValidInputAreGiven_Validator_ShouldBeReturnErrors(string title, int pageCount, int genreId)
	{
		//Arrenge
		
		command.Model = new CreateBookCommand.CreateBookViewModel() { Title = "", PageCount = 0, GenreId = 0, PublishDate = DateTime.Now.Date };
		
		//Act
		var result = validator.Validate(command);
		
		//asserts
		result.Errors.Count.Should().BeGreaterThan(0);
	}
	
	[Fact]
	public void WhenDateTimeIsEqualToNowIsGiven_Validator_ShouldBeReturnError()
	{
		command.Model = new CreateBookCommand.CreateBookViewModel(){Title = "Test", PageCount = 100, GenreId = 1, PublishDate = DateTime.Now.Date};
		var result = validator.Validate(command);
		
		result.Errors.Count.Should().BeGreaterThan(0);
	}
	[Fact]
	public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError()
	{
		command.Model = new CreateBookCommand.CreateBookViewModel(){Title = "Test", PageCount = 100, GenreId = 1, PublishDate = DateTime.Now.Date.AddYears(-2)};
		var result = validator.Validate(command);
		
		result.Errors.Count.Should().Be(0);
	}
}