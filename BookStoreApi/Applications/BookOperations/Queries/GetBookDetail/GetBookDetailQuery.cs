using AutoMapper;

namespace BookStoreApi.Applications.BookOperations.Commands.GetBookDetail
{
	public class GetBookDetailQuery
	{
		public BookDetailViewModel Model { get; set; }
		public int BookId { get; set; }

		private readonly BookStoreDbContext _dbContext;
		private readonly IMapper _mapper;
		public GetBookDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}
		public BookDetailViewModel Handle()
		{
			var book = _dbContext.Books.SingleOrDefault(book => book.Id == BookId);
			if (book is null)
			{
				throw new InvalidOperationException("ID's not correct!");
			}
			BookDetailViewModel vm = _mapper.Map<BookDetailViewModel>(book);

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
}