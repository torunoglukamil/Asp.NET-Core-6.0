using PostgreSql_API_4.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

builder.Services.AddSingleton<DbHelper>();

var app = builder.Build();

app.MapGet("/school", () => "Service is running");

app.MapControllers();

app.Run();
