using WarehouseAccountingApp.UseCases.Dto;

namespace WarehouseAccountingApp.UseCases.UseCaseInputPorts
{
    public interface IGetOrderedPallets
    {
        List<PalletDto> Handle((string orderBy, bool descending) orderBy, params (string thanBy, bool descending)[] thanBy);
    }
}
