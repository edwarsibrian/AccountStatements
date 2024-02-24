using AccountStatements.API.Configurations;
using AccountStatements.Domain.Configurations;
using AccountStatements.Domain.Configurations.Middleware;
using AccountStatements.Domain.Configurations.PipelineBehaviors;
using AccountStatements.Domain.Configurations.Validations;
using AccountStatements.Domain.Handlers;
using AccountStatements.Repository;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
    cfg.RegisterServicesFromAssemblyContaining<CreateSettingHandler>();
    cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
});
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

//Add FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<CreateSettingCommandValidator>(); // register validators
builder.Services.AddFluentValidationAutoValidation(); // the same old MVC pipeline behavior
builder.Services.AddFluentValidationClientsideAdapters(); // for client side

//Add AutoMapper
builder.Services.AddAutoMapper(typeof(MapperConfig));


builder.Services.AddDbContextFactory<AccountStatementsContext>(options =>
    options.UseInMemoryDatabase(databaseName: "AccountsStatements"));

builder.Services.AddDependencyInjection();

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

app.UseExceptionHandler();

DataGenerator.Initialize(app.Services);

app.Run();
