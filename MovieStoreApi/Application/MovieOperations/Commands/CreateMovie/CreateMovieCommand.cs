using AutoMapper;

public class CreateMovieCommand
{
	public CreateMovieViewModel Model { get; set; }
	private readonly IMovieStoreDbContext _context;
	private readonly IMapper _mapper;

	public CreateMovieCommand(IMovieStoreDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}
	public void Handle()
	{
		var movie = _context.Movies.SingleOrDefault(m => m.Name == Model.Name);
		
		if (movie is not null)
			throw new InvalidOperationException("Movie is already added!");
		
		movie = _mapper.Map<Movie>(Model);
		
		_context.Movies.Add(movie);
		_context.SaveChanges();
	}
	public class CreateMovieViewModel
	{
		public string Name { get; set; }
		public DateTime ReleaseDate { get; set; }
		public int GenreId { get; set; }
		public int DirectorId { get; set; }
		public double Price { get; set; }
	}
}