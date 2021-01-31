using Structurizr;
using ScriptEngine.Machine.Contexts;

namespace OMyGod
{
    [ContextClass("Предприятие","Enterprise")]
    public class EnterpriseImpl : AutoContext <EnterpriseImpl>
    {
        private Enterprise enterprise;

        public EnterpriseImpl(Enterprise enterprise)
        {
            this.enterprise = enterprise;
        }
    }
}