public class GetBookDetailQuery
{
	public BookDetailViewModel Model { get; set; }
	public int BookId { get; set; }
	
	private readonly BookStoreDbContext _dbContext;
	public GetBookDetailQuery(BookStoreDbContext dbContext)
	{
		_dbContext = dbContext;
	}
	public BookDetailViewModel Handle()
	{
		var book = _dbContext.Books.SingleOrDefault(book => book.Id == BookId);
		if (book is null)
		{
			throw new InvalidOperationException("ID's not correct!");
		}
		BookDetailViewModel vm = new BookDetailViewModel();
		
		vm.Title = book.Title;
		vm.Author = book.Author;
		vm.Genre = ((GenreEnum)book.GenreId).ToString();
		vm.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy");
		vm.PageCount = book.PageCount;
		
		return vm;
		
	}
}

public class BookDetailViewModel
{
	public string? Title { get; set; }
	public string? Genre { get; set; }
	public string? Author { get; set; }
	public int PageCount { get; set; }
	public string? PublishDate { get; set; }
}