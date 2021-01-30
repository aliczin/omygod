using ScriptEngine.Machine.Contexts;
using Structurizr.Api;

using System;
using System.Reflection;

using System.IO;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

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
            _createdWorkspace = createdWorkspace;
        }

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

        [ScriptConstructor]
        public static OSZWorkspace Constructor(string name, string description)
        {
            Structurizr.Workspace workspace = new Structurizr.Workspace(name,description);
            return new OSZWorkspace(workspace);
        }
    }
}