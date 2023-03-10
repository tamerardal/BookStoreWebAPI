public class DeleteMovieCommand
{
	public int MovieId { get; set; }
	private readonly IMovieStoreDbContext _context;

	public DeleteMovieCommand(IMovieStoreDbContext context)
	{
		_context = context;
	}
	
	public void Handle()
	{
		var movie = _context.Movies.SingleOrDefault(m => m.Id == MovieId);
		if (movie is null)
			throw new InvalidOperationException("Movie couldn't found!");
			
		_context.Movies.Remove(movie);
		_context.SaveChanges();
	}	
}