using BookStoreApi.Applications.BookOperations.Commands.GetBookDetail;
using FluentAssertions;
using Xunit;

public class GetBookDetailQueryValidatorTests : IClassFixture<CommonTestFixture>
{
	GetBookDetailQuery query = new GetBookDetailQuery(null, null);
	GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
	
	[Theory]
	[InlineData(-1)]
	[InlineData(0)]
	public void WhenInvalidIdAreGiven_Validator_ShouldBeReturnErrors(int id)
	{
		// arrange
		query.BookId = id;

		// act
		var result = validator.Validate(query);

		// assert
		result.Errors.Count.Should().BeGreaterThan(0);
	}
}