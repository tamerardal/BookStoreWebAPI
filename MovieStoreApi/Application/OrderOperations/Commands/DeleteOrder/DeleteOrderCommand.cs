using AutoMapper;

public class DeleteOrderCommand
{
	public int OrderId { get; set; }
	private readonly IMovieStoreDbContext _context;
	private readonly IMapper _mapper;

	public DeleteOrderCommand(IMovieStoreDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}
	
	public void Handle()
	{
		var order = _context.Orders.SingleOrDefault(o => o.Id == OrderId);
		if (order is null)
				throw new InvalidOperationException("ID's couldn't found!");

		order.IsActive = false;

		_context.Orders.Update(order);
		_context.SaveChanges();
	}
}