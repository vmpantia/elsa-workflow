using Elsa;
using ELSA.Demo.Workflow.DataAccess;
using ELSA.Demo.Workflow.Extensions;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("MigrationDb");
builder.Services.AddDbContext<ElsaDemoDbContext>(options => options.UseSqlServer(connectionString));

var elsaSection = builder.Configuration.GetSection("Elsa");
builder.Services.ConfigureElsaWorkflowServices(connectionString, elsaSection);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseHttpActivities();
app.UseStaticFiles();
app.MapFallbackToPage("/_Host");
StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);

app.UseAuthorization();

app.MapControllers();

app.Run();
