using Elsa.Activities.ControlFlow;
using Elsa.Activities.Email;
using Elsa.Activities.Http.Extensions;
using Elsa.Activities.Temporal;
using Elsa.Builders;
using ELSA.Demo.Workflow.Activities;
using NodaTime;

namespace ELSA.Demo.Workflow.Workflows
{
    public class RenewCustomerWorkflow : IWorkflow
    {
        public void Build(IWorkflowBuilder builder)
        {
            builder
                .Timer(Duration.FromSeconds(10))
                .Then<RenewCustomerActivity>();
        }
    }
}
