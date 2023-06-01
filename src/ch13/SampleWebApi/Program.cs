using Microsoft.EntityFrameworkCore;
using SampleWebApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MvcdbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// CORSを有効にする
builder.Services.AddCors();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// CORSの設定
app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Adderssテーブルに挿入
using (var scope = app.Services.CreateScope())
{
    var provider = scope.ServiceProvider;
    var context = provider.GetRequiredService<MvcdbContext>();
    SampleWebApi.Models.Address.Initialize(context);
}

app.Run();
