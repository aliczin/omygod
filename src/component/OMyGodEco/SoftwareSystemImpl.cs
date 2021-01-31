using Structurizr;
using ScriptEngine.Machine.Contexts;

namespace OMyGod
{
    [ContextClass("ПрограммнаяСистема", "SoftwareSystem")]
    public class SoftwareSystemImpl : AutoContext <SoftwareSystemImpl>
    {
        private SoftwareSystem softwareSystem;

        public SoftwareSystem link {get { return softwareSystem; } }

        [ContextMethod("ДобавитьКонтейнер", "AddContainer")]
        public ContainerImpl AddContainer(string name, string description, string technology)
        {
            return new ContainerImpl(
                softwareSystem.AddContainer(name, description, technology)
            );
        }

        public SoftwareSystemImpl(SoftwareSystem softwareSystem)
        {
            this.softwareSystem = softwareSystem;
        }
    }
}