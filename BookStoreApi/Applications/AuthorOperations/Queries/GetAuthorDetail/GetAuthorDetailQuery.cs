using AutoMapper;

public class GetAuthorDetailQuery
{
	public int AuthorId { get; set; }
	private readonly BookStoreDbContext _dbContext;
	private readonly IMapper _mapper;

	public GetAuthorDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
	{
		_dbContext = dbContext;
		_mapper = mapper;
	}
	
	public GetAuthorDetailViewModel Handle()
	{
		var author = _dbContext.Authors.SingleOrDefault(a => a.Id == AuthorId);
		
		if (author is null)
			throw new InvalidOperationException("ID is not correct!");
		
		GetAuthorDetailViewModel vm = _mapper.Map<GetAuthorDetailViewModel>(author);
		
		
		return vm;
	}
	
	public class GetAuthorDetailViewModel
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Birthday { get; set; }
	}
}