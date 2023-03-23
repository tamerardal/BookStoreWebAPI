using AutoMapper;

public class CreateOrderCommand
{
	public CreateOrderViewModel Model { get; set; }
	private readonly IMovieStoreDbContext _context;
	private readonly IMapper _mapper;

	public CreateOrderCommand(IMovieStoreDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}
	
	public void Handle()
	{
		var customer = _context.Customers.SingleOrDefault(c => c.Id == Model.CustomerId);
		var movie = _context.Movies.SingleOrDefault(m => m.Id == Model.MovieId);
		
		if (customer is null && movie is null)
			throw new InvalidOperationException("Order is already added!");
		
		var result = _mapper.Map<Order>(Model);
		result.IsActive = true;
		result.TransactionTime = DateTime.Now;
		
		movie.IsActive = false;
		
		_context.Orders.Add(result);
		_context.SaveChanges();
	}

	public class CreateOrderViewModel
	{
		public int CustomerId { get; set; }
		public int MovieId { get; set; }
	}
}