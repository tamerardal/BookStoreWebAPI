public class RefreshTokenCommand
{
	public string RefreshToken { get; set; }
	private readonly IMovieStoreDbContext _context;
	readonly IConfiguration _configuration;

	public RefreshTokenCommand(IMovieStoreDbContext context, IConfiguration configuration)
	{
		_context = context;
		_configuration = configuration;
	}
	
	public Token Handle()
	{
		var customer = _context.Customers.FirstOrDefault(c => c.RefreshToken == RefreshToken && c.RefreshTokenExpireDate > DateTime.Now);
		
		if (customer is not null)
		{
			TokenHandler tokenHandler = new TokenHandler(_configuration);
			Token token = tokenHandler.CreateAccessToken(customer);
			
			customer.RefreshToken = token.RefreshToken;
			customer.RefreshTokenExpireDate = token.ExpireDate.AddMinutes(5);
			
			_context.SaveChanges();
			return token;
		}
		else
			throw new InvalidOperationException("Refresh Token couldn't found!");
	}
}