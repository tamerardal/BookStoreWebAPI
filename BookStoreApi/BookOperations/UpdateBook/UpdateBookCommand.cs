using AutoMapper;

namespace BookStoreApi.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int BookId { get; set; }
        public UpdateBookViewModel Model;
        public UpdateBookCommand(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(book => book.Id == BookId);

            if (book is null)
                throw new InvalidOperationException("Book doesn't exist!");


            _mapper.Map(Model, book);
            // book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            // book.Author = Model.Author != default ? Model.Author : book.Author;
            // book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount;
            // book.Title = Model.Title != default ? Model.Title : book.Title;
            // book.PublishDate = Model.PublishDate != default ? Model.PublishDate : book.PublishDate;

            _dbContext.SaveChanges();

        }
    }

    public class UpdateBookViewModel
    {
        public string? Title { get; set; }
        public int GenreId { get; set; }
        public string? Author { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}