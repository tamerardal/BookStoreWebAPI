using AutoMapper;

public class CreateGenreCommand
{
	public CreateGenreViewModel Model { get; set; }
	private readonly IBookStoreDbContext _dbContext;
	private readonly IMapper _mapper;
	public CreateGenreCommand(IBookStoreDbContext dbContext, IMapper mapper)
	{
		_dbContext = dbContext;
		_mapper = mapper;
	}
	public void Handle()
	{
		var genre = _dbContext.Genres.SingleOrDefault(g => g.Name == Model.Name);
		
		if (genre is not null)
			throw new InvalidOperationException("Genre is already added!");
		
		genre = _mapper.Map<Genre>(Model);
		
		_dbContext.Genres.Add(genre);
		_dbContext.SaveChanges();
	}
	public class CreateGenreViewModel
	{
		public string Name { get; set; }
		public bool IsActive { get; set; }
	}
}