using Microsoft.EntityFrameworkCore;
using A1Template.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Added lines for A1DbContext and IA1Repo
//builder.Services.AddDbContext<A1DbContext>(options => 
  //  options.UseSqlite(builder.Configuration["P1DBConnection"]));
//builder.Services.AddScoped<IA1Repo, A1Repo>();

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

app.Run("http://localhost:8083");
