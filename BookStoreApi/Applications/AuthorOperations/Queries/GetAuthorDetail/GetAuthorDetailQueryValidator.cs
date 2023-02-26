using FluentValidation;

public class GetAuthorDetailQueryValidator : AbstractValidator<GetAuthorDetailQuery>
{
	public GetAuthorDetailQueryValidator()
	{
		RuleFor(a => a.AuthorId).NotNull().GreaterThan(0);
	}
}