public class TokenHandler
{
	public IConfiguration IConfiguration { get; set; }

	public TokenHandler(IConfiguration iConfiguration)
	{
		IConfiguration = iConfiguration;
	}
	
	public Token CreateAccessToken(Customer customer)
	{
		return null;
	}
}