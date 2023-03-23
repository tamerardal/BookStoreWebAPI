public class RefreshTokenCommand
{
	public string RefreshToken { get; set; }
	private readonly IBookStoreDbContext _context;
	readonly IConfiguration _configuration;

	public RefreshTokenCommand(IBookStoreDbContext context, IConfiguration configuration)
	{
		_context = context;
		_configuration = configuration;
	}
	public Token Handle()
	{
		var user = _context.Users.FirstOrDefault(u => u.RefreshToken == RefreshToken && u.RefreshTokenExpireDate > DateTime.Now);
		
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
			throw new InvalidOperationException("Refresh Token couldn't found!");
	}
}