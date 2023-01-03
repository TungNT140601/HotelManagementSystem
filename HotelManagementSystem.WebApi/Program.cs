using HotelManagementSystem.WebApi.DatabaseContext;
using HotelManagementSystem.WebApi.Services.CustomerService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<HotelManagementDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HotelDB") ?? throw new InvalidOperationException("Connection string 'HotelDB' not found.")));

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<ICustomerService, CustomerService>();
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
