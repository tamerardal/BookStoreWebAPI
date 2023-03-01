using BookStoreApi.Applications.BookOperations.Commands.DeleteBook;
using FluentAssertions;
using Xunit;

public class DeleteBookCommandValidatorTests : IClassFixture<CommonTestFixture>
{
	DeleteBookCommand command = new DeleteBookCommand(null);
	DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
	
	[Theory]
	[InlineData(-1)]
	[InlineData(0)]
	public void WhenInValidInputAreGiven_Validator_ShouldBeReturnErrors(int id)
	{
		//Arrenge
		
		command.BookId = id;
		
		//Act
		var result = validator.Validate(command);
		
		//asserts
		result.Errors.Count.Should().BeGreaterThan(0);
	}
}