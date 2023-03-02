using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

public class TokenHandler
{
	public IConfiguration Configuration { get; set; }

	public TokenHandler(IConfiguration configuration)
	{
		Configuration = configuration;
	}
	
	public Token CreateAccessToken(User user)
	{
		Token tokenModel = new Token();
		SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"]));
		
		SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
		
		tokenModel.ExpireDate = DateTime.Now.AddMinutes(15);
		
		JwtSecurityToken securityToken = new JwtSecurityToken(
			issuer: Configuration["Token:Issuer"],
			audience: Configuration["Token:Audience"],
			expires: tokenModel.ExpireDate,
			notBefore: DateTime.Now,
			signingCredentials: signingCredentials
		);
		
		JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
		tokenModel.AccessToken = tokenHandler.WriteToken(securityToken);
		tokenModel.RefreshToken = CreateRefreshToken();
		
		return tokenModel;
	}
	
	public string CreateRefreshToken()
	{
		return Guid.NewGuid().ToString();
	}
}