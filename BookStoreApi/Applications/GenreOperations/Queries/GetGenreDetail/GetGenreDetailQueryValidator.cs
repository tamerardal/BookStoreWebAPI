using FluentValidation;

public class GetGenreDetailQueryValidator : AbstractValidator<GetGenreDetailQuery>
{
	public GetGenreDetailQueryValidator()
	{
		RuleFor(g => g.GenreId).GreaterThan(0).NotEmpty();
	}
}