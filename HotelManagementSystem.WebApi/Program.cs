using HotelManagementSystem.WebApi.DatabaseContext;
using HotelManagementSystem.WebApi.Services;
using HotelManagementSystem.WebApi.Services.CustomerService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<HotelManagementDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HotelDB")));

// Add services to the container.

builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IHotelManagementService, HotelManagementService>();
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
