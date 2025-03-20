using IHW_1.operation;
using IHW_1.statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHW_1.category
{
    // Интерфейс фабрики команд для Category
    internal interface ICategoryCommandFactory
    {
        ICommand CreateAddCategoryCommand(Category category);
        ICommand CreateRemoveCategoryCommand(Guid categoryId);
        ICommand CreateChangeCategoryNameCommand(Guid categoryId, string newName);
        ICommand CreateChangeCategoryTypeCommand(Guid categoryId, OperationType newType);
    }
}
