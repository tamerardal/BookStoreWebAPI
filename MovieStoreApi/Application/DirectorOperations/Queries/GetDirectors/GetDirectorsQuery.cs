using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class GetDirectorsQuery
{
	private readonly IMovieStoreDbContext _context;
	private readonly IMapper _mapper;

	public GetDirectorsQuery(IMovieStoreDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}
	public List<DirectorsViewModel> Handle()
	{
		var directors = _context.Directors.ToList();
		
		return _mapper.Map<List<DirectorsViewModel>>(directors);
	}
	public class DirectorsViewModel
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		//public string FilmsDirecting { get; set; }
	}
}