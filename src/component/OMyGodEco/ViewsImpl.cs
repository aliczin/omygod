using Structurizr;
using ScriptEngine.Machine.Contexts;

namespace OMyGod
{
    [ContextClass("ПредставленияРабочегоПространства", "WorspacesViews")]
    public class ViewsImpl : AutoContext<ViewsImpl>
    {
        private Workspace _createdWorkspace;

        public ViewsImpl(Workspace createdWorkspace)
        {
            _createdWorkspace = createdWorkspace;
        }
    }
}