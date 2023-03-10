using FluentValidation;

public class DeleteMovieCommandValidator : AbstractValidator<DeleteMovieCommand>
{
	public DeleteMovieCommandValidator()
	{
		RuleFor(command => command.MovieId).GreaterThan(0).NotEmpty();
	}
}