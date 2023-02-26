using System.ComponentModel.DataAnnotations.Schema;

public class Author
{
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }
	public string Name { get; set; }
	public string Surname { get; set; }
	public DateTime Birthday { get; set; }
}