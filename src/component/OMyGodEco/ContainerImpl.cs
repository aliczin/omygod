using Structurizr;
using ScriptEngine.Machine.Contexts;

namespace OMyGod
{
    [ContextClass("Контейнер", "Container")]
    public class ContainerImpl : AutoContext<ContainerImpl>
    {
        private Container container;

        public Container link {get { return container; } }

        [ContextMethod("ДобавитьМетку", "AddTag")]
        public void AddTag(string tag)
        {
            container.AddTags(tag);
        }

        [ContextMethod("Использует", "Use")]
        public void Use(ContainerImpl cImpl, string destination, string technology)
        {
            container.Uses(cImpl.link, destination, technology);
        }

        public ContainerImpl(Container container)
        {
            this.container = container;
        }
    }
}