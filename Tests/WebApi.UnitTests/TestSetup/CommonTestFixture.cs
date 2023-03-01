using AutoMapper;
using BookStoreApi.Common;
using Microsoft.EntityFrameworkCore;

public class CommonTestFixture
{
	public BookStoreDbContext Context { get; set; }
	public IMapper Mapper { get; set; }
	public CommonTestFixture()
	{
		
		var options = new DbContextOptionsBuilder<BookStoreDbContext>().UseInMemoryDatabase("BookStoreTestDB").Options;
		Context = new BookStoreDbContext(options);
		
		Context.Database.EnsureCreated();
		
		Context.AddBooks();
		Context.AddGenres();
		Context.AddAuthors();
		Context.SaveChanges();
		
		Mapper = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); }).CreateMapper();
	}	
}