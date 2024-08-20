using Microsoft.EntityFrameworkCore;
using PaymentApplicationAPI.Domain.Services;
using PaymentApplicationAPI.Infrastructure.DataAccessLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// adding the driver for postgresql
builder.Services.AddDbContext<PaymentCollectionDBContext>(options => options.UseNpgsql("Host=localhost;Database=payment-db;Username=postgres;Password=Manchester2023!"));

//dependecny injection
builder.Services.AddScoped<ILoginService,LoginService>();
builder.Services.AddScoped<IOperationService, OperationService>();
builder.Services.AddScoped<IMembershipService, MemberService>();


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
