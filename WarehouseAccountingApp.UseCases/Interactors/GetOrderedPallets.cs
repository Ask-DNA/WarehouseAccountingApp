using WarehouseAccountingApp.Domain.Interfaces;
using WarehouseAccountingApp.Domain.Models;
using WarehouseAccountingApp.UseCases.Dto;
using WarehouseAccountingApp.UseCases.UseCaseInputPorts;

namespace WarehouseAccountingApp.UseCases.Interactors
{
    public class GetOrderedPallets(IPalletRepository repository) : IGetOrderedPallets
    {
        private readonly IPalletRepository _repository = repository;

        public List<PalletDto> Handle((string orderBy, bool descending) orderBy, params (string thanBy, bool descending)[] thanBy)
        {
            List<Pallet> pallets = _repository.GetAll();
            pallets = PalletOrderer.Process(pallets, orderBy, thanBy);

            List<PalletDto> palletsDto = new(pallets.Count);
            for (int i = 0; i < pallets.Count; i++)
                palletsDto.Add(new(pallets[i]));

            return palletsDto;
        }
    }
}
