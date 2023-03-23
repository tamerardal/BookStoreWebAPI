using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using static CreateCustomerCommand;
using static CreateTokenCommand;
[ApiController]
[Route("[controller]s")]
public class CustomerController : ControllerBase
{
	private readonly IMovieStoreDbContext _context;
	private readonly IMapper _mapper;
	readonly IConfiguration _configuration;
	public CustomerController(IMovieStoreDbContext context, IMapper mapper, IConfiguration configuration)
	{
		_context = context;
		_mapper = mapper;
		_configuration = configuration;
	}

	[HttpPost]
	public IActionResult AddCustomer([FromBody] CreateCustomerViewModel newCustomer)
	{
		CreateCustomerCommand command = new CreateCustomerCommand(_context, _mapper);
		command.Model = newCustomer;
		
		CreateCustomerCommandValidator validator = new CreateCustomerCommandValidator();
		validator.ValidateAndThrow(command);
		
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
	
	[HttpPost("connect/token")]
	public ActionResult<Token> CreateToken([FromBody] CreateTokenViewModel newToken)
	{
		CreateTokenCommand command = new CreateTokenCommand(_context, _mapper, _configuration);
		command.Model = newToken;
		
		return command.Handle();
	}
	
	[HttpGet("refreshToken")]
	public ActionResult<Token> RefreshToken([FromQuery] string token)
	{
		RefreshTokenCommand command = new RefreshTokenCommand(_context, _configuration);
		command.RefreshToken = token;
		
		return command.Handle();
	}
}