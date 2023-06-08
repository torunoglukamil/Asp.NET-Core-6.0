using Microsoft.EntityFrameworkCore;
using PostgreSql_API_3.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<SchoolContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.MapGet("/my_store", () => "Service is running");

app.MapControllers();

app.Run();
