using CompanyEvaluationsAPI.Core_Layer.Interfaces;
using CompanyEvaluationsAPI.Core_Layer.Services;
using CompanyEvaluationsAPI.Infrastructure.Context;
using CompanyEvaluationsAPI.Infrastructure.Interfaces;
using CompanyEvaluationsAPI.Infrastructure.Repository;
using CompanyEvaluationsAPI.Infrastructure_Layer.Interfaces;
using CompanyEvaluationsAPI.Infrastructure_Layer.Interfaces.UnitOfWork;
using CompanyEvaluationsAPI.Infrastructure_Layer.Repository;
using CompanyEvaluationsAPI.Infrastructure_Layer.UnitOfWord;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IRatingRepository, RatingRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();



builder.Services.AddDbContext<DataContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 41)) // Adjust version to your MySQL version
    ));

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
