public class Customer
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Surname { get; set; }
	public List<Movie> PurchasesFilms { get; set; }
	public List<Genre> FavGenres { get; set; }
}