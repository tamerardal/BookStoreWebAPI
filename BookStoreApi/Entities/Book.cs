using System.ComponentModel.DataAnnotations.Schema;

public class Book
{
	public string? Title { get; set; }

	[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }
	public string? Author { get; set; }
	public int GenreId { get; set; }
	public int PageCount { get; set; }
	public DateTime PublishDate { get; set; }
	
}