using Microsoft.AspNetCore.Server.Kestrel.Core;
using TorneioWebApi.Database;
using TorneioWebApi.Database.Interfaces;
using TorneioWebApi.Repositories;
using TorneioWebApi.Repositories.Interfaces;
using TorneioWebApi.Services;
using TorneioWebApi.Services.Interfaces;

Host.CreateDefaultBuilder(args).ConfigureServices((context, services) =>
{
    services.Configure<KestrelServerOptions>(
        context.Configuration.GetSection("Kestrel"));
}).ConfigureWebHostDefaults(webBuilder =>
{
    webBuilder.UseStartup<StartupBase>();
});

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<ICompetidorRepository, CompetidorRepository>();
builder.Services.AddSingleton<ICompetidorService, CompetidorService>();
builder.Services.AddSingleton(new DatabaseConfig { Name = builder.Configuration["DatabaseName"] });
builder.Services.AddSingleton<IDatabaseContext, DatabaseContext>();


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

app.Run();
