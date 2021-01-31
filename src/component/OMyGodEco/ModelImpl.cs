using Structurizr;
using ScriptEngine.Machine.Contexts;


namespace OMyGod
{
    [ContextClass("МодельРабочегоПространства", "WorkspaceModel")]
    public class ModelImpl : AutoContext<ModelImpl>
    {
        private Workspace _createdWorkspace;

        public ModelImpl(Workspace createdWorkspace)
        {
            _createdWorkspace = createdWorkspace;
        }
    }
}