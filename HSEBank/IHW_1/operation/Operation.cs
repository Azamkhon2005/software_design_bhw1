using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace IHW_1.operation
{
    public enum OperationType
    {
        Income,
        Expense
    }



    internal class Operation
    {
        private Guid id;
        private OperationType type;
        private Guid accountId;
        private double amount;
        private DateTime date;
        private string description; // Optional field
        private Guid categoryId;


        public Operation(OperationType type, Guid bankAccountId, double amount, DateTime date, Guid categoryId, string description)
        {
            id = Guid.NewGuid(); // Generate a unique ID
            this.type = type;
            accountId = bankAccountId;
            this.amount = amount;
            this.date = date;
            this.categoryId = categoryId;
            this.description = description;

        }


        // Public properties with getters (and private setters where applicable)
        public Guid Id { get { return id; } }
        public OperationType Type { get { return type; } set { type = value; } }
        public Guid AccountId { get { return accountId; } set { accountId = value; } }
        public double Amount { get { return amount; } set { amount = value; } }
        public DateTime Date { get { return date; } set { date = value; } }
        public string Description { get { return description; } set { description = value; } }
        public Guid CategoryId { get { return categoryId; } set { categoryId = value; } }



    }


    

    




}
