using ScriptEngine.Machine.Contexts;
using Structurizr.Api;

using System;
using System.Reflection;

using System.IO;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

using Structurizr.IO.PlantUML;

namespace OMyGod
{
     internal class PaperSizeJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Structurizr.PaperSize).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

        public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return Structurizr.PaperSize.GetPaperSize(reader.Value as string);
        }

        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, JsonSerializer serializer)
        {
            Structurizr.PaperSize paperSize = value as Structurizr.PaperSize;
            if (paperSize != null)
            {
                writer.WriteValue(paperSize.Key);
            }
        }
    }

    [ContextClass("РабочееПространствоАрхитектора", "ArcitectWorkspace")]
    public class OSZWorkspace : AutoContext<OSZWorkspace>
    {
        private Structurizr.Workspace _createdWorkspace;
        public OSZWorkspace(Structurizr.Workspace createdWorkspace)
        {
            this._createdWorkspace = createdWorkspace;
            this.Model = new ModelImpl(this._createdWorkspace.Model);
            this.Views = new ViewsImpl(this._createdWorkspace);
        }

        [ContextProperty("Модель", "Model")]
        public ModelImpl Model {get; private set;}

        [ContextProperty("Представления", "Views")]
        public ViewsImpl Views {get; private set;}

        [ContextMethod("ПолучитьПредставлениеJSON", "GetPresentationJSON")]
        public string GetPresentationJSON()
        {
            
            StringWriter stringWriter = new StringWriter();

            string json = JsonConvert.SerializeObject(_createdWorkspace,
                Formatting.Indented,
                new StringEnumConverter(),
                new IsoDateTimeConverter(),
                new PaperSizeJsonConverter()
                );


            stringWriter.Write(json);
            
            return stringWriter.ToString();
        }

        [ContextMethod("ПолучитьПредставлениеUML", "GetPresentationUML")]
        public string GetPresentationUML()
        {
            StringWriter stringWriter = new StringWriter();
            PlantUMLWriter plantUMLWriter = new PlantUMLWriter();
            plantUMLWriter.Write(_createdWorkspace, stringWriter);  

            return stringWriter.ToString();
        }


        [ScriptConstructor]
        public static OSZWorkspace Constructor(string name, string description)
        {
            Structurizr.Workspace workspace = new Structurizr.Workspace(name,description);
            return new OSZWorkspace(workspace);
        }
    }
}