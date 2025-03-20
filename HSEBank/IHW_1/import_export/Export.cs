using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace IHW_1.import_export
{
    // Паттерн "Посетитель" для экспорта данных
    interface IExportVisitor<T>
    {
        void Visit(List<T> data, string filePath);
    }

    class JsonExportVisitor<T> : IExportVisitor<T>
    {
        public void Visit(List<T> data, string filePath)
        {
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
    }

    class YamlExportVisitor<T> : IExportVisitor<T>
    {
        public void Visit(List<T> data, string filePath)
        {
            var serializer = new SerializerBuilder().Build();
            string yaml = serializer.Serialize(data);
            File.WriteAllText(filePath, yaml);
        }
    }

    class CsvExportVisitor<T> : IExportVisitor<T>
    {
        public void Visit(List<T> data, string filePath)
        {
            using var writer = new StreamWriter(filePath);
            using var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture));
            csv.WriteRecords(data);
        }
    }
}
