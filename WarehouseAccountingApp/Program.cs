using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WarehouseAccountingApp.Domain.Interfaces;
using WarehouseAccountingApp.Infrastructure.Database;
using WarehouseAccountingApp.UseCases.Interactors;
using WarehouseAccountingApp.UseCases.UseCaseInputPorts;
using WarehouseAccountingApp.UseCases.UseCaseOutputPorts;
using WarehouseAccountingApp.Infrastructure.Console.Presenters;
using WarehouseAccountingApp;

IServiceCollection services = new ServiceCollection()
    .AddDbContext<DatabaseContext>(options => options.UseNpgsql("Host=localhost;Port=5432;Database=usersdb;Username=postgres;Password=mypassword"))
    .AddTransient<IPalletRepository, PalletRepository>()
    .AddTransient<IGetOrderedPallets, GetOrderedPallets>()
    .AddTransient<IGetTopPallets, GetTopPallets>()
    .AddTransient<IPalletListViewOutputPort, PalletListViewPresenter>();

using ServiceProvider serviceProvider = services.BuildServiceProvider();
App app = new(serviceProvider);
app.Run();
