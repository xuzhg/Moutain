using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class AddCategoryUseCase : IAddCategoryUseCase
    {
        public AddCategoryUseCase(ICategoryRepository categoryRepository)
        {
            CategoryRepository = categoryRepository;
        }

        public ICategoryRepository CategoryRepository { get; }

        public void Execute(Category category)
        {
            CategoryRepository.AddCategory(category);
        }
    }
}
