using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IHW_1.statistics;

namespace IHW_1.operation
{
    internal interface IOperationCommandFactory
    {
        ICommand CreateAddOperationCommand(Operation operation);
        ICommand CreateRemoveOperationCommand(Guid id);
        ICommand CreateChangeOperationTypeCommand(Guid id, OperationType type);

        ICommand CreateChangeOperationAccountIdCommand(Guid id, Guid accountId);
        ICommand CreateChangeOperationAmountCommand(Guid id, double amount);

        ICommand CreateChangeOperationDateCommand(Guid id, DateTime date);

        ICommand CreateChangeOperationDescriptionCommand(Guid id, string text);
        ICommand CreateChangeOperationCategoryIdCommand(Guid id, Guid categoryId);
    }
}
