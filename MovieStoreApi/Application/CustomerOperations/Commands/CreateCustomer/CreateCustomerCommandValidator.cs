using FluentValidation;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
	public CreateCustomerCommandValidator()
	{
		RuleFor(c => c.Model.Name).NotEmpty().MinimumLength(2);
		RuleFor(c => c.Model.Surname).NotEmpty().MinimumLength(2);
		RuleFor(c => c.Model.Email).NotEmpty().EmailAddress();
		RuleFor(c => c.Model.Password).NotEmpty().MinimumLength(8);
	}
}