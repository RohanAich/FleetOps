using FleetOps.Application.Interfaces;
using FleetOps.Application.UseCases;
using FleetOps.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IVehicleRepository, InMemoryVehicleRepository>();
builder.Services.AddScoped<CreateVehicleUseCase>();

var app = builder.Build();

app.UseRouting();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

//app.UseHttpsRedirection();

app.Run();
