using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IHW_1.account;
using IHW_1.analytics;
using IHW_1.category;
using IHW_1.operation;
using Microsoft.Extensions.DependencyInjection;
using IHW_1.statistics;
namespace IHW_1
{
    public static class DIConfig
    {
        public static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            // account
            services.AddSingleton<AccountService>();
            services.AddSingleton<IAccountCommandFactory, AccountCommandFactory>();
            services.AddSingleton<AccountFacade>();

            // category
            services.AddSingleton<CategoryService>();
            services.AddSingleton<ICategoryCommandFactory, CategoryCommandFactory>();
            services.AddSingleton<CategoryFacade>();

            // operation
            services.AddSingleton<OperationService>();
            services.AddSingleton<IOperationCommandFactory, OperationCommandFactory>();
            services.AddSingleton<OperationFacade>();

            // analytics
            services.AddSingleton<AnaliticService>();
            services.AddSingleton<AnalyticFacade>();

            // recalculation service
            services.AddSingleton<RecalculationService>();

            // statistics
            services.AddSingleton<ICommand ,TimingCommandDecorator>();
            services.AddSingleton<Statistics>();
            
            var result = services.BuildServiceProvider();
            return result;
        }
    }
}
