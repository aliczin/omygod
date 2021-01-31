using Structurizr;
using ScriptEngine.Machine.Contexts;

using Structurizr.IO.C4PlantUML.ModelExtensions;

namespace OMyGod
{
    [ContextClass("Отношение", "Relationship")]
    public class RelationshipImpl : AutoContext<RelationshipImpl>
    {
        private Relationship relationship;
        
        [ContextMethod("УстановитьНаправлениеВправо", "SetDirectionRight")]
        public void SetDirectionRight()
        {
            relationship.SetDirection(DirectionValues.Right);
        }


        public RelationshipImpl(Relationship relationship)
        {
            this.relationship = relationship;
        }
    }
}