using AutoMapper;

public class DeleteCustomerCommand
{
	public int CustomerId { get; set; }
	private readonly IMovieStoreDbContext _context;

	public DeleteCustomerCommand(IMovieStoreDbContext context)
	{
		_context = context;
	}
	public void Handle()
	{
		var customer = _context.Customers.SingleOrDefault(c => c.Id == CustomerId);
		
		if (customer is null)
			throw new InvalidOperationException("Customer couldn't found!");
		
		_context.Customers.Remove(customer);
		_context.SaveChanges();	
	}
}