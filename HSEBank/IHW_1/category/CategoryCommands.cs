using IHW_1.operation;
using IHW_1.statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHW_1.category
{
    // Команды для CategoryService

    internal class AddCategoryCommand : ICommand
    {
        private readonly CategoryService _categoryService;
        private readonly Category _category;

        public AddCategoryCommand(CategoryService categoryService, Category category)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            _category = category ?? throw new ArgumentNullException(nameof(category));
        }

        public void Execute()
        {
            _categoryService.AddCategory(_category);
        }
    }

    internal class RemoveCategoryCommand : ICommand
    {
        private readonly CategoryService _categoryService;
        private readonly Guid _categoryId;

        public RemoveCategoryCommand(CategoryService categoryService, Guid categoryId)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            _categoryId = categoryId;
        }

        public void Execute()
        {
            _categoryService.RemoveCategory(_categoryId);
        }
    }

    internal class ChangeCategoryNameCommand : ICommand
    {
        private readonly CategoryService _categoryService;
        private readonly Guid _categoryId;
        private readonly string _newName;

        public ChangeCategoryNameCommand(CategoryService categoryService, Guid categoryId, string newName)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            _categoryId = categoryId;
            _newName = newName ?? throw new ArgumentNullException(nameof(newName));
        }

        public void Execute()
        {
            _categoryService.ChangeName(_categoryId, _newName);
        }
    }

    internal class ChangeCategoryTypeCommand : ICommand
    {
        private readonly CategoryService _categoryService;
        private readonly Guid _categoryId;
        private readonly OperationType _newType;

        public ChangeCategoryTypeCommand(CategoryService categoryService, Guid categoryId, OperationType newType)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            _categoryId = categoryId;
            _newType = newType;
        }

        public void Execute()
        {
            _categoryService.ChangeType(_categoryId, _newType);
        }
    }
}
