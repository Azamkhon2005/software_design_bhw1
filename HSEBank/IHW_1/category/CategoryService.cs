using IHW_1.import_export;
using IHW_1.operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHW_1.category
{
    internal class CategoryService
    {
        private readonly List<Category> categories = new();
        public IEnumerable<Category> GetCategories { get { return categories.AsReadOnly(); } }
        public void AddCategory(Category category)
        {
            categories.Add(category);
        }
        public void RemoveCategory(Guid categoryId)
        {
            int res = categories.RemoveAll(category => category.Id.Equals(categoryId));
            if (res == 0)
            {
                throw new ArgumentException("sdsdsd");
            }
        }
        public void ChangeName(Guid id, string name)
        {
            Category res = categories.Find(account => account.Id.Equals(id));
            if (res == null)
            {
                throw new ArgumentException("sdsdsd");
            }
            res.Name = name;
        }
        public void ChangeType(Guid id, OperationType type)
        {
            Category res = categories.Find(account => account.Id.Equals(id));
            if (res == null)
            {
                throw new ArgumentException("sdsdsd");
            }
            res.Type = type;
        }


        public void ExportCategories(IExportVisitor<Category> visitor, string filePath)
        {
            visitor.Visit(categories, filePath);
        }

        public void ImportCategories(DataImporter<Category> importer, string filePath)
        {
            categories.AddRange(importer.Import(filePath));
        }
        public void Show()
        {
            return;
        }

    }
}
