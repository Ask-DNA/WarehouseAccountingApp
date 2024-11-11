using WarehouseAccountingApp.Domain.Models;

namespace WarehouseAccountingApp.UseCases.Dto
{
    public class PalletDto
    {
        public int ID { get; }
        public int Width { get; }
        public int Height { get; }
        public int Length { get; }
        public int Weight { get; }
        public int Volume { get; }
        public DateOnly? ExpirationDate { get; }
        public IReadOnlyList<BoxDto> Boxes { get; }

        public PalletDto(Pallet pallet)
        {
            ID = pallet.ID;
            Width = pallet.Width;
            Height = pallet.Height;
            Length = pallet.Length;
            Weight = pallet.Weight;
            Volume = pallet.Volume;
            ExpirationDate = pallet.ExpirationDate;

            List<BoxDto> boxes = new(pallet.Boxes.Count);
            for (int i = 0; i < pallet.Boxes.Count; i++)
                boxes.Add(new BoxDto(pallet.Boxes[i]));
            Boxes = boxes;
        }
    }
}
