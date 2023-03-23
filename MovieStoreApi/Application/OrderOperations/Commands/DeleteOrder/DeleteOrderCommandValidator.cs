using FluentValidation;

public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
{
	public DeleteOrderCommandValidator()
	{
		RuleFor(o => o.OrderId).GreaterThan(0).NotEmpty();
	}
}