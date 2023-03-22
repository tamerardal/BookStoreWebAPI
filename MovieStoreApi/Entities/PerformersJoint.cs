using System.ComponentModel.DataAnnotations.Schema;

public class PerformersJoint
{
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }
	public int PerformerId { get; set; }
	public Performer Performer { get; set; }
	public int MovieId { get; set; }
	public Movie Movie { get; set; }
}