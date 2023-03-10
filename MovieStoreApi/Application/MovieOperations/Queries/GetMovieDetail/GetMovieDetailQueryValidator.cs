using FluentValidation;

public class GetMovieDetailQueryValidator : AbstractValidator<GetMovieDetailQuery>
{
	public GetMovieDetailQueryValidator()
	{
		RuleFor(command => command.MovieId).NotEmpty().GreaterThan(0);
	}
}