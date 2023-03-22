using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class GetMoviesQuery
{
	private readonly IMovieStoreDbContext _context;
	private readonly IMapper _mapper;

	public GetMoviesQuery(IMovieStoreDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}
	public List<MoviesViewModel> Handle()
	{
		var movies = _context.Movies.Include(g => g.Genre).Include(d => d.Director).OrderBy(m => m.Id).ToList<Movie>();
		List<MoviesViewModel> viewModels = _mapper.Map<List<MoviesViewModel>>(movies);

		return viewModels;
	}
	public class MoviesViewModel
	{
		public string Name { get; set; }
		public string Genre { get; set; }
		public string Director { get; set; }
	}
}