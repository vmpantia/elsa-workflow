using Elsa.ActivityResults;
using Elsa.Services;
using Elsa.Services.Models;
using Elsa.Activities.Email;
using ELSA.Demo.Workflow.DataAccess;
using ELSA.Demo.Workflow.Models.enums;
using Elsa.Activities.Email.Options;
using Elsa.Activities.Email.Services;
using Elsa.Serialization;
using Microsoft.Extensions.Options;
using NetBox.Extensions;
using Elsa.Activities.ControlFlow;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ELSA.Demo.Workflow.Activities
{
    public class RenewCustomerActivity : Activity
    {
        private readonly ElsaDemoDbContext _db;
        public RenewCustomerActivity(ElsaDemoDbContext db)
        {
            _db = db;
        }

        protected override IActivityExecutionResult OnExecute(ActivityExecutionContext context)
        {
            var expiringCustomers = _db.Customers.Where(data => data.Status == Status.Expiring);

            if (!expiringCustomers.Any())
            {
                Console.WriteLine($"No customer to be renew today {DateTime.Now.ToString("MM-dd-yyyy")}");
                return Suspend();
            }

            foreach(var customer in expiringCustomers)
            {
                customer.Status = Status.Enabled;
                customer.RenewedAt = DateTime.Now;
                customer.ModifiedAt = DateTime.Now;
                _db.Customers.Update(customer);
            }

            _db.SaveChanges();
            return Done();
        }
    }
}
