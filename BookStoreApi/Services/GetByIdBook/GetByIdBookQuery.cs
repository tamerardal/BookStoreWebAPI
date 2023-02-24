public class GetByIdBookQuery
{
	private readonly BookStoreDbContext _dbContext;
	public GetByIdBookQuery(BookStoreDbContext dbContext)
	{
		_dbContext = dbContext;
	}
}

public class GetByIdBookModel
{
	public string? Title { get; set; }
	public string? Genre { get; set; }
	public string? Author { get; set; }
	public int PageCount { get; set; }
	public int PublishDate { get; set; }
}