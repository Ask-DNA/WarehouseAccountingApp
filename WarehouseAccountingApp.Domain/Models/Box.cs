namespace WarehouseAccountingApp.Domain.Models
{
    public class Box
    {
        public int ID { get; init; }
        public int Width { get; init; }
        public int Height { get; init; }
        public int Length { get; init; }
        public int Weight { get; init; }
        public int Volume { get => Width * Height * Length; }
        public DateOnly? ProductionDate { get; init; }
        public DateOnly ExpirationDate { get; init; }

        private Box(int id, int width, int height, int length, int weight, DateOnly? productionDate = null, DateOnly? expirationDate = null)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(id, 0, nameof(id));
            ArgumentOutOfRangeException.ThrowIfLessThan(width, 1, nameof(width));
            ArgumentOutOfRangeException.ThrowIfLessThan(height, 1, nameof(height));
            ArgumentOutOfRangeException.ThrowIfLessThan(length, 1, nameof(length));
            ArgumentOutOfRangeException.ThrowIfLessThan(weight, 1, nameof(weight));
            if (productionDate is null && expirationDate is null)
                throw new ArgumentException($"One of the values ​​must be set: '{nameof(productionDate)}', '{nameof(expirationDate)}'");

            ID = id;
            Width = width;
            Height = height;
            Length = length;
            Weight = weight;
            ProductionDate = productionDate;

            if (expirationDate is null)
                ExpirationDate = productionDate!.Value.AddDays(100);
            else
                ExpirationDate = expirationDate.Value;
        }

        public static Box CreateWithProductionDate(int id, int width, int height, int length, int weight, DateOnly productionDate)
        {
            return new Box(id, width, height, length, weight, productionDate);
        }

        public static Box CreateWithExpirationDate(int id, int width, int height, int length, int weight, DateOnly expirationDate)
        {
            return new Box(id, width, height, length, weight, null, expirationDate);
        }
    }
}
