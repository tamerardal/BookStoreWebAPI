using FluentValidation;

public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
{
	public CreateMovieCommandValidator()
	{
		RuleFor(command => command.Model.Name).MinimumLength(3);
		RuleFor(command => command.Model.GenreId).GreaterThan(0);
		RuleFor(command => command.Model.DirectorId).GreaterThan(0);
		RuleFor(command => command.Model.Price).GreaterThan(0);
		RuleFor(command => command.Model.ReleaseDate.Date).LessThan(DateTime.Now);
		
	}
}