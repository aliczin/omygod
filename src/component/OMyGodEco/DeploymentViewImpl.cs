using Structurizr;
using ScriptEngine.Machine.Contexts;

namespace OMyGod
{
    [ContextClass("ПредставлениеРазвертывания","DeploymentView")]
    public class DeploymentViewImpl : AutoContext<DeploymentViewImpl>
    {
        private DeploymentView deploymentView;

        [ContextProperty("Окружение", "Environment")]
        public string env {
            get => deploymentView.Environment; 
            set => deploymentView.Environment = env; 
        }

        [ContextMethod("ДобавитьВсеУзлыРазвертывания", "AddAllDeploymentNodes")]
        public void AddAllDeploymentNodes()
        {
            deploymentView.AddAllDeploymentNodes();
        }

        public DeploymentViewImpl(DeploymentView deploymentView)
        {
            this.deploymentView = deploymentView;
        }
    }
}