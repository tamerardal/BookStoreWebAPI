using AutoMapper;

public class GetGenresQuery
{
	private readonly BookStoreDbContext _dbContext;
	private readonly IMapper _mapper;

	public GetGenresQuery(BookStoreDbContext dbContext, IMapper mapper)
	{
		_dbContext = dbContext;
		_mapper = mapper;
	}

	public List<GenreViewModel> Handle()
	{
		var genreList = _dbContext.Genres.Where(g => g.IsActive == true).OrderBy(g => g.Name).ToList();
		List<GenreViewModel> viewModel = _mapper.Map<List<GenreViewModel>>(genreList);
		
		return viewModel;
	}
	
	public class GenreViewModel
	{
		public int GenreId { get; set; }
		public string? Name { get; set; }
	}
}