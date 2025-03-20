using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IHW_1.import_export;

namespace IHW_1.operation
{
    internal class OperationService
    {
        private readonly List<Operation> operations = new();

        public IEnumerable<Operation> GetOperations { get { return operations.AsReadOnly(); } }
        public void AddOperation(Operation operation)
        {
            operations.Add(operation);
        }
        public void RemoveOperation(Guid operationId)
        {
            int res = operations.RemoveAll(operation => operation.Id.Equals(operationId));
            if (res == 0)
            {
                throw new ArgumentException("sdsdsd");
            }
        }

        public void ChangeType(Guid operationId, OperationType type)
        {
            Operation res = operations.Find(operation => operation.Id.Equals(operationId));
            if (res == null)
            {
                throw new ArgumentException("sdsdsd");
            }
            res.Type = type;
        }

        public void ChangeAccountId(Guid operationId, Guid accountId)
        {
            Operation res = operations.Find(operation => operation.Id.Equals(operationId));
            if (res == null)
            {
                throw new ArgumentException("sdsdsd");
            }
            res.AccountId = accountId;
        }

        public void ChangeAmount(Guid operationId, double amount)
        {
            Operation res = operations.Find(operation => operation.Id.Equals(operationId));
            if (res == null)
            {
                throw new ArgumentException("sdsdsd");
            }
            if (amount <= 0)
            {
                throw new ArgumentException("asasas");
            }
            res.Amount = amount;
        }

        public void ChangeDate(Guid operationId, DateTime date)
        {
            Operation res = operations.Find(operation => operation.Id.Equals(operationId));
            if (res == null)
            {
                throw new ArgumentException("sdsdsd");
            }
            res.Date = date;
        }
        public void ChangeDescription(Guid operationId, string description)
        {
            Operation res = operations.Find(operation => operation.Id.Equals(operationId));
            if (res == null)
            {
                throw new ArgumentException("sdsdsd");
            }
            res.Description = description;
        }
        public void ChangeCategoryId(Guid operationId, Guid categoryId)
        {
            Operation res = operations.Find(operation => operation.Id.Equals(operationId));
            if (res == null)
            {
                throw new ArgumentException("sdsdsd");
            }
            res.CategoryId = categoryId;
        }

        public void ExportOperations(IExportVisitor<Operation> visitor, string filePath)
        {
            visitor.Visit(operations, filePath);
        }
        public void ImportOperations(DataImporter<Operation> importer, string filePath)
        {
            operations.AddRange(importer.Import(filePath));
        }

    }
}
