using AutoMapper;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]s")]
public class UserController : ControllerBase 
{
	private readonly IBookStoreDbContext _context;
	private readonly IMapper _mapper;
	readonly IConfiguration _configuration;

	public UserController(IBookStoreDbContext context, IMapper mapper, IConfiguration configuration)
	{
		_context = context;
		_mapper = mapper;
		_configuration = configuration;
	}
	
	[HttpPost]
	public IActionResult Create([FromBody] CreateUserViewModel newUser)
	{
		CreateUserCommand command = new CreateUserCommand(_context, _mapper);
		command.Model = newUser;
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