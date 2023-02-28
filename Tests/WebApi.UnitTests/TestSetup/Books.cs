public static class Books
{
	public static void AddBooks(this BookStoreDbContext context)
	{
		context.Books.AddRange(
			new Book{Title = "Book of 5 Rings",AuthorId = 1,GenreId = 3,PageCount = 128,PublishDate = new DateTime(1645, 1, 1),},
			new Book{Title = "Meditations", AuthorId = 2, GenreId = 3, PageCount = 112, PublishDate = new DateTime(54, 1, 1),},
			new Book{Title = "Dune", AuthorId = 3, GenreId = 2, PageCount = 879, PublishDate = new DateTime(2001, 1, 1),}
		);
	}
}