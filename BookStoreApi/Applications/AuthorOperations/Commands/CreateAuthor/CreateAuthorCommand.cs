using AutoMapper;

public class CreateAuthorCommand
{
	public CreateAuthorViewModel Model { get; set; }
	private readonly BookStoreDbContext _dbContext;
	private readonly IMapper _mapper;

	public CreateAuthorCommand(BookStoreDbContext dbContext, IMapper mapper)
	{
		_dbContext = dbContext;
		_mapper = mapper;
	}
	
	public void Handle()
	{
		var author = _dbContext.Authors.SingleOrDefault(a => a.Name == Model.Name);
		
		if (author is not null)
			throw new InvalidOperationException("Author is already added.");
		
		author = _mapper.Map<Author>(Model);
		
		_dbContext.Add(author);
		_dbContext.SaveChanges();
		
	}
	
	public class CreateAuthorViewModel
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public DateTime Birthday { get; set; }
	}
}

