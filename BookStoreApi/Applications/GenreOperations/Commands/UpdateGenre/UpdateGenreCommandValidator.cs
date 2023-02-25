using FluentValidation;

public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
{
	public UpdateGenreCommandValidator()
	{
		RuleFor(g => g.GenreId).NotNull().GreaterThan(0);
		RuleFor(g => g.Model.Name).NotNull().MinimumLength(3);
	}
}