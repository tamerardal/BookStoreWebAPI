using FluentValidation;

public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
{
	public UpdateMovieCommandValidator()
	{
		RuleFor(command => command.MovieId).GreaterThan(0).NotEmpty();
		RuleFor(command => command.Model.GenreId).GreaterThan(0);
		RuleFor(command => command.Model.DirectorId).GreaterThan(0);
		RuleFor(command => command.Model.Price).GreaterThan(0);
		RuleFor(command => command.Model.ReleaseDate.Date).LessThan(DateTime.Now.Date);
	}
}