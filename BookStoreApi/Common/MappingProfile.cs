using AutoMapper;
using BookStoreApi.Applications.BookOperations.CreateBook;
using BookStoreApi.Applications.BookOperations.GetBookDetail;
using BookStoreApi.Applications.BookOperations.GetBooks;
using BookStoreApi.Applications.BookOperations.UpdateBook;

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