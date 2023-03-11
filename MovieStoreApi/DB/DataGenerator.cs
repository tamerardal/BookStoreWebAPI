using Microsoft.EntityFrameworkCore;

public class DataGenerator
{
	public static void Initialize(IServiceProvider serviceProvider)
	{
		using (var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
		{
			if (context.Movies.Any())
			{
				return ;
			}
			
			context.Genres.AddRange(
				new Genre{Name = "Action"},
				new Genre{Name = "Comedy"},
				new Genre{Name = "Drama"},
				new Genre{Name = "Fantasy"},
				new Genre{Name = "Horror"},
				new Genre{Name = "Mystery"},
				new Genre{Name = "Romance"}
		  	);
 

			context.Directors.AddRange(
				new Director{Name = "Alfred", Surname = "Hitchcock"},
		  		new Director{Name = "John", Surname = "Ford"},
		  		new Director{Name = "Howard", Surname = "Hawks"},
		  		new Director{Name = "Martin", Surname = "Scorsese"},
		  		new Director{Name = "Orson", Surname = "Welles"},
		  		new Director{ Name = "Akira", Surname = "Kurosawa"});


			context.Performers.AddRange(
		  		new Performer{Name = "Robert", Surname = "DeNiro"},
		  		new Performer{Name = "Jack", Surname = "Nicholson"},
		  		new Performer{Name = "Marlon", Surname = "Brando"},
		  		new Performer{Name = "Denzel", Surname = "Washington"},
		  		new Performer{Name = "Katharine", Surname = "Hepburn"},
		  		new Performer{Name = "Humphrey", Surname = "Bogart"},
		  		new Performer{Name = "Meryl", Surname = "Streep"},
		  		new Performer{Name = "Daniel", Surname = "DayLewis"},
		  		new Performer{Name = "Sidney", Surname = "Poitier"},
		  		new Performer{Name = "Clark", Surname = "Geble"},
		  		new Performer{Name = "Ingrid", Surname = "Bergman"},
		  		new Performer{Name = "Tom", Surname = "Hanks"},
		  		new Performer{Name = "Elizabeth", Surname = "Taylor"},
		  		new Performer{ Name = "Bette", Surname = "Davis"});

			context.Movies.AddRange(
				new Movie{
					Name = "The Godfater", 
					GenreId = 6, DirectorId = 1, Price = 30,
					ReleaseDate = new DateTime(1972), 
					Performers = "Marlon Brando"},
				new Movie{
					Name = "Citizen Kane", 
					GenreId = 3, DirectorId = 2, Price = 20,
					ReleaseDate = new DateTime(1941), 
					Performers = "Orson Welles"},
				new Movie{
					Name = "La Dolce Vita", 
					GenreId = 7, DirectorId = 3, Price = 10,
					ReleaseDate = new DateTime(1960), 
					Performers = "Ingrid Bergman"},
				new Movie{
					Name = "Seven Samurai", 
					GenreId = 1, DirectorId = 4, Price = 40,
					ReleaseDate = new DateTime(1954), 
					Performers = "Akira Kurosawa"},
				new Movie{
					Name = "There Will Be Blood", 
					GenreId = 3, DirectorId = 5, Price = 25,
					ReleaseDate = new DateTime(2007), 
					Performers = "Daniel Daylewis"},
				new Movie{
					Name = "Singing in the Rain", 
					GenreId = 5, DirectorId = 6, Price = 15,
					ReleaseDate = new DateTime(1952), 
					Performers = "Ingrid Bergman"}
			);
			context.Customers.AddRange(
				new Customer
				{
					Name = "Tamer",
					Surname = "Ardal",
					Email = "tamerardal@ardal.com",
					Password = "123456",
					PurchasesFilmId = 1,
					FavGenreId = 3,
				},
				new Customer
				{
					Name = "Ali",
					Surname = "Veli",
					Email = "aliveli@ardal.com",
					Password = "asdfgh",
					PurchasesFilmId = 5,
					FavGenreId = 1,
				}
			);

				context.SaveChanges();
		}
	}
}