using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using static CreateCustomerCommand;

[ApiController]
[Route("[controller]s")]
public class CustomerController : ControllerBase
{
	private readonly IMovieStoreDbContext _context;
	private readonly IMapper _mapper;
	public CustomerController(IMovieStoreDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}
	
	[HttpPost]
	public IActionResult AddCustomer([FromBody] CreateCustomerViewModel newCustomer)
	{
		CreateCustomerCommand command = new CreateCustomerCommand(_context, _mapper);
		command.Model = newCustomer;
		
		command.Handle();
		return Ok();
	}
	
	[HttpDelete]
	public IActionResult DeleteCustomer(int id)
	{
		DeleteCustomerCommand command = new DeleteCustomerCommand(_context);
		command.CustomerId = id;
		
		command.Handle();
		return Ok();
	}
}