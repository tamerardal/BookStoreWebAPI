using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

public class CreateBookCommand
{
	public CreateBookVModel Model { get; set; }
	private readonly BookStoreDbContext _dbContext;
	private readonly IMapper _mapper;
	public CreateBookCommand(BookStoreDbContext dbContext, IMapper mapper)
	{
		_dbContext = dbContext;
		_mapper = mapper;
	}
	public void Handle()
	{
		var book = _dbContext.Books.SingleOrDefault(x => x.Title == Model.Title);
		if (book is not null)
		{
			throw new InvalidOperationException("Book is already added!");
		}
		book = _mapper.Map<Book>(Model); //new Book();
		// book.Title = Model.Title;
		// book.Author = Model.Author;
		// book.GenreId = Model.GenreId;
		// book.PublishDate = Model.PublishDate;
		// book.PageCount = Model.PageCount;
		
		_dbContext.Books.Add(book);
		_dbContext.SaveChanges();

	}
	public class CreateBookVModel
	{
		public string? Title { get; set; }
		public string? Author { get; set; }
		public DateTime PublishDate { get; set; }
		public int GenreId { get; set; }
		public int PageCount { get; set; }
	}
}