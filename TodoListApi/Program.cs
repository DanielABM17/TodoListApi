using BLL;
using DAL.Context;
using DAL.Repository;
using DAL.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using Utilitys;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ToDoContext>(option=> option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b=> b.MigrationsAssembly("DAL")));
builder.Services.AddTransient<ITodoRepository, TodoRepository>();
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddScoped<ToDoServices>();



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
