using MS.Infrastructure;
using MS.Services.FileManager;
using Newtonsoft.Json;
using System;
using System.Text;

namespace MS.Services.JsonFileGenerator
{
    public class JsonFileGenerator
    {
        private IFileManager fileManager;

        public JsonFileGenerator(IFileManager fileManager)
        {
            this.fileManager = fileManager;
        }

        public void Generate(Object objectToSerialize)
        {
            string supplyDocumentToJson = JsonConvert.SerializeObject(objectToSerialize, Formatting.Indented);

            this.fileManager.WriteFile(Encoding.ASCII.GetBytes(supplyDocumentToJson), null, GlobalConstants.JsonMoviesFileName);
        }
    }
}
