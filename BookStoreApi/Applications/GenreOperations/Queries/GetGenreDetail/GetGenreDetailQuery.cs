using AutoMapper;

public class GetGenreDetailQuery
{
	public GenreDetailViewModel Model { get; set; }
	public int GenreId { get; set; }
	private readonly IBookStoreDbContext _dbContext;
	private readonly IMapper _mapper;

	public GetGenreDetailQuery(IBookStoreDbContext dbContext, IMapper mapper)
	{
		_dbContext = dbContext;
		_mapper = mapper;
	}

	public GenreDetailViewModel Handle()
	{
		var genre = _dbContext.Genres.SingleOrDefault(g => g.Id == GenreId);
		
		if (genre is null)
			throw new InvalidOperationException("ID is not found!");
		
		GenreDetailViewModel viewModel = _mapper.Map<GenreDetailViewModel>(genre);
		
		return viewModel;
	}
	
	public class GenreDetailViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}