using FluentValidation;

public class GetDirectorDetailQueryValidator : AbstractValidator<GetDirectorDetailQuery>
{
	public GetDirectorDetailQueryValidator()
	{
		RuleFor(d => d.DirectorId).GreaterThan(0);
	}
}