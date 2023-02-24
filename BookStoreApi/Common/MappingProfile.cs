using AutoMapper;

namespace BookStoreApi.Common
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
			CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
			CreateMap<CreateBookCommand.CreateBookVModel, Book>();
			CreateMap<UpdateBookModel, Book>();
		}
	}
}