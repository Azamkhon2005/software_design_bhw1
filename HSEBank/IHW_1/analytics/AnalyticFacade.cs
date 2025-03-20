using IHW_1.operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHW_1.analytics
{
    internal class AnalyticFacade
    {
        private readonly AnaliticService service;
        public AnalyticFacade(AnaliticService service)
        {
            this.service = service ?? throw new Exception(nameof(AnaliticService));
        }
        public void CalculateBalance(DateTime start, DateTime end, Guid id)
        {
            try
            {
                double result = service.CalculateBalance(start, end, id);
                Console.WriteLine($"difference between income and expenses for a given period {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("error calculating balance");
                Console.WriteLine(ex.Message );
            }
        }
        public void GroupByCategoryAndType(DateTime start, DateTime end, Guid id)
        {
            try
            {
                Dictionary<string, Dictionary<OperationType, double>> categoryTypeTotals = service.GroupByCategoryAndType(start, end, id);
                Console.WriteLine("Expenses by Category and Type:");
                foreach (var categoryGroup in categoryTypeTotals)
                {
                    Console.Write($"Category: {categoryGroup.Key}");
                    foreach (var typeGroup in categoryGroup.Value)
                    {
                        Console.WriteLine($"  {typeGroup.Key}: {typeGroup.Value}");
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("error:");
                Console.WriteLine(ex.Message );
            }
            
        }
    }
}
