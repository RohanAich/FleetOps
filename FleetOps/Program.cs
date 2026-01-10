using FleetOps.Application.Interfaces;
using FleetOps.Application.UseCases;
using FleetOps.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddSingleton<IVehicleRepository, InMemoryVehicleRepository>();

builder.Services.AddDbContext<FleetOpsDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);


builder.Services.AddScoped<IVehicleRepository, EfVehicleRepository>();
builder.Services.AddScoped<CreateVehicleUseCase>();

builder.Services.AddScoped<CreateVehicleUseCase>();

var app = builder.Build();

app.UseRouting();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

//app.UseHttpsRedirection();

app.Run();
