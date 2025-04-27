using System;
using System.Activities;
using UiPath.CodedWorkflows;
using UiPath.CodedWorkflows.Utils;
using System.Threading;
using System.Threading.Tasks;

namespace UiBankTestSuite
{
    [System.ComponentModel.Browsable(false)]
    public class BootloaderActivity : System.Activities.Activity
    {
        public InArgument<System.String> pipeName { get; set; }

        public InArgument<System.String> workflowPath { get; set; }

        public InArgument<System.Collections.Generic.Dictionary<System.String, System.Object>> wfArgs { get; set; }

        public BootloaderActivity()
        {
            this.Implementation = () =>
            {
                return new BootloaderActivityChild()
                {pipeName = (this.pipeName == null ? (InArgument<System.String>)Argument.CreateReference((Argument)new InArgument<System.String>(), "pipeName") : (InArgument<System.String>)Argument.CreateReference((Argument)this.pipeName, "pipeName")), workflowPath = (this.workflowPath == null ? (InArgument<System.String>)Argument.CreateReference((Argument)new InArgument<System.String>(), "workflowPath") : (InArgument<System.String>)Argument.CreateReference((Argument)this.workflowPath, "workflowPath")), wfArgs = (this.wfArgs == null ? (InArgument<System.Collections.Generic.Dictionary<System.String, System.Object>>)Argument.CreateReference((Argument)new InArgument<System.Collections.Generic.Dictionary<System.String, System.Object>>(), "wfArgs") : (InArgument<System.Collections.Generic.Dictionary<System.String, System.Object>>)Argument.CreateReference((Argument)this.wfArgs, "wfArgs")), };
            };
        }
    }

    [System.ComponentModel.Browsable(false)]
    internal class BootloaderActivityChild : UiPath.CodedWorkflows.AsyncTaskCodedWorkflowActivity
    {
        public InArgument<System.String> pipeName { get; set; }

        public InArgument<System.String> workflowPath { get; set; }

        public InArgument<System.Collections.Generic.Dictionary<System.String, System.Object>> wfArgs { get; set; }

        public System.Collections.Generic.IDictionary<string, object> newResult { get; set; }

        public BootloaderActivityChild()
        {
            DisplayName = "Bootloader";
        }

        protected override async Task<Action<AsyncCodeActivityContext>> ExecuteAsync(AsyncCodeActivityContext context, System.Threading.CancellationToken cancellationToken)
        {
            var codedWorkflow = new global::UiBankTestSuite.Bootloader();
            CodedWorkflowHelper.Initialize(codedWorkflow, context);
            await codedWorkflow.Execute(pipeName.Get(context), workflowPath.Get(context), wfArgs.Get(context), cancellationToken);
            ;
            return endContext =>
            {
            };
        }
    }
}