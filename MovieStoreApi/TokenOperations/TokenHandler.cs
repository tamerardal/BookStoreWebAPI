using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

public class TokenHandler
{
	public IConfiguration IConfiguration { get; set; }

	public TokenHandler(IConfiguration iConfiguration)
	{
		IConfiguration = iConfiguration;
	}
	
	public Token CreateAccessToken(Customer customer)
	{
		Token tokenModel = new Token();
		SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(IConfiguration["Token:SecurityKey"]));
		
		SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
		
		tokenModel.ExpireDate = DateTime.Now.AddMinutes(15);
		
		JwtSecurityToken securityToken = new JwtSecurityToken(
			issuer: IConfiguration["Token:Issuer"],
			audience: IConfiguration["Token:Audience"],
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