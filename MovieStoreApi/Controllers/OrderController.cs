using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static CreateOrderCommand;
[Authorize]
[ApiController]
[Route("[controller]s")]
public class OrderController : ControllerBase
{
	private readonly IMovieStoreDbContext _context;
	private readonly IMapper _mapper;

	public OrderController(IMovieStoreDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}
	
	[HttpGet]
	public IActionResult GetOrders()
	{
		GetOrdersQuery query = new GetOrdersQuery(_context, _mapper);
		
		return Ok(query.Handle());
	}
	
	[HttpGet("{id}")]
	public IActionResult GetOrder(int id)
	{
		GetOrderDetailQuery query = new GetOrderDetailQuery(_context, _mapper);
		query.OrderId = id;
		
		GetOrderDetailQueryValidator validator = new GetOrderDetailQueryValidator();
		validator.ValidateAndThrow(query);

		return Ok(query.Handle());
	}
	
	[HttpPost]
	public IActionResult PurchasedMovie([FromBody] CreateOrderViewModel newOrder)
	{
		CreateOrderCommand command = new CreateOrderCommand(_context, _mapper);
		command.Model = newOrder;
		
		CreateOrderCommandValidator validator = new CreateOrderCommandValidator();
		validator.ValidateAndThrow(command);
		
		command.Handle();
		return Ok(); 
	}

	[HttpDelete("{id}")]
	public IActionResult SoftDelete(int id)
	{
		DeleteOrderCommand command = new DeleteOrderCommand(_context, _mapper);
		
		command.OrderId = id;
		command.Handle();
		
		return Ok();
	}
}