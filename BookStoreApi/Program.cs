using System.Reflection;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

internal class Program
{
	private static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.

		builder.Services.AddControllers();
		builder.Services.AddDbContext<BookStoreDbContext>(options => options.UseInMemoryDatabase(databaseName: "BookStoreDB"));
		builder.Services.AddScoped<IBookStoreDbContext>(provider => provider.GetService<BookStoreDbContext>());
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

		app.UseHttpsRedirection();

		app.UseAuthorization();
		
		app.UseCustomExceptionMiddleware();

		app.MapControllers();

		app.Run();
	}
}