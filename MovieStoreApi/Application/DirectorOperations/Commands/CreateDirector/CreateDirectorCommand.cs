using AutoMapper;

public class CreateDirectorCommand
{
	public CreateDirectorViewModel Model { get; set; }
	private readonly IMovieStoreDbContext _context;
	private readonly IMapper _mapper;

	public CreateDirectorCommand(IMovieStoreDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}
	
	public void Handle()
	{
		var director = _context.Directors.SingleOrDefault(d => d.Name == Model.Name);
		
		if(director is not null)
			throw new InvalidOperationException("Director is already added.");
			
		director = _mapper.Map<Director>(Model);
		
		_context.Directors.Add(director);
		_context.SaveChanges();
	}

	public class CreateDirectorViewModel
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string FilmsDirecting { get; set; }
	}
}