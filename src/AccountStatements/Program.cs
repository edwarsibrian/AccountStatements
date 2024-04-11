using AccountStatements.Configurations;
using AccountStatements.Configurations.Handlers;
using AccountStatements.Helpers;
using AccountStatements.Interfaces;
using AccountStatements.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHealthChecks();

//Global Exception
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

//Add AutoMapper
builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.HttpClientFactoryConfigure(builder.Configuration);

builder.Services.AddScoped<IHttpContentHelper, HttpContentHelper>();
builder.Services.AddScoped<IAccountStatementsClient, AccountStatementsClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseExceptionHandler();

app.UseRouting();

app.UseAuthorization();

app.UseHealthChecks(path: "/health");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
