using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class GetPerformerDetailQuery
{
	public int PerformerId { get; set; }
	public PerformerDetailViewModel Model { get; set; }
	private readonly IMovieStoreDbContext _context;
	private readonly IMapper _mapper;

	public GetPerformerDetailQuery(IMovieStoreDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}
	
	public PerformerDetailViewModel Handle()
	{
		var performer = _context.Performers.Include(p => p.PerformersJoints).ThenInclude(p => p.Movie).SingleOrDefault(p => p.Id == PerformerId);
		
		if (performer is null)
			throw new InvalidOperationException("ID is couldn't found!");
			
		return _mapper.Map<PerformerDetailViewModel>(performer);
	}

	public class PerformerDetailViewModel
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public List<string> MoviesPlayed { get; set; }
	}
}