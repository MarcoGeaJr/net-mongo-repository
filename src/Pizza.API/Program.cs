using Pizza.API.Extensions;
using Pizza.Infra.Mongo;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureContexts(builder.Configuration);
builder.Services.AddRepositories();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapRoutes();

app.Run();
