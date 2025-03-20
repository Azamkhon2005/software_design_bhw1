using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IHW_1.statistics;

namespace IHW_1.operation
{
    internal class AddOperationCommand : ICommand
    {
        private readonly OperationService service;
        private readonly Operation operation;
        public AddOperationCommand(OperationService service, Operation operation)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.operation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public void Execute()
        {
            service.AddOperation(operation);
        }
    }

    internal class RemoveOperationCommand : ICommand
    {
        private readonly OperationService service;
        private readonly Guid id;
        public RemoveOperationCommand(OperationService service, Guid id)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.id = id;
        }

        public void Execute()
        {
            service.RemoveOperation(id);
        }
    }

    internal class ChangeOperationTypeCommand : ICommand
    {
        private readonly OperationService service;
        private readonly Guid id;
        private readonly OperationType type;

        public ChangeOperationTypeCommand(OperationService service, Guid id, OperationType type)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.id = id;
            this.type = type;
        }

        public void Execute()
        {
            service.ChangeType(id, type);
        }
    }


    internal class ChangeOperationAccountIdCommand : ICommand
    {
        private readonly OperationService service;
        private readonly Guid id;
        private readonly Guid accountId;

        public ChangeOperationAccountIdCommand(OperationService service, Guid id, Guid accountId)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.id = id;
            this.accountId = accountId;
        }

        public void Execute()
        {
            service.ChangeAccountId(id, accountId);
        }
    }

    internal class ChangeOperationAmountCommand : ICommand
    {
        private readonly OperationService service;
        private readonly Guid id;
        private readonly double amount;

        public ChangeOperationAmountCommand(OperationService service, Guid id, double amount)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.id = id;
            this.amount = amount;
        }

        public void Execute()
        {
            service.ChangeAmount(id, amount);
        }
    }

    internal class ChangeOperationDateCommand : ICommand
    {
        private readonly OperationService service;
        private readonly Guid id;
        private readonly DateTime date;

        public ChangeOperationDateCommand(OperationService service, Guid id, DateTime date)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.id = id;
            this.date = date;
        }

        public void Execute()
        {
            service.ChangeDate(id, date);
        }
    }

    internal class ChangeOperationDescriptionCommand : ICommand
    {
        private readonly OperationService service;
        private readonly Guid id;
        private readonly string text;

        public ChangeOperationDescriptionCommand(OperationService service, Guid id, string text)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.id = id;
            this.text = text;
        }

        public void Execute()
        {
            service.ChangeDescription(id, text);
        }
    }


    internal class ChangeOperationCategoryIdCommand : ICommand
    {
        private readonly OperationService service;
        private readonly Guid id;
        private readonly Guid categoryId;

        public ChangeOperationCategoryIdCommand(OperationService service, Guid id, Guid categoryId)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.id = id;
            this.categoryId = categoryId;
        }

        public void Execute()
        {
            service.ChangeCategoryId(id, categoryId);
        }
    }
}
