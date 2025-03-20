using IHW_1.account;
using IHW_1.operation;
using IHW_1.category;
using System;
using IHW_1.statistics;
using IHW_1;
using IHW_1.analytics;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;





public class Program
{
    private static AccountFacade accountMenu;
    private static CategoryFacade categoryMenu;
    private static OperationFacade operationMenu;
    private static AnalyticFacade analyticsMenu;
    private static RecalculationService recalculationService;
    public static void Main(string[] args)
    {
        try {
            IServiceProvider service = DIConfig.ConfigureServices();
            accountMenu = service.GetRequiredService<AccountFacade>();
            categoryMenu = service.GetRequiredService<CategoryFacade>();
            analyticsMenu = service.GetRequiredService<AnalyticFacade>();
            recalculationService = service.GetRequiredService<RecalculationService>();

            while (true)
            {

                Console.Clear();
                ShowMainMenu();
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AccountsMenu();
                        break;
                    case "2":
                        CategoriesMenu();
                        break;
                    case "3":
                        OperationsMenu();
                        break;
                    case "4":
                        Analytics();
                        break;
                    case "5":
                        ImportExportData();
                        break;
                    case "6":
                        RecalculateBalances();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор!");
                        break;
                }
            }

        }
        catch(Exception ex)
        {
            Console.WriteLine("Something went wronge");
            Console.WriteLine(ex.Message);
        }


    }

    static void ShowMainMenu()
    {
        Console.WriteLine("=== Учет финансов ===");
        Console.WriteLine("1. Управление счетами");
        Console.WriteLine("2. Управление категориями");
        Console.WriteLine("3. Управление операциями");
        Console.WriteLine("4. Аналитика");
        Console.WriteLine("5. Импорт/Экспорт");
        Console.WriteLine("6. Пересчет балансов");
        Console.WriteLine("0. Выход");
        Console.Write("Выберите действие: ");
    }
    static void AccountsMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Управление счетами ===");
            Console.WriteLine("1. Создать счет");
            Console.WriteLine("2. Список счетов");
            Console.WriteLine("3. Назад");
            Console.Write("Выберите действие: ");

            switch (Console.ReadLine())
            {
                case "1":
                    CreateAccount();
                    break;
                case "2":
                    ShowAccounts();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Неверный выбор!");
                    break;
            }
        }
    }

    static void CreateAccount()
    {
        Console.Write("Введите название счета: ");
        var name = Console.ReadLine();

        var account = new Account(name);

        accountMenu.CreateAccount(account);

    }

    static void ShowAccounts()
    {
        Console.WriteLine("\nСписок счетов:");
        accountMenu.Show();
        Console.WriteLine("\nНажмите любую клавишу...");
        Console.ReadKey();
    }

    static void CategoriesMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Управление категориями ===");
            Console.WriteLine("1. Создать категорию");
            Console.WriteLine("2. Список категорий");
            Console.WriteLine("3. Назад");
            Console.Write("Выберите действие: ");

            switch (Console.ReadLine())
            {
                case "1":
                    CreateCategory();
                    break;
                case "2":
                    ShowCategories();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Неверный выбор!");
                    break;
            }
        }
    }

    static void CreateCategory()
    {
        try
        {
            Console.Write("Тип категории (1 - Доход, 2 - Расход): ");
            var typeInput = Console.ReadLine();
            var type = typeInput == "1" ? OperationType.Income : OperationType.Expense;

            Console.Write("Название категории: ");
            var name = Console.ReadLine();

            var category = new Category(type, name);
            categoryMenu.CreateCategory(category);

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }

    static void ShowCategories()
    {
        Console.WriteLine("\nСписок категорий:");
        categoryMenu.Show();
        Console.WriteLine("\nНажмите любую клавишу...");
        Console.ReadKey();
    }

    static void OperationsMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Управление операциями ===");
            Console.WriteLine("1. Добавить операцию");
            Console.WriteLine("2. История операций");
            Console.WriteLine("3. Назад");
            Console.Write("Выберите действие: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AddOperation();
                    break;
                case "2":
                    ShowOperationHistory();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Неверный выбор!");
                    break;
            }
        }
    }

    static void AddOperation()
    {
        try
        {
            Console.Write("Тип операции (1 - Доход, 2 - Расход): ");
            var typeInput = Console.ReadLine();
            var type = typeInput == "1" ? OperationType.Income : OperationType.Expense;

            Console.Write("Сумма: ");
            var amount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Дата операции (гггг-мм-дд): ");
            var date = DateTime.Parse(Console.ReadLine());

            Console.Write("Описание: ");
            var description = Console.ReadLine();

            ShowAccounts();
            Console.Write("ID счета: ");
            var accountId = Guid.Parse(Console.ReadLine());

            

            Console.WriteLine("Доступные категории:");
            categoryMenu.Show();

            Console.Write("ID категории: ");
            var categoryId = Guid.Parse(Console.ReadLine());

            var operation = new Operation(
                type,
                accountId,
                amount,
                date,
                categoryId,
                description
            );

            operationMenu.CreateOperation(operation);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }

    static void ShowOperationHistory()
    {
        Console.WriteLine("\nИстория операций:");
        operationMenu.Show();
        Console.WriteLine("\nНажмите любую клавишу...");
        Console.ReadKey();
    }

    static void Analytics()
    {

        
        Console.Clear();
        Console.WriteLine("=== Финансовая аналитика ===");

        accountMenu.Show();
        Console.WriteLine("ID аккаунта:");
        var id = Console.ReadLine();


        
        Console.Write("Начальная дата (гггг-мм-дд): ");
        var start = DateTime.Parse(Console.ReadLine());

        Console.Write("Конечная дата (гггг-мм-дд): ");
        var end = DateTime.Parse(Console.ReadLine());

        analyticsMenu.CalculateBalance(start, end, Guid.Parse(id));
        Console.WriteLine("\nРасходы по категориям:");
        analyticsMenu.GroupByCategoryAndType(start, end, Guid.Parse(id));
        Console.WriteLine("\nНажмите любую клавишу...");
        Console.ReadKey();
    }

    static void ImportExportData()
    {
        Console.Clear();
        Console.WriteLine("=== Импорт/Экспорт ===");
        Console.WriteLine("1. Экспорт из CSV");
        Console.WriteLine("2. Экспорт в JSON");
        Console.WriteLine("3. Экспорт в YAML");

        Console.WriteLine("4. Импорт из CSV");
        Console.WriteLine("5. Импорт из JSON");
        Console.WriteLine("6. Импорт из YAML");

        Console.WriteLine("7. Назад");
        Console.Write("Выберите действие: ");

        var choice = Console.ReadLine();
        if (choice == "1")
        {
            accountMenu.ExportCSV("account.csv");
            categoryMenu.ExportCSV("category.csv");
            operationMenu.ExportCSV("operation.csv");
        }
        else if (choice == "2")
        {
            accountMenu.ExportJSON("account.json");
            categoryMenu.ExportJSON("category.json");
            operationMenu.ExportJSON("operation.json");
        }
        else if (choice == "3")
        {
            accountMenu.ExportYaml("account.yaml");
            categoryMenu.ExportYaml("category.yaml");
            operationMenu.ExportYaml("operation.yaml");
        }
        else if (choice == "4")
        {
            accountMenu.ImportCSV("account.csv");
            categoryMenu.ImportCSV("category.csv");
            operationMenu.ImportCSV("operation.csv");
        }
        else if (choice == "5")
        {
            accountMenu.ImportJSON("account.json");
            categoryMenu.ImportJSON("category.json");
            operationMenu.ImportJSON("operation.json");
        }
        else if (choice == "6")
        {
            accountMenu.ExportYaml("category_export.yaml");
            categoryMenu.ExportYaml("operation_export.yaml");
            operationMenu.ExportYaml("category_export.yaml");
        }
    }

    static void RecalculateBalances()
    {
        
        recalculationService.RecalculateAllBalances();
    }
}
/*
 
        var operationService = new OperationService();
        var accountService = new AccountService();
        var categoryService = new CategoryService();

        accountService.ImportAccounts(new CsvImporter<Account>(), "C:\\Users\\abuzu\\OneDrive\\Рабочий стол\\test.csv");
        accountService.ExportAccounts(new CsvExportVisitor<Account>(), "C:\\Users\\abuzu\\OneDrive\\Рабочий стол\\suka.csv");








 
BankAccount res1 = new BankAccount("goyda");
BankAccountService service = new BankAccountService();
service.AddBankAccount(res1);
service.ChangeAccountBalance(1, "income", 20);

service.Show();





 FinanceManager financeManager = new FinanceManager();

        // Create some categories
        Category foodCategory = new Category(OperationType.Expense, "Food");
        Category salaryCategory = new Category(OperationType.Income, "Salary");
        Category rentCategory = new Category(OperationType.Expense, "Rent");
        Category investmentCategory = new Category(OperationType.Income, "Investments");
        financeManager.AddCategory(foodCategory);
        financeManager.AddCategory(salaryCategory);
        financeManager.AddCategory(rentCategory);
        financeManager.AddCategory(investmentCategory);



        // Create some operations
        Guid accountId = Guid.NewGuid();
        financeManager.AddOperation(new Operation(OperationType.Income, accountId, 2500, DateTime.Parse("2023-10-01"), salaryCategory.Id, "October Salary"));
        financeManager.AddOperation(new Operation(OperationType.Expense, accountId, 100, DateTime.Parse("2023-10-05"), foodCategory.Id, "Groceries"));
        financeManager.AddOperation(new Operation(OperationType.Expense, accountId, 800, DateTime.Parse("2023-10-10"), rentCategory.Id, "Monthly Rent"));
        financeManager.AddOperation(new Operation(OperationType.Expense, accountId, 50, DateTime.Parse("2023-10-15"), foodCategory.Id, "Restaurant"));
        financeManager.AddOperation(new Operation(OperationType.Income, accountId, 300, DateTime.Parse("2023-10-20"), investmentCategory.Id, "Stock Dividends"));
        financeManager.AddOperation(new Operation(OperationType.Expense, accountId, 75, DateTime.Parse("2023-10-25"), foodCategory.Id, "Coffee"));

        // Add operation with no category (for testing uncategorized)
        financeManager.AddOperation(new Operation(OperationType.Expense, accountId, 25, DateTime.Parse("2023-10-28"), Guid.Empty, "Unknown expense"));


        // Calculate the balance for October.
        DateTime startDate = DateTime.Parse("2023-10-01");
        DateTime endDate = DateTime.Parse("2023-10-31");
        double balance = financeManager.CalculateBalance(startDate, endDate);
        Console.WriteLine($"Balance for October: {balance}");  // Output the balance


        
        Dictionary<string, Dictionary<OperationType, double>> categoryTypeTotals = financeManager.GroupByCategoryAndType(startDate, endDate);
        Console.WriteLine("\nOctober Expenses by Category and Type:");
        foreach (var categoryGroup in categoryTypeTotals)
        {
            Console.WriteLine($"Category: {categoryGroup.Key}");
            foreach (var typeGroup in categoryGroup.Value)
            {
                Console.WriteLine($"  {typeGroup.Key}: {typeGroup.Value}");
            }
        }

        //List all the operations
        Console.WriteLine("\nOperations:");
        List<Operation> allOperations = financeManager.GetOperations();

        foreach (Operation op in allOperations)
        {
            string categoryName = (financeManager.GetCategoryById(op.CategoryId) != null) ? financeManager.GetCategoryById(op.CategoryId).Name : "Uncategorized";
            Console.WriteLine($"  {op.Date} - {op.Type} - {categoryName} - {op.Amount} - {op.Description}");
        }

  */