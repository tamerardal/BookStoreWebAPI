using AutoMapper;

public class GetPerformersQuery
{
	private readonly IMovieStoreDbContext _context;
	private readonly IMapper _mapper;

	public GetPerformersQuery(IMovieStoreDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}
	
	public List<PerformersViewModel> Handle()
	{
		var performers = _context.Performers.OrderBy(p => p.Id).ToList();
		
		List<PerformersViewModel> vm = _mapper.Map<List<PerformersViewModel>>(performers);

		return vm;
	}
	
	public class PerformersViewModel
	{
		public string Name { get; set; }
		public string Surname { get; set; }
	}	
}