using Microsoft.EntityFrameworkCore;
using SportsStore.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.Extensions.Configuration;
using SportsStore.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("SportsStoreConnection");
builder.Services.AddDbContext<StoreDbContext>(opts => {
    opts.UseMySql(
        connectionString, ServerVersion.AutoDetect(connectionString) 
    );
});

builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();

var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();

SeedData.EnsurePopulated(app);

app.Run();
