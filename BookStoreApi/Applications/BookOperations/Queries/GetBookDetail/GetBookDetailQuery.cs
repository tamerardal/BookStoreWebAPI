using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Applications.BookOperations.Commands.GetBookDetail
{
	public class GetBookDetailQuery
	{
		public BookDetailViewModel Model { get; set; }
		public int BookId { get; set; }

		private readonly IBookStoreDbContext _dbContext;
		private readonly IMapper _mapper;
		public GetBookDetailQuery(IBookStoreDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}
		public BookDetailViewModel Handle()
		{
			var book = _dbContext.Books.Include(g => g.Genre).Include(a => a.Author).Where(book => book.Id == BookId).SingleOrDefault();
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
		public string Title { get; set; }
		public string Genre { get; set; }
		public string AuthorName { get; set; }
		public string AuthorSurname { get; set; }
		public int PageCount { get; set; }
		public string PublishDate { get; set; }
	}
}