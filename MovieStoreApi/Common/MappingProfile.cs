using AutoMapper;
using static CreateOrderCommand;
using static CreatePerformerCommand;
using static GetDirectorDetailQuery;
using static GetDirectorsQuery;
using static GetMovieDetailQuery;
using static GetMoviesQuery;
using static GetOrderDetailQuery;
using static GetOrdersQuery;
using static GetPerformerDetailQuery;
using static GetPerformersQuery;
using static UpdatePerformerCommand;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		//Movie Mapping
		CreateMap<CreateMovieCommand.CreateMovieViewModel, Movie>();
		CreateMap<Movie, MoviesViewModel>()
		.ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
		.ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.Name + " " + src.Director.Surname));
		CreateMap<Movie, MovieDetailViewModel>()
		.ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
		.ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.Name + " " + src.Director.Surname))
		.ForMember(dest => dest.Performers, opt => opt.MapFrom(src => src.PerformersJoint.Select(x => x.Performer.Name + " " + x.Performer.Surname)))
		.ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));
		CreateMap<UpdateMovieViewModel, Movie>();
		
		//Customer Mapping
		CreateMap<CreateCustomerCommand.CreateCustomerViewModel, Customer>();
		
		//Director Mapping
		CreateMap<Director, DirectorsViewModel>();
		CreateMap<Director, DirectorDetailViewModel>();
		CreateMap<CreateDirectorCommand.CreateDirectorViewModel, Director>();
		
		//Performer Mapping
		CreateMap<CreatePerformerViewModel, Performer>();
		CreateMap<Performer, PerformersViewModel>();
		CreateMap<Performer, PerformerDetailViewModel>()
		.ForMember(dest => dest.MoviesPlayed, opt => opt.MapFrom(src => src.PerformersJoints.Select(x => x.Movie.Name)));
		CreateMap<UpdatePerformerViewModel, Performer>();
		
		//Order Mapping
		CreateMap<CreateOrderViewModel, Order>();
		CreateMap<Order, OrdersViewModel>()
		.ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer.Name + " " + src.Customer.Surname))
		.ForMember(dest => dest.Movie, opt => opt.MapFrom(src => src.Movie.Name + " " + src.Movie.Price + "₺"));
		CreateMap<Order, OrderViewModel>()
		.ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer.Name + " " + src.Customer.Surname))
		.ForMember(dest => dest.Movie, opt => opt.MapFrom(src => src.Movie.Name))
		.ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Movie.Price + "₺"));
		
	}
}