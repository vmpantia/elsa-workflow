using Elsa.ActivityResults;
using Elsa.Services;
using Elsa.Services.Models;
using ELSA.Demo.Workflow.DataAccess;
using ELSA.Demo.Workflow.DataAccess.Entities;
using ELSA.Demo.Workflow.Models.enums;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ELSA.Demo.Workflow.Activities
{
    public class UpdateDataActivity : Activity
    {
        private readonly ElsaDemoDbContext _db;
        public UpdateDataActivity(ElsaDemoDbContext db)
        {
            _db = db;
        }

        protected override IActivityExecutionResult OnExecute(ActivityExecutionContext context)
        {
            var tempCustomers = context.GetVariable<List<TemporaryCustomer>>("tempCustomers") ?? new List<TemporaryCustomer>();
            foreach(var customer in tempCustomers)
            {
                // Check if the customer exist
                var exist = _db.Customers.Where(data => data.Id == customer.Id)
                                         .FirstOrDefault();
                // Add new customer
                if (exist == null)
                {
                    customer.Status = Status.Enabled;
                    _db.Customers.Add(new Customer
                    {
                        Id = customer.Id,
                        Name = customer.Name,
                        Email = customer.Email,
                        Status = Status.Enabled,
                        RenewedAt = null,
                        CreatedAt = DateTime.Now,
                        ModifiedAt = null
                    });
                }
                else
                {
                    exist.Name = customer.Name;
                    exist.Email = customer.Email;
                    exist.Status = customer.Status;
                    exist.ModifiedAt = DateTime.Now;
                    _db.Customers.Update(exist);
                }
                _db.SaveChanges();
            }
            return Done();
        }
    }
}
