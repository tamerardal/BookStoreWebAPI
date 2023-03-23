using FluentValidation;

public class UpdatePerformerCommandValidator : AbstractValidator<UpdatePerformerCommand>
{
	public UpdatePerformerCommandValidator()
	{
		RuleFor(command => command.PerformerId).NotEmpty().GreaterThan(0);
		RuleFor(command => command.Model.Name).MinimumLength(2);
		RuleFor(command => command.Model.Surname).MinimumLength(2);
	}
}