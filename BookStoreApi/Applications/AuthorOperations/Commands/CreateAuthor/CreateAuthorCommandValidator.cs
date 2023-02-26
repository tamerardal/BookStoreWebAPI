using FluentValidation;

public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
{
	public CreateAuthorCommandValidator()
	{
		RuleFor(a => a.Model.Name).MinimumLength(2).NotEmpty();
		RuleFor(a => a.Model.Surname).MinimumLength(2).NotEmpty();
		RuleFor(a => a.Model.Birthday.Date).LessThan(DateTime.Now.Date);	
	}
}