using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases
{
    public class ViewInventoriesByNameUseCase : IViewInventoriesByNameUseCase
    {
        public ViewInventoriesByNameUseCase(IInventoryRepository inventoryRepository)
        {
            InventoryRepository = inventoryRepository;
        }

        public IInventoryRepository InventoryRepository { get; }

        public async Task<IEnumerable<Inventory>> ExecuteAsync(string name = "")
        {
            return await InventoryRepository.GetInventoriesByName(name);
        }
    }
}