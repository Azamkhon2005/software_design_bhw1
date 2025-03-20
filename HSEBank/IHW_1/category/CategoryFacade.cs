using IHW_1.account;
using IHW_1.operation;
using IHW_1.statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IHW_1.import_export;
namespace IHW_1.category
{
    // Фасад для работы с категориями
    internal class CategoryFacade
    {
        private readonly ICategoryCommandFactory categoryCommandFactory;
        private readonly CategoryService categoryService;

        public CategoryFacade(CategoryService categoryService, ICategoryCommandFactory categoryCommandFactory)
        {
            this.categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            this.categoryCommandFactory = categoryCommandFactory ?? throw new ArgumentNullException(nameof(categoryCommandFactory));
        }

        public void CreateCategory(Category category)
        {
            try
            {
                ICommand command = categoryCommandFactory.CreateAddCategoryCommand(category);
                command.Execute();
                Console.WriteLine("category successfully created");
            }
            catch (Exception ex)
            {
                Console.WriteLine("error creating category");
                Console.WriteLine(ex.Message);
            }

        }

        public void ChangeCategoryName(Guid categoryId, string newName)
        {
            try
            {
                ICommand command = categoryCommandFactory.CreateChangeCategoryNameCommand(categoryId, newName);
                command.Execute();
                Console.WriteLine("category name changed successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("error changing name of category");
                Console.WriteLine(ex.Message);
            }
        }

        public void ChangeCategoryType(Guid categoryId, OperationType newType)
        {
            try
            {

                ICommand command = categoryCommandFactory.CreateChangeCategoryTypeCommand(categoryId, newType);
                command.Execute();
                Console.WriteLine("category type changed successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("error changing type of category");
                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteCategory(Guid categoryId)
        {
            try
            {

                ICommand command = categoryCommandFactory.CreateRemoveCategoryCommand(categoryId);
                command.Execute();
                Console.WriteLine("category deleted successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("error deleting category");
                Console.WriteLine(ex.Message);
            }
        }

        public void ImportJSON(string path)
        {
            try
            {
                categoryService.ImportCategories(new JsonImporter<Category>(), path);
                Console.WriteLine("json file imported successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error importing json file:");
                Console.WriteLine(ex.Message);
            }
        }

        public void ImportCSV(string path)
        {
            try
            {
                categoryService.ImportCategories(new CsvImporter<Category>(), path);
                Console.WriteLine("csv file imported successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error importing json file:");
                Console.WriteLine(ex.Message);
            }
        }
        public void ImportYaml(string path)
        {
            try
            {
                categoryService.ImportCategories(new YamlImporter<Category>(), path);
                Console.WriteLine("yaml file imported successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error importing yaml file:");
                Console.WriteLine(ex.Message);
            }
        }
        public void ExportJSON(string path)
        {
            try
            {
                categoryService.ExportCategories(new JsonExportVisitor<Category>(), path);
                Console.WriteLine("data exported to json file successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error exporting to json file:");
                Console.WriteLine(ex.Message);
            }
        }
        public void ExportCSV(string path)
        {
            try
            {
                categoryService.ExportCategories(new CsvExportVisitor<Category>(), path);
                Console.WriteLine("data exported to csv file successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error exporting to csv file:");
                Console.WriteLine(ex.Message);
            }
        }
        public void ExportYaml(string path)
        {
            try
            {
                categoryService.ExportCategories(new YamlExportVisitor<Category>(), path);
                Console.WriteLine("data exported to yaml file successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error exporting to yaml file:");
                Console.WriteLine(ex.Message);
            }
        }
        public void Show()
        {
            foreach(Category i in categoryService.GetCategories)
            {

                Console.WriteLine($"{i.Id}  {i.Name}  {i.Type}");
            }
        }
    }
}
