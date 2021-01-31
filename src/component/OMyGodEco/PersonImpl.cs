using Structurizr;
using ScriptEngine.Machine.Contexts;

namespace OMyGod
{
    [ContextClass("Персона", "Person")]
    public class PersonImpl : AutoContext<PersonImpl>
    {
        private Person person;

        [ContextMethod("ИспользуетСистему","UseSystem")]
        public RelationshipImpl UseSystem(SoftwareSystemImpl system, string description)
        {
            return new RelationshipImpl(
                person.Uses(system.link, description)
            );
        }

        public PersonImpl(Person person)
        {
            this.person = person;
        }
    }
}