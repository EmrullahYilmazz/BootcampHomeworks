using BitirmeProjesi.Domain.Entities;
using BitirmeProjesi.Persistence.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BitirmeProjesi.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BitirmeProjesi.Persistence.Repositories
{
	public class JWTManagerRepository : IJWTManagerRepository
	{
	
		//Jwt işlemleri controllerde login\login ve login\authenticate için kodlar
        private readonly ApplicationDbContext _context;

        private readonly IConfiguration iconfiguration;
		public JWTManagerRepository(IConfiguration iconfiguration, IServiceScopeFactory factory)
		{
			//this._context = applicationDbContext;
			this._context = factory.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();

			this.iconfiguration = iconfiguration;
		}
		public Tokens Authenticate(User users)
		{
            //if (!UsersRecords.Any(x => x.Key == users.UserName))
            //{
            //    return null;
            //}
            if (!_context.Users.Any(x => x.UserName == users.UserName))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
			var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Token"]);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
						new Claim(ClaimTypes.Name, users.UserName)
				 }),
				Expires = DateTime.UtcNow.AddMinutes(10),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return new Tokens { Token = tokenHandler.WriteToken(token) };
		}
	}
}