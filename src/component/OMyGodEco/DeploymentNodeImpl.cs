using Structurizr;
using ScriptEngine.Machine.Contexts;

namespace OMyGod
{
    [ContextClass("УзелРазвертывания","DeploymentNode")]
    public class DeploymentNodeImpl : AutoContext <DeploymentNodeImpl>
    {
        private DeploymentNode deploymentNode;

        [ContextMethod("ДобавитьУзелРазвертывания", "AddDeploymentNode")]
        public DeploymentNodeImpl AddDeploymentNode(string _name,
                                                    string _description,
                                                    string _technology)
        {
            return new DeploymentNodeImpl(
                deploymentNode.AddDeploymentNode(_name, _description, _technology)
            );
        }

        [ContextMethod("Добавить", "Add")]
        public ContainerInstanceImpl Add(ContainerImpl container)
        {
            return new ContainerInstanceImpl(
                deploymentNode.Add(container.link)
            );
        }

        public DeploymentNodeImpl(DeploymentNode deploymentNode)
        {
            this.deploymentNode = deploymentNode;
        }
    }
}