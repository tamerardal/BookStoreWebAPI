using FluentValidation;

public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand> 
{
	public DeleteBookCommandValidator()
    {
    	RuleFor(command => command.BookId).NotEmpty().GreaterThan(0);
    }
}