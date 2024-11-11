using WarehouseAccountingApp.UseCases.Dto;

namespace WarehouseAccountingApp.UseCases.UseCaseOutputPorts
{
    public interface IPalletListViewOutputPort
    {
        void Present(List<PalletDto> pallets);
    }
}
