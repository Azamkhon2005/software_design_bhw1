using IHW_1.account;
using IHW_1.operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHW_1.analytics
{
    internal class RecalculationService
    {
        private  AccountService accounts = new();
        private  OperationService operations = new();

        public RecalculationService(AccountService accounts, OperationService operations)
        {
            this.accounts = accounts;
            this.operations = operations;
        }

        public void RecalculateAllBalances()
        {
            foreach (var account in accounts.GetBankAccounts)
            {
                RecalculateBalance(account.Id);
            }
        }
        public void RecalculateBalance(Guid accountId)
        {
            Account res = accounts.GetBankAccounts.ToList().Find(account => account.Id.Equals(accountId));
            if (res == null) return;

            var operations = this.operations.GetOperations.Where(o => o.AccountId == accountId);

            double newBalance = operations
                .Sum(o => o.Type == OperationType.Income ? o.Amount : -o.Amount);

            res.Balance += newBalance;
        }
    }
}
