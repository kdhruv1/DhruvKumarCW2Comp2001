using Microsoft.EntityFrameworkCore;
using CW2_.Models;
using Microsoft.AspNetCore.Authentication.Cookies;



var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = "Server=dist-6-505.uopnet.plymouth.ac.uk;Database=COMP2001_DKumar;User ID=DKumar; Password=QymF731+";
builder.Services.AddDbContext<Comp2001DkumarContext>(options =>
    options.UseSqlServer(connectionString));
var app = builder.Build();




// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();

app.Run();
