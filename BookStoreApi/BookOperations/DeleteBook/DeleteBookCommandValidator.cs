using FluentValidation;

namespace BookStoreApi.BookOperations.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(command => command.BookId).NotEmpty().GreaterThan(0);
        }
    }
}