public class UpdateBookCommand
{
	private readonly BookStoreDbContext _dbContext;
	public UpdateBookCommand(BookStoreDbContext dbContext)
	{
		_dbContext = dbContext;
	}
}

public class UpdateBookModel
{
	public string? Title { get; set; }
	public string? Genre { get; set; }
	public string? Author { get; set; }
	public int PageCount { get; set; }
	public int PublishDate { get; set; }
}