using AutoMapper;

namespace BookStoreApi.Applications.BookOperations.Commands.CreateBook
{
	public class CreateBookCommand
	{
		public CreateBookViewModel Model { get; set; }
		private readonly IBookStoreDbContext _dbContext;
		private readonly IMapper _mapper;
		public CreateBookCommand(IBookStoreDbContext dbContext, IMapper mapper)
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
			book = _mapper.Map<Book>(Model); 

			_dbContext.Books.Add(book);
			_dbContext.SaveChanges();

		}
		public class CreateBookViewModel
		{
			public string Title { get; set; }
			public int AuthorId { get; set; }
			public DateTime PublishDate { get; set; }
			public int GenreId { get; set; }
			public int PageCount { get; set; }
		}
	}
}