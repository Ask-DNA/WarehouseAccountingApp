using WarehouseAccountingApp.UseCases.Dto;

namespace WarehouseAccountingApp.UseCases.UseCaseInputPorts
{
    public interface IGetTopPallets
    {
        List<PalletDto> Handle(int num, string topBy, (string orderBy, bool descending) orderBy, params (string thanBy, bool descending)[] thanBy);
    }
}
