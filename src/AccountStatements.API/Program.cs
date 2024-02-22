using AccountStatements.API.Configurations;
using AccountStatements.API.Configurations.IoC;
using AccountStatements.API.Configurations.Middleware;
using AccountStatements.API.Configurations.PipelineBehaviors;
using AccountStatements.API.Configurations.Validations;
using AccountStatements.Domain;
using AccountStatements.Domain.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Add HealthChecks
builder.Services.AddHealthChecks();
//Add Mediator (CQRS)
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
    cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
});

//Add FluentValidation
//builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddValidatorsFromAssemblyContaining<CreateSettingCommandValidator>(); // register validators
builder.Services.AddFluentValidationAutoValidation(); // the same old MVC pipeline behavior
builder.Services.AddFluentValidationClientsideAdapters(); // for client side

//Add AutoMapper
builder.Services.AddAutoMapper(typeof(MapperConfig));


builder.Services.AddDbContextFactory<AccountStatementsContext>(options =>
    options.UseInMemoryDatabase(databaseName: "AccountsStatements"));

builder.Services.AddScoped<ISettingRepository, SettingRepository>();


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

app.MapHealthChecks(pattern: "/health");

app.UseMiddleware<ValidationExceptionHandlingMiddleware>();

app.Run();
