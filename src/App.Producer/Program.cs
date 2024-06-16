using App.Application.Contracts;
using App.Application.Mappers;
using App.Application.Services;
using App.Domain.Entities;
using App.Domain.Repositories;
using App.Domain.Validators;
using App.Infra.Adapters;
using App.Infra.Contexts;
using App.Infra.Repositories;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Automapper
builder.Services.AddAutoMapper(typeof(IStartup), typeof(MapperConfig));

//Services
builder.Services.AddTransient<IProducerService, ProducerService>();
builder.Services.AddTransient<IMessageReposity, MessageRepository>();
builder.Services.AddSingleton<IBrokerAdapter, BrokerAdapter>();
//Validators
builder.Services.AddScoped<IValidator<Message>, MessageValidator>();


builder.Services.AddDbContext<Context>(
    opt => opt.UseOracle(builder.Configuration.GetConnectionString("OracleConnection"))
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();