using T_Api_Time.Models;
using T_Api_Time.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ეს ამოიღებს დატაბეიზის სტრინგს აპპსეტტინგ ფაილიდან
builder.Services.AddDbContext<T_Api_TimeContext>(
                    options => options.UseSqlServer(
                        builder.Configuration.GetConnectionString("T_Api_TimeContext")
                        )
                    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

// დაწყება      23:21
// დამთავრება   მეორე დღის 15:27 :( .