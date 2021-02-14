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

        [ContextMethod("ДобавитьВсё", "AddAll")]
        public void AddAll()
        {
            systemLandscapeView.AddAllPeople();
            systemLandscapeView.AddAllElements();
        }


        public SystemLandscapeViewImpl(SystemLandscapeView _systemLandscapeView)
        {
            systemLandscapeView = _systemLandscapeView;
        }
    }
}