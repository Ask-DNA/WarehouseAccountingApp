using WarehouseAccountingApp.Domain.Models;

namespace WarehouseAccountingApp.UseCases.Dto
{
    public class BoxDto(Box box)
    {
        public int ID { get; } = box.ID;
        public int Width { get; } = box.Width;
        public int Height { get; } = box.Height;
        public int Length { get; } = box.Length;
        public int Weight { get; } = box.Weight;
        public int Volume { get; } = box.Volume;
        public DateOnly? ProductionDate { get; } = box.ProductionDate;
        public DateOnly ExpirationDate { get; } = box.ExpirationDate;
    }
}
