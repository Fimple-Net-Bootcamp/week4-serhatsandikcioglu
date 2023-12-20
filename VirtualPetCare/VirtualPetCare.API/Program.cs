using FluentValidation;
using Microsoft.EntityFrameworkCore;
using VirtualPetCare.API;
using VirtualPetCare.Core.DTOs;
using VirtualPetCare.Core.Interfaces;
using VirtualPetCare.Core.Mapper;
using VirtualPetCare.Infrastructure.Database;
using VirtualPetCare.Infrastructure.Repositories;
using VirtualPetCare.Service;
using VirtualPetCare.Service.Interfaces;
using VirtualPetCare.Service.Validator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAplication();
builder.Services.AddDbContext<AppDbContext>(options =>
{

    options.UseNpgsql(builder.Configuration.GetConnectionString("SqlConnection"), Action => {
        Action.MigrationsAssembly("VirtualPetCare.Infrastructure");
    });
});
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
