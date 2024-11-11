using WarehouseAccountingApp.Domain.Models;

namespace WarehouseAccountingApp.Domain.Interfaces
{
    public interface IPalletRepository
    {
        List<Pallet> GetAll();
    }
}
