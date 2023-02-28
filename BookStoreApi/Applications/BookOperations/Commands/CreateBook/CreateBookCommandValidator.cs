using FluentValidation;

namespace BookStoreApi.Applications.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(command => command.Model.GenreId).GreaterThan(0).LessThan(20);
            RuleFor(command => command.Model.PageCount).GreaterThan(0).LessThan(5000);
            RuleFor(command => command.Model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(3);
        }
    }
}