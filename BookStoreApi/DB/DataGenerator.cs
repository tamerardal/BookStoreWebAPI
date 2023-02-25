using Microsoft.EntityFrameworkCore;

public class DataGenerator
{
	public static void Initialize(IServiceProvider serviceProvider)
	{
		using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
		{
			if (context.Books.Any())
			{
				return ;
			}
			
			context.Genres.AddRange(
				new Genre
				{
					//Id = 1,
					Name = "Personal Growth",
				},
				new Genre
				{
					//Id = 2,
					Name = "Science Fiction",
				},
				new Genre
				{
					//Id = 3,
					Name = "Philosophy",
				}
			);
			
			context.Books.AddRange(
				new Book
				{
					//Id = 1,
					Title = "Book of 5 Rings",
					Author = "Miyamoto Musashi",
					GenreId = 5, //	Philosophy
					PageCount = 128,
					PublishDate = new DateTime(1645, 1, 1),
				},
				new Book
				{
					//Id = 2,
					Title = "Meditations",
					Author = "Marcus Aurelius",
					GenreId = 5, //	Philosophy
					PageCount = 112,
					PublishDate = new DateTime(54, 1, 1),
				},
				new Book
				{
					//Id = 3,
					Title = "Dune",
					Author = "Frank Herbert",
					GenreId = 2, //	Science-Fiction
					PageCount = 879,
					PublishDate = new DateTime(2001, 1, 1),
				}
			);
			
			context.SaveChanges();
		}
	}
}