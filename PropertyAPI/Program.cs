using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using PropertyAPI.Data;
using PropertyAPI.Extensions;
using PropertyAPI.Helpers;
using PropertyAPI.Interfaces;
using PropertyAPI.Middlewares;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddCors();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

app.ConfigureExceptionHandler(app.Environment);

//app.ConfigureBuiltInExceptionHandler(app.Environment);

// Configure the HTTP request pipeline.

app.UseCors(m => m.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();
