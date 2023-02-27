using AutoMapper;

public class UpdateAuthorCommand
{
	public int AuthorId { get; set; }
	public UpdateAuthorViewModel Model { get; set; }
	
	private readonly IBookStoreDbContext _dbContext;
	private readonly IMapper _mapper;

	public UpdateAuthorCommand(IBookStoreDbContext dbContext, IMapper mapper)
	{
		_dbContext = dbContext;
		_mapper = mapper;
	}
	
	public void Handle()
	{
		var author = _dbContext.Authors.SingleOrDefault(a => a.Id == AuthorId);
		
		if (author is null)
			throw new InvalidOperationException("ID is not correct.");
		
		_mapper.Map(Model, author);
		
		_dbContext.SaveChanges();
	}

	public class UpdateAuthorViewModel
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public DateTime Birthday { get; set; }
	}
}

