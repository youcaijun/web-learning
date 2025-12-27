using Microsoft.EntityFrameworkCore;
using register;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//使用配置类注册服务
ServiceRegister.ConfigureServices(builder.Services);
//注册单个可用
//builder.Services.AddScoped<UserInfoDapper>();
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
