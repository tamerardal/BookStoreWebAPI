using FluentValidation;

public class GetOrderDetailQueryValidator : AbstractValidator<GetOrderDetailQuery>
{
	public GetOrderDetailQueryValidator()
	{
		RuleFor(o => o.OrderId).NotEmpty().GreaterThan(0);
	}
}