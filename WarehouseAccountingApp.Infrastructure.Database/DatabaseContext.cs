using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseAccountingApp.Infrastructure.Database.Models;

namespace WarehouseAccountingApp.Infrastructure.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<BoxDbModel> Boxes { get; set; }
        public DbSet<PalletDbModel> Pallets { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalletDbModel>(PalletsConfigure);
            modelBuilder.Entity<BoxDbModel>(BoxesConfigure);
            
            modelBuilder.Entity<PalletDbModel>().HasData(
                new PalletDbModel() { ID = 1, Width = 80, Height = 15, Length = 120 },
                new PalletDbModel() { ID = 2, Width = 80, Height = 15, Length = 120 },
                new PalletDbModel() { ID = 3, Width = 80, Height = 15, Length = 120 },
                new PalletDbModel() { ID = 4, Width = 80, Height = 15, Length = 120 },
                new PalletDbModel() { ID = 5, Width = 80, Height = 15, Length = 120 }
                );

            modelBuilder.Entity<BoxDbModel>().HasData(
                new BoxDbModel()
                {
                    ID = 1,
                    Width = 27,
                    Height = 18,
                    Length = 40,
                    Weight = 10,
                    ProductionDate = null,
                    ExpirationDate = new(2025, 1, 1),
                    PalletId = 1
                },
                new BoxDbModel()
                {
                    ID = 2,
                    Width = 27,
                    Height = 18,
                    Length = 40,
                    Weight = 10,
                    ProductionDate = new(2024, 10, 10),
                    ExpirationDate = new DateOnly(2024, 10, 10).AddDays(100),
                    PalletId = 1
                },
                new BoxDbModel()
                {
                    ID = 3,
                    Width = 36,
                    Height = 22,
                    Length = 53,
                    Weight = 20,
                    ProductionDate = null,
                    ExpirationDate = new(2025, 1, 3),
                    PalletId = 1
                },
                new BoxDbModel()
                {
                    ID = 4,
                    Width = 27,
                    Height = 18,
                    Length = 40,
                    Weight = 10,
                    ProductionDate = new(2024, 9, 10),
                    ExpirationDate = new DateOnly(2024, 9, 10).AddDays(100),
                    PalletId = 2
                },
                new BoxDbModel()
                {
                    ID = 5,
                    Width = 36,
                    Height = 22,
                    Length = 53,
                    Weight = 20,
                    ProductionDate = null,
                    ExpirationDate = new(2025, 2, 1),
                    PalletId = 2
                },
                new BoxDbModel()
                {
                    ID = 6,
                    Width = 36,
                    Height = 22,
                    Length = 53,
                    Weight = 30,
                    ProductionDate = null,
                    ExpirationDate = new(2025, 1, 1),
                    PalletId = 3
                },
                new BoxDbModel()
                {
                    ID = 7,
                    Width = 27,
                    Height = 18,
                    Length = 40,
                    Weight = 10,
                    ProductionDate = null,
                    ExpirationDate = new(2025, 3, 4),
                    PalletId = 5
                },
                new BoxDbModel()
                {
                    ID = 8,
                    Width = 36,
                    Height = 22,
                    Length = 53,
                    Weight = 25,
                    ProductionDate = null,
                    ExpirationDate = new(2025, 1, 1),
                    PalletId = 5
                }
                );
        }

        private static void PalletsConfigure(EntityTypeBuilder<PalletDbModel> builder)
        {
            builder.ToTable("Pallets");
        }

        private static void BoxesConfigure(EntityTypeBuilder<BoxDbModel> builder)
        {
            builder.ToTable("Boxes");
            builder.Property(obj => obj.ProductionDate).HasColumnType("date");
            builder.Property(obj => obj.ExpirationDate).HasColumnType("date");
            builder
                .HasOne(box => box.Pallet)
                .WithMany(pallet => pallet.Boxes)
                .HasForeignKey(box => box.PalletId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
