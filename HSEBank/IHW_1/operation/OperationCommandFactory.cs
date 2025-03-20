using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IHW_1.statistics;

namespace IHW_1.operation
{
    internal class OperationCommandFactory : IOperationCommandFactory
    {
        private readonly OperationService operationService;
        public OperationCommandFactory(OperationService operationService)
        {
            this.operationService = operationService ?? throw new ArgumentNullException(nameof(operationService));
        }

        public ICommand CreateAddOperationCommand(Operation operation)
        {
            return new AddOperationCommand(operationService, operation);
        }

        public ICommand CreateRemoveOperationCommand(Guid id)
        {
            return new RemoveOperationCommand(operationService, id);
        }

        public ICommand CreateChangeOperationTypeCommand(Guid id, OperationType type)
        {
            return new ChangeOperationTypeCommand(operationService, id, type);
        }


        public ICommand CreateChangeOperationAccountIdCommand(Guid id, Guid accountId)
        {
            return new ChangeOperationAccountIdCommand(operationService, id, accountId);
        }
        public ICommand CreateChangeOperationAmountCommand(Guid id, double amount)
        {
            return new ChangeOperationAmountCommand(operationService, id, amount);
        }

        public ICommand CreateChangeOperationDateCommand(Guid id, DateTime date)
        {
            return new ChangeOperationDateCommand(operationService, id, date);
        }

        public ICommand CreateChangeOperationDescriptionCommand(Guid id, string text)
        {
            return new ChangeOperationDescriptionCommand(operationService, id, text);
        }

        public ICommand CreateChangeOperationCategoryIdCommand(Guid id, Guid categoryId)
        {
            return new ChangeOperationCategoryIdCommand(operationService, id, categoryId);
        }
    }

}
