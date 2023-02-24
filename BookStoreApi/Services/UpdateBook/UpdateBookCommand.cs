public class UpdateBookCommand
{
	private readonly BookStoreDbContext _dbContext;
	public int BookId { get; set; }
	public UpdateBookModel Model;
	public UpdateBookCommand(BookStoreDbContext dbContext)
	{
		_dbContext = dbContext;
	}
	public void Handle()
	{
		var book = _dbContext.Books.SingleOrDefault(book => book.Id == BookId);
		
		if (book is null)
		{
			throw new InvalidOperationException("Book doesn't exist!");
		}
		
		book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
		book.Author = Model.Author != default ? Model.Author : book.Author;
		book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount;
		book.Title = Model.Title != default ? Model.Title : book.Title;
		book.PublishDate = Model.PublishDate != default ? Model.PublishDate : book.PublishDate;
			
		_dbContext.SaveChanges();

	}
}

public class UpdateBookModel
{
	public string? Title { get; set; }
	public int GenreId { get; set; }
	public string? Author { get; set; }
	public int PageCount { get; set; }
	public DateTime PublishDate { get; set; }
}