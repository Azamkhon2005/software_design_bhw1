using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.Json;
using CsvHelper;
using CsvHelper.Configuration;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace IHW_1.import_export
{
    abstract class DataImporter<T>
    {
        public List<T> Import(string filePath)
        {
            string fileContent = File.ReadAllText(filePath);
            return ParseData(fileContent);
        }

        protected abstract List<T> ParseData(string content);
    }

    // Конкретные классы импорта
    class JsonImporter<T> : DataImporter<T>
    {
        protected override List<T> ParseData(string content)
        {
            return JsonSerializer.Deserialize<List<T>>(content) ?? new List<T>();
        }
    }

    class YamlImporter<T> : DataImporter<T>
    {
        protected override List<T> ParseData(string content)
        {
            var deserializer = new DeserializerBuilder().Build();
            return deserializer.Deserialize<List<T>>(content) ?? new List<T>();
        }
    }

    class CsvImporter<T> : DataImporter<T>
    {
        protected override List<T> ParseData(string content)
        {
            using var reader = new StringReader(content);
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            };
            using var csv = new CsvReader(reader, config);
            return new List<T>(csv.GetRecords<T>());
        }
    }


}
