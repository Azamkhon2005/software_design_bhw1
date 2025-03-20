using IHW_1.operation;
using IHW_1.statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHW_1.account
{
    // Команды для AccountService
    internal class AddAccountCommand : ICommand
    {
        private readonly AccountService _accountService;
        private readonly Account _account;

        public AddAccountCommand(AccountService accountService, Account account)
        {
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
            _account = account ?? throw new ArgumentNullException(nameof(account));
        }

        public void Execute()
        {
            _accountService.AddAccount(_account);
        }
    }

    internal class RemoveAccountCommand : ICommand
    {
        private readonly AccountService _accountService;
        private readonly Guid _accountId;

        public RemoveAccountCommand(AccountService accountService, Guid accountId)
        {
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
            _accountId = accountId;
        }

        public void Execute()
        {
            _accountService.RemoveAccount(_accountId);
        }
    }

    internal class ChangeAccountNameCommand : ICommand
    {
        private readonly AccountService _accountService;
        private readonly Guid _accountId;
        private readonly string _newName;

        public ChangeAccountNameCommand(AccountService accountService, Guid accountId, string newName)
        {
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
            _accountId = accountId;
            _newName = newName ?? throw new ArgumentNullException(nameof(newName));
        }

        public void Execute()
        {
            _accountService.ChangeName(_accountId, _newName);
        }
    }

    internal class ChangeAccountBalanceCommand : ICommand
    {
        private readonly AccountService _accountService;
        private readonly Guid _accountId;
        private readonly OperationType _operationType;
        private readonly double _amount;

        public ChangeAccountBalanceCommand(AccountService accountService, Guid accountId, OperationType operationType, double amount)
        {
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
            _accountId = accountId;
            _operationType = operationType;
            _amount = amount;
        }

        public void Execute()
        {
            _accountService.ChangeBalance(_accountId, _operationType, _amount);
        }
    }
}
