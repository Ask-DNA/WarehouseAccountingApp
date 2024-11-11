namespace WarehouseAccountingApp.Infrastructure.Database.Models
{
    public class BoxDbModel
    {
        public int ID { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }
        public int Weight { get; set; }
        public DateOnly? ProductionDate { get; set; }
        public DateOnly ExpirationDate { get; set; }
        public int PalletId { get; set; }
        public PalletDbModel? Pallet { get; set; }
    }
}
