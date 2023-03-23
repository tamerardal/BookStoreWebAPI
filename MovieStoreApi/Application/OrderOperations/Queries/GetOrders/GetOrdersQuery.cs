using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class GetOrdersQuery
{
	private readonly IMovieStoreDbContext _context;
	private readonly IMapper _mapper;

	public GetOrdersQuery(IMovieStoreDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}
	public List<OrdersViewModel> Handle()
	{
		var orders = _context.Orders.Include(c => c.Customer).Include(m => m.Movie).Where(o => o.IsActive == true).OrderBy(o => o.Id).ToList();
		List<OrdersViewModel> vm = _mapper.Map<List<OrdersViewModel>>(orders);
		
		return vm;
	}
	
	public class OrdersViewModel
	{
		public string Customer { get; set; }
		public string Movie { get; set; }
	}
}