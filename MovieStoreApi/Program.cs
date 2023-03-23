using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

internal class Program
{
	private static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.
		builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
			opt => 
			{
				opt.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateAudience = true,
					ValidateIssuer = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ValidIssuer = builder.Configuration["Token:Issuer"],
					ValidAudience = builder.Configuration["Token:Audience"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
					ClockSkew = TimeSpan.Zero
				};
			}
		);
		builder.Services.AddControllers();
		builder.Services.AddDbContext<MovieStoreDbContext>(opt => opt.UseInMemoryDatabase(databaseName: "MovieStoreDB"));
		builder.Services.AddScoped<IMovieStoreDbContext>(pro => pro.GetService<MovieStoreDbContext>());
		builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();
		builder.Services.AddSingleton<ILoggerService, DbLogger>();

		var app = builder.Build();
		
		using(var scope = app.Services.CreateScope())
		{
			var services = scope.ServiceProvider;
			DataGenerator.Initialize(services);
		}

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseAuthentication();

		app.UseHttpsRedirection();

		app.UseAuthorization();
		
		app.UseCustomExceptionMiddleware();

		app.MapControllers();

		app.Run();
	}
}