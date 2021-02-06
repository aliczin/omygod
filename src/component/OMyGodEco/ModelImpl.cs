using Structurizr;
using ScriptEngine.Machine.Contexts;
namespace OMyGod
{
    [ContextClass("МодельРабочегоПространства", "WorkspaceModel")]
    public class ModelImpl : AutoContext<ModelImpl>
    {
        private Model _createdModel;

        [ContextMethod("ДобавитьПлатформуПредприятия", "AddEnterprisePlatform")]
        public EnterpriseImpl AddEnterprise(string name)
        {
            _createdModel.Enterprise = new Enterprise(name);
            
            return new EnterpriseImpl(_createdModel.Enterprise);
        }

        [ContextMethod("ДобавитьПерсону", "AddPerson")]
        public PersonImpl AddPerson(string name, string description)
        {
            return new PersonImpl(_createdModel.AddPerson(name, description));
        }

        [ContextMethod("ДобавитьПрограммнуюСистему", "AddSoftwareSystem")]
        public SoftwareSystemImpl AddSoftwareSystem(string _name, string _description)
        {            
            return new SoftwareSystemImpl(
                _createdModel.AddSoftwareSystem(_name, 
                    _description.Replace("\r\n", "\\n").Replace( "\n", "\\n" ))
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