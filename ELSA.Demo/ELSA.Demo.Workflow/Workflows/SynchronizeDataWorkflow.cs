using Elsa.Activities.Console;
using Elsa.Activities.Temporal;
using Elsa.Builders;
using ELSA.Demo.Workflow.Activities;
using NodaTime;

namespace ELSA.Demo.Workflow.Workflows
{
    public class SynchronizeDataWorkflow : IWorkflow
    {
        public void Build(IWorkflowBuilder builder)
        {
            builder
                .Timer(Duration.FromSeconds(60))
                .Then<RetrieveDataFromTmpActivity>()
                .Then<UpdateDataActivity>()
                .WriteLine($"Synchornization completed at {DateTime.Now}");
        }
    }
}
