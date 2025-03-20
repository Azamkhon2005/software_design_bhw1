using IHW_1.operation;
using IHW_1.statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHW_1.category
{
    // Реализация фабрики команд для Category
    internal class CategoryCommandFactory : ICategoryCommandFactory
    {
        private readonly CategoryService _categoryService;

        public CategoryCommandFactory(CategoryService categoryService)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        public ICommand CreateAddCategoryCommand(Category category)
        {
            return new AddCategoryCommand(_categoryService, category);
        }

        public ICommand CreateRemoveCategoryCommand(Guid categoryId)
        {
            return new RemoveCategoryCommand(_categoryService, categoryId);
        }

        public ICommand CreateChangeCategoryNameCommand(Guid categoryId, string newName)
        {
            return new ChangeCategoryNameCommand(_categoryService, categoryId, newName);
        }
        public ICommand CreateChangeCategoryTypeCommand(Guid categoryId, OperationType newType)
        {
            return new ChangeCategoryTypeCommand(_categoryService, categoryId, newType);
        }
    }
}
