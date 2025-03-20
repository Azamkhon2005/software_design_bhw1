using IHW_1.import_export;
using IHW_1.operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHW_1.account
{
    internal class AccountService
    {
        private readonly List<Account> accounts = new();

        public IEnumerable<Account> GetBankAccounts { get { return accounts.AsReadOnly(); } }

        public void AddAccount(Account bankAccount)
        {
            accounts.Add(bankAccount);
        }
        public void RemoveAccount(Guid accountId)
        {
            int res = accounts.RemoveAll(account => account.Id.Equals(accountId));
            if (res == 0)
            {
                throw new ArgumentException("sdsdsd");
            }
        }
        public void ChangeName(Guid accountId, string newName)
        {
            Account res = accounts.Find(account => account.Id.Equals(accountId));
            if (res == null)
            {
                throw new ArgumentException("sdsdsd");
            }
            res.Name = newName;
        }
        public void ChangeBalance(Guid accountId, OperationType type, double amount)
        {
            Account res = accounts.Find(account => account.Id.Equals(accountId));
            if (res == null)
            {
                throw new ArgumentException($"Счет с ID '{accountId}' не найден.");
            }

            if (type == OperationType.Income)
            {
                res.Deposit(amount);
            }
            else
            {
                res.Withdraw(amount);
            }
        }

        public void ExportAccounts(IExportVisitor<Account> visitor, string filePath)
        {
            visitor.Visit(accounts, filePath);
        }

        public void ImportAccounts(DataImporter<Account> importer, string filePath)
        {
            accounts.AddRange(importer.Import(filePath));
        }
        public void Show()
        {
            foreach (Account acc in accounts)
            {
                Console.WriteLine($"{acc.Id.ToString()}, {acc.Name}, {acc.Balance}");
            }
        }
    }
}
