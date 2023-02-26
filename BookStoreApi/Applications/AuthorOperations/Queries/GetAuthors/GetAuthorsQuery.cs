using AutoMapper;

public class GetAuthorsQuery
{
	private readonly BookStoreDbContext _dbContext;
	private readonly IMapper _mapper;

	public GetAuthorsQuery(BookStoreDbContext dbContext, IMapper mapper)
	{
		_dbContext = dbContext;
		_mapper = mapper;
	}
	
	public List<GetAuthorsViewModel> Handle()
	{
		var authorList = _dbContext.Authors.OrderBy(a => a.Id).ToList();
		
		List<GetAuthorsViewModel> viewModel = _mapper.Map<List<GetAuthorsViewModel>>(authorList);
		
		return viewModel;
	}
	
	public class GetAuthorsViewModel
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Birthday { get; set; }
	}
}