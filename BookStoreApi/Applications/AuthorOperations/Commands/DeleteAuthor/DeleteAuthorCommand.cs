public class DeleteAuthorCommand
{
	public int AuthorId { get; set; }
	private readonly BookStoreDbContext _dbContext;

	public DeleteAuthorCommand(BookStoreDbContext dbContext)
	{
		_dbContext = dbContext;
	}
	public void Handle()
	{
		var author = _dbContext.Authors.SingleOrDefault(a => a.Id == AuthorId);
		
		if (author is null)
			throw new InvalidOperationException("ID isn't found.");
			
		_dbContext.Authors.Remove(author);
		_dbContext.SaveChanges();
	}
}