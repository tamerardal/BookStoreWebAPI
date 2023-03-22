using FluentValidation;

public class CreatePerformerCommandValidator : AbstractValidator<CreatePerformerCommand>
{
	public CreatePerformerCommandValidator()
	{
		RuleFor(command => command.Model.Name).MinimumLength(1);
		RuleFor(command => command.Model.Surname).MinimumLength(3);
	}
}