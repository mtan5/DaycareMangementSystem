using DMSWebApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using DMSClassLibrary.Interfaces;
using DMSWebApi.ApiFilter;

var builder = WebApplication.CreateBuilder(args);
string db_connection_string = builder.Configuration.GetConnectionString("DmsDbConn");
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DmsDbContext>(options => options.UseSqlServer(db_connection_string));
builder.Services.AddScoped<ISystemAccount, SystemAccount>();
builder.Services.AddScoped<IAPIHandler, ApiKeyHandler>();
builder.Services.AddScoped<APIKeyHandler>();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
