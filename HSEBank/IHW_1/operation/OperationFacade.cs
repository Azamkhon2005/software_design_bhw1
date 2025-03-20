using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IHW_1.statistics;
using IHW_1.import_export;
namespace IHW_1.operation
{
    internal class OperationFacade
    {
        private readonly OperationService operationService;
        private readonly IOperationCommandFactory operationCommandFactory;

        public OperationFacade(OperationService operationService, IOperationCommandFactory operationCommandFactory)
        {
            this.operationService = operationService ?? throw new ArgumentNullException(nameof(operationService));
            this.operationCommandFactory = operationCommandFactory ?? throw new ArgumentNullException(nameof(operationCommandFactory));
        }

        public void CreateOperation(Operation operation)
        {
            try
            {
                ICommand command = operationCommandFactory.CreateAddOperationCommand(operation);
                command.Execute();
                Console.WriteLine("operation successfully created");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error creating account:");
                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteOperation(Guid id)
        {
            try
            {
                ICommand command = operationCommandFactory.CreateRemoveOperationCommand(id);
                command.Execute();
                Console.WriteLine("operation successfully deleted");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting operation:");
                Console.WriteLine(ex.Message);
            }
        }
        public void ChangeType(Guid id, OperationType type)
        {
            try
            {
                ICommand command = operationCommandFactory.CreateChangeOperationTypeCommand(id, type);
                command.Execute();
                Console.WriteLine("operation type successfully changed");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error changing type of operation:");
                Console.WriteLine(ex.Message);
            }
        }
        public void ChangeAccountId(Guid id, Guid accountId)
        {
            try
            {
                ICommand command = operationCommandFactory.CreateChangeOperationAccountIdCommand(id, accountId);
                command.Execute();
                Console.WriteLine("operation account id successfully changed");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error changing account id of operation:");
                Console.WriteLine(ex.Message);
            }
        }

        public void ChangeAmount(Guid id, double amount)
        {
            try
            {
                ICommand command = operationCommandFactory.CreateChangeOperationAmountCommand(id, amount);
                command.Execute();
                Console.WriteLine("operation amount successfully changed");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error changing amount of operation:");
                Console.WriteLine(ex.Message);
            }
        }
        public void ChangeDate(Guid id, DateTime date)
        {
            try
            {
                ICommand command = operationCommandFactory.CreateChangeOperationDateCommand(id, date);
                command.Execute();
                Console.WriteLine("operation date successfully changed");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error changing date of operation:");
                Console.WriteLine(ex.Message);
            }
        }
        public void ChangeDescription(Guid id, string text)
        {
            try
            {
                ICommand command = operationCommandFactory.CreateChangeOperationDescriptionCommand(id, text);
                command.Execute();
                Console.WriteLine("operation description successfully changed");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error changing description of operation:");
                Console.WriteLine(ex.Message);
            }
        }
        public void ChangeCategoryId(Guid id, Guid categoryId)
        {
            try
            {
                ICommand command = operationCommandFactory.CreateChangeOperationCategoryIdCommand(id, categoryId);
                command.Execute();
                Console.WriteLine("operation category id successfully changed");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error changing category id of operation:");
                Console.WriteLine(ex.Message);
            }
        }


        public void ImportJSON(string path)
        {
            try
            {
                operationService.ImportOperations(new JsonImporter<Operation>(), path);
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
                operationService.ImportOperations(new CsvImporter<Operation>(), path);
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
                operationService.ImportOperations(new YamlImporter<Operation>(), path);
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
                operationService.ExportOperations(new JsonExportVisitor<Operation>(), path);
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
                operationService.ExportOperations(new CsvExportVisitor<Operation>(), path);
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
                operationService.ExportOperations(new YamlExportVisitor<Operation>(), path);
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
            foreach(Operation i in operationService.GetOperations)
            {
                Console.WriteLine($"{i.Id} {i.AccountId} {i.Type} {i.CategoryId} {i.Date} {i.Amount} {i.Description}");
            }
        }
    }
}
