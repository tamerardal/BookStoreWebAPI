using AutoMapper;

public class UpdateGenreCommand
{
	public int GenreId{ get; set; }
	public UpdateGenreViewModel Model { get; set; }
	private readonly IBookStoreDbContext _dbContext;
	private readonly IMapper _mapper;
	public UpdateGenreCommand(IBookStoreDbContext dbContext, IMapper mapper)
	{
		_dbContext = dbContext;
		_mapper = mapper;
	}
	
	public void Handle()
	{
		var genre = _dbContext.Genres.SingleOrDefault(g => g.Id == GenreId);
		
		if (genre is null)
			throw new InvalidOperationException("ID could not found!");
		if (_dbContext.Genres.Any(g => genre.Name.ToLower() == Model.Name.ToLower() && g.Id == GenreId))
			throw new InvalidOperationException("Genre name or ID is already existing.");

		_mapper.Map(Model, genre);
		
		_dbContext.SaveChanges();
	}
	public class UpdateGenreViewModel
	{
		public string Name { get; set; }
		public bool IsActive { get; set; }
	}
}