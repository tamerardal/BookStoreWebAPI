using AutoMapper;

public class DeleteDirectorCommand
{
	public int DirectorId { get; set; }
	private readonly IMovieStoreDbContext _context;

	public DeleteDirectorCommand(IMovieStoreDbContext context)
	{
		_context = context;
	}
	
	public void Handle()
	{
		var director = _context.Directors.SingleOrDefault(d => d.Id == DirectorId);
		
		if(director is null)
			throw new InvalidOperationException("Director ID couldn't found!");
			
		_context.Directors.Remove(director);
		_context.SaveChanges();
	}
}