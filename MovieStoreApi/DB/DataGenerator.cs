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
		  		new Director{Name = "Akira", Surname = "Kurosawa"},
				new Director{Name = "Francis Ford", Surname = "Copppola"});


			context.Performers.AddRange(
		  		new Performer{Name = "Robert", Surname = "DeNiro"},
		  		new Performer{Name = "Jack", Surname = "Nicholson"},
		  		new Performer{Name = "Marlon", Surname = "Brando"},
		  		new Performer{Name = "Al", Surname = "Pacino"},
		  		new Performer{Name = "Katharine", Surname = "Hepburn"},
		  		new Performer{Name = "Humphrey", Surname = "Bogart"},
		  		new Performer{Name = "Meryl", Surname = "Streep"},
		  		new Performer{Name = "Denzel", Surname = "Washington"},
		  		new Performer{Name = "Sidney", Surname = "Poitier"},
		  		new Performer{Name = "Clark", Surname = "Geble"},
		  		new Performer{Name = "Ingrid", Surname = "Bergman"},
		  		new Performer{Name = "Tom", Surname = "Hanks"},
		  		new Performer{Name = "Elizabeth", Surname = "Taylor"},
		  		new Performer{ Name = "Bette", Surname = "Davis"});

			context.Movies.AddRange(
				new Movie{
					Name = "The Godfather", 
					GenreId = 6, DirectorId = 7, Price = 30,
					ReleaseDate = new DateTime(1972, 1, 1),
					},
				new Movie{
					Name = "The Godfather 2", 
					GenreId = 6, DirectorId = 7, Price = 30,
					ReleaseDate = new DateTime(1974, 1, 1), 
					},
				new Movie{
					Name = "Citizen Kane", 
					GenreId = 3, DirectorId = 2, Price = 20,
					ReleaseDate = new DateTime(1941, 1, 1), 
					},
				new Movie{
					Name = "La Dolce Vita", 
					GenreId = 7, DirectorId = 3, Price = 10,
					ReleaseDate = new DateTime(1960,1 ,1), 
					},
				new Movie{
					Name = "Seven Samurai", 
					GenreId = 1, DirectorId = 4, Price = 40,
					ReleaseDate = new DateTime(1954, 1, 1), 
					},
				new Movie{
					Name = "There Will Be Blood", 
					GenreId = 3, DirectorId = 5, Price = 25,
					ReleaseDate = new DateTime(2007, 1 ,1), 
					},
				new Movie{
					Name = "Singing in the Rain", 
					GenreId = 5, DirectorId = 6, Price = 15,
					ReleaseDate = new DateTime(1952, 1, 1), 
					}
			);
			context.Customers.AddRange(
				new Customer
				{
					Name = "Tamer",
					Surname = "Ardal",
					Email = "tamerardal@ardal.com",
					Password = "123456",
				}
			);
			context.PerformersJoint.AddRange(
				new PerformersJoint
				{
					MovieId = 1,
					PerformerId = 3
				},
				new PerformersJoint
				{
					MovieId = 2,
					PerformerId = 4
				},
				new PerformersJoint
				{
					MovieId = 2,
					PerformerId = 1
				},
				new PerformersJoint
				{
					MovieId = 1,
					PerformerId = 4
				},
				new PerformersJoint
				{
					MovieId = 2,
					PerformerId = 7
				},
				new PerformersJoint
				{
					MovieId = 3,
					PerformerId = 5
				},
				new PerformersJoint
				
				{
					MovieId = 1,
					PerformerId = 1,
				}
			);

				context.SaveChanges();
		}
	}
}