using AutoMapper;
using static GetMovieDetailQuery;
using static GetMoviesQuery;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<CreateMovieCommand.CreateMovieViewModel, Movie>();
		CreateMap<Movie, MoviesViewModel>()
		.ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
		.ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.Name + " " + src.Director.Surname))
		.ForMember(dest => dest.Performers, opt => opt.MapFrom(src => returnPerformers(src.Performers)));
		CreateMap<Movie, MovieDetailViewModel>()
		.ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
		.ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.Name + " " + src.Director.Surname))
		.ForMember(dest => dest.Performers, opt => opt.MapFrom(src => returnPerformers(src.Performers)));
		CreateMap<UpdateMovieViewModel, Movie>();
		
		
	}
	public List<string> returnPerformers(List<Performer> performers)
	{
	  List<string> performerNames = new List<string>();
	  foreach(Performer performer in performers)
	  {
		performerNames.Add(performer.Name + " " + performer.Surname);
	  }
	  return performerNames;
	}
}