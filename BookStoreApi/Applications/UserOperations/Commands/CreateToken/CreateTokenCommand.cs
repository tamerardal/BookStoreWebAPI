using AutoMapper;

public class CreateTokenCommand
{
	public CreateTokenViewModel Model { get; set; }
	private readonly IBookStoreDbContext _context;
	private readonly IMapper _mapper;
	readonly IConfiguration _configuration;

	public CreateTokenCommand(IBookStoreDbContext context, IMapper mapper, IConfiguration configuration)
	{
		_context = context;
		_mapper = mapper;
		_configuration = configuration;
	}

	public Token Handle()
	{
		var user = _context.Users.FirstOrDefault(u => u.Email == Model.Email && u.Password == Model.Password);
		
		if (user is not null)
		{
			TokenHandler handler = new TokenHandler(_configuration);
			Token token = handler.CreateAccessToken(user);
			
			user.RefreshToken = token.RefreshToken;
			user.RefreshTokenExpireDate = token.ExpireDate.AddMinutes(5);
			
			_context.SaveChanges();
			return token;
		}
		else
			throw new InvalidOperationException("Email or password is wrong!");
	}
}

public class CreateTokenViewModel
{
	public string Email { get; set; }
	public string Password { get; set; }
}