using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IHW_1.operation;

namespace IHW_1.category
{


    internal class Category
    {
        private readonly Guid id;
        private OperationType type;
        private string name;

        public Category(OperationType type, string name)
        {
            id = Guid.NewGuid();
            this.type = type;
            this.name = name;
        }

        public Guid Id { get { return id; } }
        public OperationType Type { get { return type; } set { type = value; } }
        public string Name { get { return name; } set { name = value; } }
    }






}
