using ScriptEngine.Machine.Contexts;
using Structurizr.Api;

using System;
using System.Reflection;

using System.IO;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

using Structurizr.IO.PlantUML;
using Structurizr.IO.C4PlantUML;
using Structurizr.IO.C4PlantUML.ModelExtensions;

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
            Model = new ModelImpl(_createdWorkspace.Model);
            Views = new ViewsImpl(_createdWorkspace);
        }

        [ContextProperty("Модель", "Model")]
        public ModelImpl Model { get; private set; }

        [ContextProperty("Представления", "Views")]
        public ViewsImpl Views { get; private set; }

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

        [ContextMethod("ПолучитьПредставлениеUMLC4", "GetPresentationUMLС4")]
        public string GetPresentationUMLС4()
        {
            string C4String = "";
            try
            {
                using (var stringWriter = new StringWriter())
                {
                    var plantUmlWriter = new C4PlantUmlWriter();
                    plantUmlWriter.CustomBaseUrl = "https://raw.githubusercontent.com/kirchsth/C4-PlantUML/master/";
                    plantUmlWriter.Write(
                        _createdWorkspace, stringWriter
                    );
                    C4String = stringWriter.ToString();
                }
            }
            catch (System.Exception ex)
            {

                throw new ScriptEngine.Machine.RuntimeException(
                    "GetPresentationUMLС4 Render Exception",ex
                );
            }

            return C4String;
        }

        [ContextMethod("ЭкспортироватьВоВсеФорматы", "ExportToAllFormats")]
        public void ExportToAllFormats(string fullPath, string filePrefix)
        {
            Directory.CreateDirectory(fullPath);
            using (StreamWriter outputFilejson = new StreamWriter(
                    Path.Combine(fullPath, filePrefix + ".json"), false))
            {
                outputFilejson.WriteLine(GetPresentationJSON());
            }

            using (StreamWriter outputFileC4 = new StreamWriter(
                    Path.Combine(fullPath, filePrefix + "-C4.plantuml"), false))
            {
                outputFileC4.WriteLine(GetPresentationUMLС4());
            }

            using (StreamWriter outputFileUML = new StreamWriter(
                    Path.Combine(fullPath, filePrefix + ".plantuml"), false))
            {
                outputFileUML.WriteLine(GetPresentationUML());
            }
        }

        [ScriptConstructor]
        public static OSZWorkspace Constructor(string name, string description)
        {
            Structurizr.Workspace workspace = 
                new Structurizr.Workspace(name, description);

            return new OSZWorkspace(workspace);
        }
    }
}