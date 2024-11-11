using Microsoft.EntityFrameworkCore;
using WarehouseAccountingApp.Domain.Interfaces;
using WarehouseAccountingApp.Domain.Models;
using WarehouseAccountingApp.Infrastructure.Database.Models;

namespace WarehouseAccountingApp.Infrastructure.Database
{
    public class PalletRepository(DatabaseContext context) : IPalletRepository, IDisposable
    {
        private readonly DatabaseContext _databaseContext = context;
        private bool _disposed = false;

        public List<Pallet> GetAll()
        {
            ObjectDisposedException.ThrowIf(_disposed, this);

            List<PalletDbModel> palletsDb = [.. _databaseContext.Pallets.Include(p => p.Boxes).AsNoTracking()];
            List<Pallet> result = new(palletsDb.Count);
            foreach (PalletDbModel palletDb in palletsDb)
            {
                List<Box> boxes = [];
                if (palletDb.Boxes is not null)
                {
                    foreach(BoxDbModel box in palletDb.Boxes)
                    {
                        if (box.ProductionDate is not null)
                            boxes.Add(Box.CreateWithProductionDate(box.ID, box.Width, box.Height, box.Length, box.Weight, box.ProductionDate.Value));
                        else
                            boxes.Add(Box.CreateWithExpirationDate(box.ID, box.Width, box.Height, box.Length, box.Weight, box.ExpirationDate));
                    }
                }
                result.Add(new Pallet(palletDb.ID, palletDb.Width, palletDb.Height, palletDb.Length, boxes));
            }
            return result;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _databaseContext.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
