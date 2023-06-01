using Microsoft.EntityFrameworkCore;
using SampleWebApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MvcdbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

// AdderssÉeÅ[ÉuÉãÇ…ë}ì¸
using (var scope = app.Services.CreateScope())
{
    var provider = scope.ServiceProvider;
    var context = provider.GetRequiredService<MvcdbContext>();
    SampleWebApi.Models.Address.Initialize(context);
}

app.Run();
