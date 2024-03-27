using Microsoft.EntityFrameworkCore;
using URLShortener.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppContext>(opt => opt.UseInMemoryDatabase("URLShortener"));

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
