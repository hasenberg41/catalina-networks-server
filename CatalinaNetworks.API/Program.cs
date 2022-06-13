using CatalinaNetworks.API.Profiles;
using CatalinaNetworks.DataBase;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using CatalinaNetworks.API.Middleware;
using CatalinaNetworks.Core.Repositories;
using CatalinaNetworks.Core.Models;
using CatalinaNetworks.Core.Services;
using CatalinaNetworks.BusinessLogic;

//Say my name
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<ApiUserMappingProfile>();
    cfg.AddProfile<DBUserMappingProfile>();
});

builder.Services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
// Пока слои логики не реализованы, контроллер использует методы контекста
// контекста базы данных напрямую для тестирования frontend части
builder.Services.AddDbContext<IRepository<User>, UsersDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

builder.Services.AddScoped<IUserService, UsersService>();

builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomExceptionHundler();

app.UseHttpsRedirection();

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
