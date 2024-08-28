using CleanArchitecture.Application.Service;
using CleanArchitecture.Domain.Interface;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Net.NetworkInformation;
using SQLitePCL;
using CleanCleanArchitecture.Data;
using CleanArchitecture.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BlogDbcontext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("BlogBbcontext") ??
    throw new InvalidOperationException("Connection string 'BlogBbcontext' not found.")));

builder.Services.AddTransient<IBlogRespository, BlogRepository>();
builder.Services.AddTransient<IBlogService, BlogService>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
