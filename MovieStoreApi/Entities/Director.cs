using System.ComponentModel.DataAnnotations.Schema;

public class Director
{
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }
	public string Name { get; set; }
	public string Surname { get; set; }
	public string FilmsDirecting { get; set; }
	public bool IsActive { get; set; }
}