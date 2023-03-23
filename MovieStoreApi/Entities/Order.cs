using System.ComponentModel.DataAnnotations.Schema;

public class Order
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public DateTime TransactionTime { get; set; }
		public int CustomerId { get; set; }
		public Customer Customer { get; set; }
		public int MovieId { get; set; }
		public Movie Movie { get; set; }
		public bool IsActive { get; set; }
	}