using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Project_ProtectToFurture.API
{
	public class TokenGenerator
	{
		public string GeneretaToken()
		{

			SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Zorluzorluzorlu1."));
			SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			JwtSecurityToken token = new JwtSecurityToken(issuer: "http://localhost", audience: "http://localhost", notBefore: System.DateTime.Now, expires: DateTime.Now.AddMinutes(5), signingCredentials: credentials);

			JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
			return handler.WriteToken(token);
		}
	}
}
