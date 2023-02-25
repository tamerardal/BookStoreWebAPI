using AutoMapper;
using BookStoreApi.Applications.BookOperations.Commands.CreateBook;
using BookStoreApi.Applications.BookOperations.Commands.GetBookDetail;
using BookStoreApi.Applications.BookOperations.Commands.GetBooks;
using BookStoreApi.Applications.BookOperations.Commands.UpdateBook;

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