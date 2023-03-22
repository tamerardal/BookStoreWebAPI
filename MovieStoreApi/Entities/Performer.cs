using System.ComponentModel.DataAnnotations.Schema;

public class Performer
{
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }
	public string Name { get; set; }
	public string Surname { get; set; }
	public virtual ICollection<PerformersJoint> PerformersJoints { get; set; }
	public bool IsActive { get; set; }
}