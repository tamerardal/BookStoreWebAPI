using FluentValidation;

public class GetPerformerDetailQueryValidator : AbstractValidator<GetPerformerDetailQuery>
{
	public GetPerformerDetailQueryValidator()
	{
		RuleFor(query => query.PerformerId).GreaterThan(0);
	}
}