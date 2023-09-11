using Elsa;
using Elsa.Persistence.EntityFramework.Core.Extensions;
using Elsa.Persistence.EntityFramework.Sqlite;

var builder = WebApplication.CreateBuilder(args);

var elsaSection = builder.Configuration.GetSection("Elsa");
builder.Services.AddElsa(elsa => elsa
                    .UseEntityFrameworkPersistence(ef => ef.UseSqlite())
                    .AddConsoleActivities()
                    .AddHttpActivities(elsaSection.GetSection("Server").Bind)
                    .AddQuartzTemporalActivities()
                    .AddWorkflowsFrom<Startup>()
                );

// Elsa API endpoints.
builder.Services.AddElsaApiEndpoints();

// For Dashboard.
builder.Services.AddRazorPages();

var app = builder.Build();

app.UseStaticFiles();
app.UseHttpActivities();

app.MapFallbackToPage("/_Host");

app.Run();
