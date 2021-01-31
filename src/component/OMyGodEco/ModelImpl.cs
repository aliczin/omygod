using Structurizr;
using ScriptEngine.Machine.Contexts;
namespace OMyGod
{
    [ContextClass("МодельРабочегоПространства", "WorkspaceModel")]
    public class ModelImpl : AutoContext<ModelImpl>
    {
        private Model _createdModel;
        
        [ContextMethod("ДобавитьПрограммнуюСистему", "AddSoftwareSystem")]
        public SoftwareSystemImpl AddSoftwareSystem(string _name, string _description)
        {            
            return new SoftwareSystemImpl(
                _createdModel.AddSoftwareSystem(_name, _description)
            );
        }

        [ContextMethod("ДобавитьУзелРазвертывания","AddDeploymentNode")]
        public DeploymentNodeImpl AddDeploymentNode(string _name,
                                                    string _description,
                                                    string _technology)
        {
            var dn = _createdModel.AddDeploymentNode(_name, _description, _technology);

            return new DeploymentNodeImpl(dn);
        }

        public ModelImpl(Model createdModel)
        {
            _createdModel = createdModel;
        }
    }
}