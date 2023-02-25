using FluentValidation;

public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
{
	public CreateGenreCommandValidator()
	{
		RuleFor(g => g.Model.Name).NotNull().MinimumLength(3);
	}
}