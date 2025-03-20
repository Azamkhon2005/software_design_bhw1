using IHW_1.operation;
using IHW_1.statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IHW_1.import_export;
namespace IHW_1.account
{
    // Фасад для работы со счетами
    internal class AccountFacade
    {
        private readonly IAccountCommandFactory accountCommandFactory;
        private readonly AccountService accountService;

        public AccountFacade(AccountService accountService, IAccountCommandFactory accountCommandFactory)
        {
            this.accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
            this.accountCommandFactory = accountCommandFactory ?? throw new ArgumentNullException(nameof(accountCommandFactory));
        }

        public void CreateAccount(Account account)
        {
            try
            {

                ICommand command = accountCommandFactory.CreateAddAccountCommand(account);
                command.Execute();
                Console.WriteLine("created account successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("error creating account");
                Console.WriteLine(ex.Message);
            }
        }

        public void ChangeAccountName(Guid accountId, string newName)
        {
            try
            {
                ICommand command = accountCommandFactory.CreateChangeAccountNameCommand(accountId, newName);
                command.Execute();
                Console.WriteLine("changed name of account successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("error changing name of account");
                Console.WriteLine(ex.Message);
            }

        }

        public void Deposit(Guid accountId, double amount)
        {
            try
            {

                ICommand command = accountCommandFactory.CreateChangeAccountBalanceCommand(accountId, OperationType.Income, amount);
                command.Execute();
                Console.WriteLine("Deposit to account made successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deposit of account");
                Console.WriteLine(ex.Message);
            }
        }

        public void Withdraw(Guid accountId, double amount)
        {
            try
            {
                ICommand command = accountCommandFactory.CreateChangeAccountBalanceCommand(accountId, OperationType.Expense, amount);
                command.Execute();
                Console.WriteLine("withdraw made successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("error withdraw of account");
                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteAccount(Guid accountId)
        {
            try
            {
                ICommand command = accountCommandFactory.CreateRemoveAccountCommand(accountId);
                command.Execute();
                Console.WriteLine("deleted account successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("error deleting of account");
                Console.WriteLine(ex.Message);
            }
        }

        public void ImportJSON(string path)
        {
            try
            {
                accountService.ImportAccounts(new JsonImporter<Account>(), path);
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
                accountService.ImportAccounts(new CsvImporter<Account>(), path);
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
                accountService.ImportAccounts(new YamlImporter<Account>(), path);
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
                accountService.ExportAccounts(new JsonExportVisitor<Account>(), path);
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
                accountService.ExportAccounts(new CsvExportVisitor<Account>(), path);
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
                accountService.ExportAccounts(new YamlExportVisitor<Account>(), path);
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
            foreach(Account account in accountService.GetBankAccounts)
            {
                Console.WriteLine($"{account.Id}  {account.Name}  {account.Balance}");
            }
        }

    }
}
