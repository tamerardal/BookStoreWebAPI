using AutoMapper;
using BookStoreApi.Applications.BookOperations.Commands.CreateBook;
using BookStoreApi.Applications.BookOperations.Commands.GetBookDetail;
using BookStoreApi.Applications.BookOperations.Commands.GetBooks;
using BookStoreApi.Applications.BookOperations.Commands.UpdateBook;
using static CreateGenreCommand;
using static GetGenreDetailQuery;
using static GetGenresQuery;
using static UpdateGenreCommand;
using static GetAuthorsQuery;
using static GetAuthorDetailQuery;
using static CreateAuthorCommand;
using static UpdateAuthorCommand;

namespace BookStoreApi.Common
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
			CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
			CreateMap<CreateBookCommand.CreateBookViewModel, Book>();
			CreateMap<UpdateBookViewModel, Book>();
			
			CreateMap<Genre, GenreViewModel>();
			CreateMap<Genre, GenreDetailViewModel>();
			CreateMap<CreateGenreViewModel, Genre>();
			CreateMap<UpdateGenreViewModel, Genre>();
			
			CreateMap<Author, AuthorsViewModel>();
			CreateMap<Author, AuthorDetailViewModel>();
			CreateMap<CreateAuthorViewModel, Author>();
			CreateMap<UpdateAuthorViewModel, Author>();
			
			CreateMap<CreateUserViewModel, User>();
		}
	}
}