using BasecampAPI.MiddleWares;
using DAL.Models;
using DAL.Repository;
using DAL.Services;
using DAL.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IRepository<Board>, Repository<Board>>();
builder.Services.AddScoped<IRepository<TaskItem>, Repository<TaskItem>>();
builder.Services.AddScoped<IRepository<Sprint>, Repository<Sprint>>();
builder.Services.AddScoped<IBoardService, BoardService>();
builder.Services.AddScoped<ITaskItemService, TaskItemService>();
builder.Services.AddScoped<CustomErrorHandlingMiddleware, CustomErrorHandlingMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCustomErrorHandlingMiddleWare();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
