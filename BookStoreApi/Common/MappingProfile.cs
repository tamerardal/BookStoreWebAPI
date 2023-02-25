using AutoMapper;
using BookStoreApi.BookOperations.CreateBook;
using BookStoreApi.BookOperations.GetBookDetail;
using BookStoreApi.BookOperations.GetBooks;
using BookStoreApi.BookOperations.UpdateBook;

namespace BookStoreApi.Common
{
    public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
			CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
			CreateMap<CreateBookCommand.CreateBookViewModel, Book>();
			CreateMap<UpdateBookViewModel, Book>();
		}
	}
}