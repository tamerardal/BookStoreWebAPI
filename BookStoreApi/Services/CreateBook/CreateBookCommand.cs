using Microsoft.AspNetCore.Mvc;

public class CreateBookCommand
{
	public CreateBookModel Model { get; set; }
	private readonly BookStoreDbContext _dbContext;
	
	public CreateBookCommand(BookStoreDbContext dbContext)
	{
		_dbContext = dbContext;
	}
	public void Handle()
	{
		var book = _dbContext.Books.SingleOrDefault(x => x.Title == Model.Title);
		if (book is not null)
		{
			throw new InvalidOperationException("Book is already added!");
		}
		book = new Book();
		book.Title = Model.Title;
		book.Author = Model.Author;
		book.GenreId = Model.GenreId;
		book.PublishDate = Model.PublishDate;
		book.PageCount = Model.PageCount;
		
		_dbContext.Books.Add(book);
		_dbContext.SaveChanges();

	}
	public class CreateBookModel
	{
		public string? Title { get; set; }
		public string? Author { get; set; }
		public DateTime PublishDate { get; set; }
		public int GenreId { get; set; }
		public int PageCount { get; set; }
	}
}