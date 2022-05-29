using CatalinaNetworks.API.Profiles;
using CatalinaNetworks.DataBase;
using Microsoft.EntityFrameworkCore;
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

// Пока слои логики не реализованы, контроллер использует методы контекста
// контекста базы данных напрямую для тестирования frontend части
builder.Services.AddDbContext<UsersDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"))); // TODO : не соответствует DI

builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
