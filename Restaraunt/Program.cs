using Microsoft.EntityFrameworkCore;
using Restaraunt;
using Restaraunt.RestarauntSystem.DAL.DbContexts;
using RestarauntBLL.Services.Abstract;
using RestarauntBLL.Services;
using RestarauntDAL.Repositories;
using RestarauntBLL.Mapping;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RestarauntContext>(dbContextOptions => dbContextOptions.UseSqlServer("Server=.\\SQLEXPRESS;DataBase=WebRestaraunt.db;Trusted_Connection=True"));
builder.Services.AddScoped<IIngredientService, IngredientService>();
builder.Services.AddScoped<IDishService, DishService>();
builder.Services.AddScoped<IPortionService, PortionService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(IngredientProfile)));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }