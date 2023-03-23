using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class GetOrderDetailQuery
{
	public int OrderId { get; set; }
	private readonly IMovieStoreDbContext _context;
	private readonly IMapper _mapper;

	public GetOrderDetailQuery(IMovieStoreDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}
	
	public OrderViewModel Handle()
	{
		var order = _context.Orders.Include(m => m.Movie).Include(c => c.Customer).SingleOrDefault(o => o.Id == OrderId);
		
		if (order is null)
			throw new InvalidOperationException("ID's not correct!");
		
		return _mapper.Map<OrderViewModel>(order);
	}

	public class OrderViewModel
	{
		public string TransactionTime { get; set; }
		public string Customer { get; set; }
		public string Movie { get; set; }
		public string Price { get; set; }
		public string IsActive { get; set; }
	}
}