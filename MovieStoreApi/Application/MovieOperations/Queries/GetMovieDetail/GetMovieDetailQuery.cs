using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class GetMovieDetailQuery
{
	public int MovieId { get; set; }
	public MovieDetailViewModel Model { get; set; }
	private readonly IMovieStoreDbContext _context;
	private readonly IMapper _mapper;

	public GetMovieDetailQuery(IMovieStoreDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}
	
	public MovieDetailViewModel Handle()
	{
		var movie = _context.Movies.Include(g => g.Genre).Include(d => d.Director).Include(p => p.PerformersJoint).ThenInclude(p => p.Performer).SingleOrDefault(m => m.Id == MovieId);
		
		if (movie is null)
			throw new InvalidOperationException("ID's not correct!");
		
		return _mapper.Map<MovieDetailViewModel>(movie);
	}
	public class MovieDetailViewModel
	{
		public string Name { get; set; }
		public string ReleaseDate { get; set; }
		public string Genre { get; set; }
		public string Director { get; set; }
		public List<string> Performers { get; set; }
		public double Price { get; set; }
		public string IsActive { get; set; }
	}
}