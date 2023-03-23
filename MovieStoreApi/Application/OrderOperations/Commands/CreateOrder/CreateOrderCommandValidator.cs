using FluentValidation;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
	public CreateOrderCommandValidator()
	{
		RuleFor(o => o.Model.CustomerId).NotEmpty().GreaterThan(0);
		RuleFor(o => o.Model.MovieId).NotEmpty().GreaterThan(0);
	}
}