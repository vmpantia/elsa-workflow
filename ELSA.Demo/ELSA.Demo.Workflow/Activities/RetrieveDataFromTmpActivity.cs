using Elsa.ActivityResults;
using Elsa.Services;
using Elsa.Services.Models;
using ELSA.Demo.Workflow.DataAccess;

namespace ELSA.Demo.Workflow.Activities
{
    public class RetrieveDataFromTmpActivity : Activity
    {
        private readonly ElsaDemoDbContext _db;
        public RetrieveDataFromTmpActivity(ElsaDemoDbContext db)
        {
            _db = db;
        }

        protected override IActivityExecutionResult OnExecute(ActivityExecutionContext context)
        {
            var tempCustomers = _db.TemporaryCustomers.ToList();

            context.SetVariable("tempCustomers", tempCustomers);

            return Done();
        }
    }
}
