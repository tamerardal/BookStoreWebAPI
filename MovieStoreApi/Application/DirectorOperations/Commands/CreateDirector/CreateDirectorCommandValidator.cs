using FluentValidation;

public class CreateDirectorCommandValidator : AbstractValidator<CreateDirectorCommand>
{
	public CreateDirectorCommandValidator()
	{
		RuleFor(d => d.Model.Name).NotEmpty().MinimumLength(2);
		RuleFor(d => d.Model.Surname).NotEmpty().MinimumLength(2);
	}
}