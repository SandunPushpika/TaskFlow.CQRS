using Infrastructure.Persistent;
using Microsoft.EntityFrameworkCore;
using TaskFlow.CQRS.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbHelper>(opt =>
{
    opt.UseInMemoryDatabase("Tasks");
});

builder.Services.AddServices();
builder.Services.AddAutoMapper();

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();