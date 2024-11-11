namespace WarehouseAccountingApp.Infrastructure.Database.Models
{
    public class PalletDbModel
    {
        public int ID { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }
        public List<BoxDbModel>? Boxes { get; set; }
    }
}
