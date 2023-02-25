using FluentValidation;

public class GetBookDetailQueryValidator : AbstractValidator<GetBookDetailQuery>
{
	public GetBookDetailQueryValidator()
    {
    	RuleFor(command => command.BookId).NotEmpty().GreaterThan(0);
    }
}