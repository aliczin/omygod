using Structurizr;
using ScriptEngine.Machine.Contexts;

namespace OMyGod
{

    [ContextClass("ЭкземплярКонтейнера", "ContainerInstance")]
    public class ContainerInstanceImpl : AutoContext<ContainerInstanceImpl>
    {
        private ContainerInstance containerInstance;

        [ContextMethod("ДобавитьПроверкуДоступности", "AddHealthCheck")]
        public void AddHealthCheck(string name, string url)
        {
            containerInstance.AddHealthCheck(name, url);
        }

        public ContainerInstanceImpl(ContainerInstance containerInstance)
        {
            this.containerInstance = containerInstance;
        }
    }
}