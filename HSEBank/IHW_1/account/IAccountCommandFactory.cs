using IHW_1.operation;
using IHW_1.statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHW_1.account
{
    // Интерфейс фабрики команд для Account
    internal interface IAccountCommandFactory
    {
        ICommand CreateAddAccountCommand(Account account);
        ICommand CreateRemoveAccountCommand(Guid accountId);
        ICommand CreateChangeAccountNameCommand(Guid accountId, string newName);
        ICommand CreateChangeAccountBalanceCommand(Guid accountId, OperationType operationType, double amount);

    }
}
