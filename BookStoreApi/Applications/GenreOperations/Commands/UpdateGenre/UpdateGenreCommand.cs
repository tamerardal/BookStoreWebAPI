using AutoMapper;

public class UpdateGenreCommand
{
	public int GenreId{ get; set; }
	public UpdateGenreViewModel Model { get; set; }
	private readonly BookStoreDbContext _dbContext;
	private readonly IMapper _mapper;
	public UpdateGenreCommand(BookStoreDbContext dbContext, IMapper mapper)
	{
		_dbContext = dbContext;
		_mapper = mapper;
	}
	
	public void Handle()
	{
		var genre = _dbContext.Genres.SingleOrDefault(g => g.Id == GenreId);
		
		if (genre is null)
			throw new InvalidOperationException("ID could not found!");
		
		_mapper.Map(Model, genre);
		
		_dbContext.SaveChanges();
	}
	public class UpdateGenreViewModel
	{
		public string? Name { get; set; }
		public bool IsActive { get; set; }
	}
}