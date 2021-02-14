using Structurizr;
using ScriptEngine.Machine.Contexts;

namespace OMyGod
{
    [ContextClass("СистемныйЛандшафт", "SystemsLandscape")]
    public class SystemLandscapeViewImpl : AutoContext<SystemLandscapeViewImpl>
    {
        private SystemLandscapeView systemLandscapeView;

        [ContextMethod("ДобавитьВсеЭлементы", "AddAllElements")]
        public void AddAllElements()
        {
            systemLandscapeView.AddAllElements();
        }


        public SystemLandscapeViewImpl(SystemLandscapeView systemLandscapeView)
        {
            this.systemLandscapeView = systemLandscapeView;
        }
    }
}