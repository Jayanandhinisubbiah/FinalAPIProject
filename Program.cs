using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using APIProject.Data;
using APIProject.Provider;
using System.Text.Json.Serialization;
using APIProject.Helpers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FoodContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FoodContext") ?? throw new InvalidOperationException("Connection string 'FoodContext' not found.")));
//builder.Services.AddDbContext<FoodContext>(options =>
//    options.UseSqlServer(KeyVault.GetSecret("connectionstring1")));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSession();
builder.Services.AddDistributedMemoryCache();
// Add services to the container.
builder.Services.AddScoped<IProvider, FoodProvider>();

builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
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
app.UseSession();
app.UseAuthorization();

app.MapControllers();

app.Run();
