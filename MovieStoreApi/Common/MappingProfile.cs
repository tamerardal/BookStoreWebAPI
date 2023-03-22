using AutoMapper;
using static CreatePerformerCommand;
using static GetDirectorDetailQuery;
using static GetDirectorsQuery;
using static GetMovieDetailQuery;
using static GetMoviesQuery;
using static GetPerformerDetailQuery;
using static GetPerformersQuery;
using static UpdatePerformerCommand;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<CreateMovieCommand.CreateMovieViewModel, Movie>();
		CreateMap<Movie, MoviesViewModel>()
		.ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
		.ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.Name + " " + src.Director.Surname));
		CreateMap<Movie, MovieDetailViewModel>()
		.ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
		.ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.Name + " " + src.Director.Surname))
		.ForMember(dest => dest.Performers, opt => opt.MapFrom(src => src.PerformersJoint.Select(x => x.Performer.Name + " " + x.Performer.Surname)));
		CreateMap<UpdateMovieViewModel, Movie>();
		
		CreateMap<CreateCustomerCommand.CreateCustomerViewModel, Customer>();
		
		CreateMap<Director, DirectorsViewModel>();
		CreateMap<Director, DirectorDetailViewModel>();
		CreateMap<CreateDirectorCommand.CreateDirectorViewModel, Director>();
		
		CreateMap<CreatePerformerViewModel, Performer>();
		CreateMap<Performer, PerformersViewModel>();
		CreateMap<Performer, PerformerDetailViewModel>()
		.ForMember(dest => dest.MoviesPlayed, opt => opt.MapFrom(src => src.PerformersJoints.Select(x => x.Movie.Name)));
		CreateMap<UpdatePerformerViewModel, Performer>();
	}
}