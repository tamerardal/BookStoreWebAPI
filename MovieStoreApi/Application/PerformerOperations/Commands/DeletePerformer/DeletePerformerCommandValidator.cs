using FluentValidation;

public class DeletePerformerCommandValidator : AbstractValidator<DeletePerformerCommand>
{
	public DeletePerformerCommandValidator()
	{
		RuleFor(command => command.PerformerId).GreaterThan(0);
	}
}