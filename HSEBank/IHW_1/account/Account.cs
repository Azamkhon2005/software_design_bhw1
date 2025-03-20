using CsvHelper.Configuration.Attributes;
using IHW_1.operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHW_1.account
{
    internal class Account
    {
        private Guid id;
        private string name;
        private double balance = 0;

        public Account(string name)
        {
            this.name = name;
            this.balance = 0;
            id = Guid.NewGuid();
        }

        public Account(string id, string name)
        {
            this.id = Guid.Parse(id);
            this.name = name;
            this.balance = 0;
        }
        [Name("id")]
        public Guid Id { get { return id; } set { id = value; } }


        [Name("name")]
        public string Name { get { return name; } set { name = value; } }
        public void Withdraw(double amount)
        {
            if (balance > amount)
            {
                balance -= amount;
            }
            else
            {
                throw new ArgumentException("amount of withdraw more than balance");
            }
        }

        public void Deposit(double amount)
        {
            balance += amount;
        }

        [Name("balance")]
        public double Balance { get { return balance; } set { balance = value; } }
    }

}
