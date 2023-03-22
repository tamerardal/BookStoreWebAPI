using AutoMapper;

public class GetDirectorDetailQuery
{
	public int DirectorId { get; set; }
	public DirectorDetailViewModel Model { get; set; }
	private readonly IMovieStoreDbContext _context;
	private readonly IMapper _mapper;

	public GetDirectorDetailQuery(IMovieStoreDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}
	
	public DirectorDetailViewModel Handle()
	{
		var director = _context.Directors.SingleOrDefault(d => d.Id == DirectorId);
		
		if (director is null)
			throw new InvalidOperationException("Director ID couldn't found!");
			
		return _mapper.Map<DirectorDetailViewModel>(director);
	}
	
	public class DirectorDetailViewModel
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		//public string FilmsDirecting { get; set; }
	}
}