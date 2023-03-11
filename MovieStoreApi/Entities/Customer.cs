public class Customer
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Surname { get; set; }
	public string Email { get; set; }
	public string Password { get; set; }
	public Movie PurchasesFilm { get; set; }	
	public int PurchasesFilmId { get; set; }
	public Genre FavGenre { get; set; }
	public int FavGenreId { get; set; }
}