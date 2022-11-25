using Microsoft.EntityFrameworkCore;
using transactionTest.models;
using transactionTest.services;
using transactionTest.services.Icountry;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<GeodbContext>(options =>
                                    options.UseSqlServer(
                                        builder.Configuration.GetConnectionString("default")));
builder.Services.AddTransient<ICountryService, CountryService>();
builder.Services.AddTransient<ITransactionService, TransactionService>();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
