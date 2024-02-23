using AccountStatements.Domain.Configurations;
using AccountStatements.Domain.Configurations.Middleware;
using AccountStatements.Domain.Configurations.PipelineBehaviors;
using AccountStatements.Domain.Configurations.Validations;
using AccountStatements.Domain.Handlers;
using AccountStatements.Repository;
using AccountStatements.Repository.Interfaces;
using AccountStatements.Repository.Services;
using AccountStatements.Repository.Utils;
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
    cfg.RegisterServicesFromAssemblyContaining<CreateSettingHandler>();
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
//builder.Services.AddDbContextFactory<AccountStatementsContext>(opt =>
//    opt.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=AccountsStatements"));

builder.Services.AddScoped<ISettingService, SettingService>();
builder.Services.AddSingleton<IApplicationConfigManager, ApplicationConfigManager>();
builder.Services.AddSingleton<IEncryptDecryptString, EncryptDecryptString>();


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
