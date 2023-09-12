using Elsa;
using Elsa.Persistence.EntityFramework.SqlServer;
using Elsa.Persistence.EntityFramework.Core.Extensions;
using ELSA.Demo.Workflow.Activities;

namespace ELSA.Demo.Workflow.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureElsaWorkflowServices(this IServiceCollection services, string connectionString, IConfiguration elsaSection)
        {
            services.AddElsa(options => options
                                            .UseEntityFrameworkPersistence(ef => ef.UseSqlServer(connectionString))
                                            .AddConsoleActivities()
                                            .AddHttpActivities(elsaSection.GetSection("Server").Bind)
                                            .AddEmailActivities(elsaSection.GetSection("Smtp").Bind)
                                            .AddQuartzTemporalActivities()
                                            .AddJavaScriptActivities()
                                            .AddActivity<RenewCustomerActivity>());
                                            //.AddWorkflow<RenewCustomerWorkflow>());

            services.AddElsaApiEndpoints();
            services.AddRazorPages();
        }
    }
}
