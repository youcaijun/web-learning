using Microsoft.EntityFrameworkCore;
using entity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//可用
//builder.Services.AddScoped<UserInfoDapper>();
services.ServiceExtensions.add(builder);
builder.Services.AddControllers();


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
