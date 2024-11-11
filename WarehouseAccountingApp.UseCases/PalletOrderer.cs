using WarehouseAccountingApp.Domain.Models;
using WarehouseAccountingApp.UseCases.Dto;

namespace WarehouseAccountingApp.UseCases
{
    internal static class PalletOrderer
    {
        public static List<Pallet> Process(
            List<Pallet> pallets,
            (string orderBy, bool descending) orderBy,
            params (string thanBy, bool descending)[] thanBy)
        {
            for (int i = thanBy.Length - 1; i >= 0; i--)
            {
                if (thanBy[i].descending)
                    pallets = OrderByDesc(pallets, thanBy[i].thanBy);
                else
                    pallets = OrderBy(pallets, thanBy[i].thanBy);
            }
            if (orderBy.descending)
                pallets = OrderByDesc(pallets, orderBy.orderBy);
            else
                pallets = OrderBy(pallets, orderBy.orderBy);

            return pallets;
        }

        private static List<Pallet> OrderBy(IEnumerable<Pallet> pallets, string fieldName)
        {
            return fieldName switch
            {
                (nameof(PalletDto.ID)) => [.. pallets.OrderBy(x => x.ID)],
                (nameof(PalletDto.Width)) => [.. pallets.OrderBy(x => x.Width)],
                (nameof(PalletDto.Height)) => [.. pallets.OrderBy(x => x.Height)],
                (nameof(PalletDto.Length)) => [.. pallets.OrderBy(x => x.Length)],
                (nameof(PalletDto.Weight)) => [.. pallets.OrderBy(x => x.Weight)],
                (nameof(PalletDto.Volume)) => [.. pallets.OrderBy(x => x.Volume)],
                (nameof(PalletDto.ExpirationDate)) => [.. pallets.OrderBy(x => x.ExpirationDate)],
                _ => throw new ArgumentException($"Invalid key name {fieldName}"),
            };
        }

        private static List<Pallet> OrderByDesc(IEnumerable<Pallet> pallets, string fieldName)
        {
            return fieldName switch
            {
                (nameof(PalletDto.ID)) => [.. pallets.OrderByDescending(x => x.ID)],
                (nameof(PalletDto.Width)) => [.. pallets.OrderByDescending(x => x.Width)],
                (nameof(PalletDto.Height)) => [.. pallets.OrderByDescending(x => x.Height)],
                (nameof(PalletDto.Length)) => [.. pallets.OrderByDescending(x => x.Length)],
                (nameof(PalletDto.Weight)) => [.. pallets.OrderByDescending(x => x.Weight)],
                (nameof(PalletDto.Volume)) => [.. pallets.OrderByDescending(x => x.Volume)],
                (nameof(PalletDto.ExpirationDate)) => [.. pallets.OrderByDescending(x => x.ExpirationDate)],
                _ => throw new ArgumentException($"Invalid key name {fieldName}"),
            };
        }
    }
}
