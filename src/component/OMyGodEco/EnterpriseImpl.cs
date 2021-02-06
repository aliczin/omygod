using Structurizr;
using ScriptEngine.Machine.Contexts;

namespace OMyGod
{
    [ContextClass("ПлатформаПредприятия","EnterprisePlatform")]
    public class EnterpriseImpl : AutoContext <EnterpriseImpl>
    {
        private Enterprise enterprise;

        public EnterpriseImpl(Enterprise enterprise)
        {
            this.enterprise = enterprise;
        }
    }
}