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
		.ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.Name + " " + src.Director.Surname));
		CreateMap<Movie, MovieDetailViewModel>()
		.ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
		.ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.Name + " " + src.Director.Surname));
		CreateMap<UpdateMovieViewModel, Movie>();
		
		CreateMap<CreateCustomerCommand.CreateCustomerViewModel, Customer>();
		
		
	}
	// public List<string> returnPerformers(List<int> performers)
	// {
	//   List<string> performerNames = new List<string>();
	//   foreach(int performer in performers)
	//   {
	// 	performerNames.Add(performer + " " + performer.Surname);
	//   }
	//   return performerNames;
	// }
}