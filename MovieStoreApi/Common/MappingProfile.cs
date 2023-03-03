using AutoMapper;
using static GetMovieDetailQuery;
using static GetMoviesQuery;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<Movie, MoviesViewModel>()
		.ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
		.ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.Name + " " + src.Director.Surname))
		.ForMember(dest => dest.Performers, opt => opt.MapFrom(src => returnActors(src.Performers)));
		CreateMap<Movie, MovieDetailViewModel>()
		.ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
		.ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.Name + " " + src.Director.Surname))
		.ForMember(dest => dest.Performers, opt => opt.MapFrom(src => returnActors(src.Performers)));
		
		
		
	}
	public List<string> returnActors(List<Performer> actors)
	{
	  List<string> performerNames = new List<string>();
	  foreach(Performer performer in actors)
	  {
		performerNames.Add(performer.Name + " " + performer.Surname);
	  }
	  return performerNames;
	}
}