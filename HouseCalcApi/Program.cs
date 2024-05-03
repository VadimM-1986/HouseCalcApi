using Microsoft.EntityFrameworkCore;
using HouseCalcApi.Models;
using AppContext = HouseCalcApi.Models.AppContext;
using HouseCalcApi.Core;
using HouseCalcApi.Data;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, services, configuration) => configuration
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services)
    .Enrich.FromLogContext()
    .WriteTo.Console());
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<AppContext>();
builder.Services.AddTransient <IPriceRepository, PriceRepository>();
builder.Services.AddTransient <ICalculatorService, CalculatorService>();


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
