using WarehouseAccountingApp.Domain.Interfaces;
using WarehouseAccountingApp.Domain.Models;
using WarehouseAccountingApp.UseCases.Dto;
using WarehouseAccountingApp.UseCases.UseCaseInputPorts;

namespace WarehouseAccountingApp.UseCases.Interactors
{
    public class GetTopPallets(IPalletRepository repository) : IGetTopPallets
    {
        private readonly IPalletRepository _repository = repository;

        public List<PalletDto> Handle(int num, string topBy, (string orderBy, bool descending) orderBy, params (string thanBy, bool descending)[] thanBy)
        {
            List<Pallet> pallets = _repository.GetAll();
            pallets = PalletOrderer.Process(pallets, (topBy, descending: true));
            pallets = pallets.Take(num).ToList();
            pallets = PalletOrderer.Process(pallets, orderBy, thanBy);

            List<PalletDto> palletsDto = new(pallets.Count);
            for (int i = 0; i < pallets.Count; i++)
                palletsDto.Add(new(pallets[i]));

            return palletsDto;
        }
    }
}
