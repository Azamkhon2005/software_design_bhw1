using IHW_1.operation;
using IHW_1.statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHW_1.account
{
    internal class AccountCommandFactory : IAccountCommandFactory
    {
        private readonly AccountService _accountService;

        public AccountCommandFactory(AccountService accountService)
        {
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
        }

        public ICommand CreateAddAccountCommand(Account account)
        {
            return new AddAccountCommand(_accountService, account);
        }

        public ICommand CreateRemoveAccountCommand(Guid accountId)
        {
            return new RemoveAccountCommand(_accountService, accountId);
        }

        public ICommand CreateChangeAccountNameCommand(Guid accountId, string newName)
        {
            return new ChangeAccountNameCommand(_accountService, accountId, newName);
        }

        public ICommand CreateChangeAccountBalanceCommand(Guid accountId, OperationType operationType, double amount)
        {
            return new ChangeAccountBalanceCommand(_accountService, accountId, operationType, amount);
        }

    }
}
