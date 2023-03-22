using AutoMapper;

public class DeletePerformerCommand
{
	public int PerformerId { get; set; }
	private readonly IMovieStoreDbContext _context;

	public DeletePerformerCommand(IMovieStoreDbContext context)
	{
		_context = context;
	}
	
	public void Handle()
	{
		var performer = _context.Performers.SingleOrDefault(p => p.Id == PerformerId);
		
		if (performer is null)
			throw new InvalidOperationException("ID's couldn't found!");
			
		_context.Performers.Remove(performer);
		_context.SaveChanges();
	}
}