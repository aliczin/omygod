using System.Linq;
using Structurizr;
using ScriptEngine.Machine.Contexts;
using Structurizr.IO.C4PlantUML.ModelExtensions;

namespace OMyGod
{
    [ContextClass("СистемноеПредставление", "SystemView")]
    public class SystemViewImpl : AutoContext <SystemViewImpl>
    {
        private SystemContextView systemContextView;

        [ContextMethod("ДобавитьВсеПрограммныеСистемы", "AddAllSoftwareSystems")]
        public void AddAllSoftwareSystems()
        {
            systemContextView.AddAllSoftwareSystems();
        }

        [ContextMethod("ДобавитьВсехЛюдей", "AddAllPeople")]
        public void AddAllPeople()
        {
            systemContextView.AddAllPeople();
        }

        public SystemViewImpl(SystemContextView systemContextView)
        {
            this.systemContextView = systemContextView;
        }
    }
}