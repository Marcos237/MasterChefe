using Api.MasterChefe.Ioc.Initializers;
using Api.MasterChefe.Repository.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
new AplicationInitializer().Initialize(builder.Services);
new DomainInitializer().Initialize(builder.Services);
new RepositoryInitializer().Initialize(builder.Services);

builder.Services.AddDbContext<MasterChefeContext>(
        options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

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
