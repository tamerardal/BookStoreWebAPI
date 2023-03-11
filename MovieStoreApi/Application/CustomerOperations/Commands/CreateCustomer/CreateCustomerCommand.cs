using AutoMapper;

public class CreateCustomerCommand
{
	public CreateCustomerViewModel Model { get; set; }
	private readonly IMovieStoreDbContext _context;
	private readonly IMapper _mapper;

	public CreateCustomerCommand(IMovieStoreDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}
	
	public void Handle()
	{
		var customer = _context.Customers.SingleOrDefault(c => c.Email.ToLower() == Model.Email.ToLower());
		
		if (customer is not null)
			throw new InvalidOperationException("Customer is already added!");
			
		customer = _mapper.Map<Customer>(Model);
		
		_context.Customers.Add(customer);
		_context.SaveChanges();
	}
	
	public class CreateCustomerViewModel
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
	}
}

