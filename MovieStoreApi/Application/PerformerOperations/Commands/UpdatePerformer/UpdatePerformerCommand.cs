using AutoMapper;

public class UpdatePerformerCommand
{
	public int PerformerId { get; set; }
	public UpdatePerformerViewModel Model { get; set; }
	
	private readonly IMovieStoreDbContext _context;
	private readonly IMapper _mapper;

	public UpdatePerformerCommand(IMovieStoreDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}
	
	public void Handle()
	{
		var performer = _context.Performers.SingleOrDefault(p => p.Id == PerformerId);
		
		if (performer is null)
			throw new InvalidOperationException("ID's couldn't found!");
			
		_mapper.Map(Model, performer);
		_context.SaveChanges();
	}

	public class UpdatePerformerViewModel
	{
		public string Name { get; set; }
		public string Surname { get; set; }
	}
}