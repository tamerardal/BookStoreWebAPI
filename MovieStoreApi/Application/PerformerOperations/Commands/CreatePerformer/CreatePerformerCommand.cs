using AutoMapper;

public class CreatePerformerCommand
{
	public CreatePerformerViewModel Model { get; set; }
	private readonly IMovieStoreDbContext _context;
	private readonly IMapper _mapper;

	public CreatePerformerCommand(IMovieStoreDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}
	
	public void Handle()
	{
		var performer = _context.Performers.SingleOrDefault(p => p.Name == Model.Name);
		
		if (performer is not null)
			throw new InvalidOperationException("Performer is already added!");
			
		performer = _mapper.Map<Performer>(Model);
		
		_context.Performers.Add(performer);
		_context.SaveChanges();
	}

	public class CreatePerformerViewModel
	{
		public string Name { get; set; }
		public string Surname { get; set; }
	}
}