using AutoMapper;

public class UpdateMovieCommand
{
	public int MovieId { get; set; }
	public UpdateMovieViewModel Model { get; set; }
	private readonly IMovieStoreDbContext _context;
	private readonly IMapper _mapper;

	public UpdateMovieCommand(IMovieStoreDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}
	
	public void Handle()
	{
		var movie = _context.Movies.SingleOrDefault(m => m.Id == MovieId);
		if (movie is null)
			throw new InvalidOperationException("Movie couldn't found!");
	
		_mapper.Map(Model, movie);

		_context.SaveChanges();
	}
}

public class UpdateMovieViewModel
{
	public string Name { get; set; }
	public DateTime ReleaseDate { get; set; }
	public int GenreId { get; set; }
	public int DirectorId { get; set; }
	public string Performers { get; set; }
	public double Price { get; set; }
}