using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IHW_1.category;
using IHW_1.operation;

namespace IHW_1.analytics
{



    internal class AnaliticService
    {
        private IEnumerable<Operation> operations;
        private IEnumerable<Category> categories;

        public AnaliticService(IEnumerable<Operation> operations, IEnumerable<Category> categories)
        {
            this.operations = operations;
            this.categories = categories;
        }


        private Category GetCategoryById(Guid categoryId)
        {
            return categories.FirstOrDefault(c => c.Id == categoryId);
        }


        // 1. Calculate the difference between income and expenses for a given period.
        public double CalculateBalance(DateTime startDate, DateTime endDate, Guid accountId)
        {
            // Filter operations within the specified date range.
            var operationsInPeriod = operations.Where(o => o.Date >= startDate && o.Date <= endDate && o.AccountId == accountId);

            // Calculate total income.
            double totalIncome = operationsInPeriod
                .Where(o => o.Type == OperationType.Income)
                .Sum(o => o.Amount);

            double totalExpenses = operationsInPeriod
                .Where(o => o.Type == OperationType.Expense)
                .Sum(o => o.Amount);

            return totalIncome - totalExpenses;
        }




        public Dictionary<string, Dictionary<OperationType, double>> GroupByCategoryAndType(DateTime startDate, DateTime endDate, Guid accountId)
        {
            var operationsInPeriod = operations.Where(o => o.Date >= startDate && o.Date <= endDate && o.AccountId == accountId);

            var groupedOperations = operationsInPeriod
                .GroupBy(o => o.CategoryId)
                .Select(group =>
                {
                    var category = GetCategoryById(group.Key);
                    var categoryName = category != null ? category.Name : "Uncategorized";
                    return new
                    {
                        CategoryName = categoryName,
                        Operations = group.ToList()
                    };
                })
                .ToDictionary(
                    item => item.CategoryName,
                    item => item.Operations
                        .GroupBy(o => o.Type)
                        .ToDictionary(typeGroup => typeGroup.Key, typeGroup => typeGroup.Sum(o => o.Amount))
                );

            return groupedOperations;
        }


    }

}
