using AutoMapper;

public class CreateTokenCommand
{
	public CreateTokenViewModel Model { get; set; }
	private readonly IMovieStoreDbContext _context;
	private readonly IMapper _mapper;
	readonly IConfiguration _configuration;

	public CreateTokenCommand(IMovieStoreDbContext context, IMapper mapper, IConfiguration configuration)
	{
		_context = context;
		_mapper = mapper;
		_configuration = configuration;
	}
	
	public Token Handle()
	{
		var customer = _context.Customers.FirstOrDefault(c => c.Email == Model.Email && c.Password == Model.Password);
		
		if (customer is not null)
		{
			TokenHandler tokenHandler = new TokenHandler(_configuration);
			Token token = tokenHandler.CreateAccessToken(customer);
			
			customer.RefreshToken = token.RefreshToken;
			customer.RefreshTokenExpireDate = token.ExpireDate.AddMinutes(5);
			
			_context.SaveChanges();
			return token;
		}else
		{
			throw new InvalidOperationException("Email or password is wrong!");
		}
	}

	public class CreateTokenViewModel
	{
		public string Email { get; set; }
		public string Password { get; set; }
	}
}