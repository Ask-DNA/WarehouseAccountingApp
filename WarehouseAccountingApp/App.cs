using Microsoft.Extensions.DependencyInjection;
using WarehouseAccountingApp.UseCases.Dto;
using WarehouseAccountingApp.UseCases.UseCaseInputPorts;
using WarehouseAccountingApp.UseCases.UseCaseOutputPorts;

namespace WarehouseAccountingApp
{
    public class App(IServiceProvider serviceProvider)
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;

        public void Run()
        {
            string? input;
            while (true)
            {
                Console.WriteLine("Enter 1 to print pallets ordered by expiration date, than by weight");
                Console.WriteLine("Enter 2 to print top three expiration date pallets ordered by volume");
                input = Console.ReadLine();
                if (input is null || (input != "1" && input != "2"))
                {
                    Console.Clear();
                    continue;
                }
                try
                {
                    Console.WriteLine();
                    if (input == "1")
                        PrintPalletsOrderedByExpirationDateThanByWeight();
                    else
                        PrintTopThreeExpirationDatePalletsOrderedByVolume();
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception occured: " + ex.Message);
                    Console.WriteLine("Terminating process");
                    break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void PrintPalletsOrderedByExpirationDateThanByWeight()
        {
            IGetOrderedPallets inputPort = _serviceProvider.GetService<IGetOrderedPallets>() ?? throw new InvalidOperationException("Invalid service provider configure");
            IPalletListViewOutputPort outputPort = _serviceProvider.GetService<IPalletListViewOutputPort>() ?? throw new InvalidOperationException("Invalid service provider configure");

            outputPort.Present(inputPort.Handle(
                (orderBy: nameof(PalletDto.ExpirationDate), descending: false),
                (thanBy: nameof(PalletDto.Weight), descending: false)));
        }

        private void PrintTopThreeExpirationDatePalletsOrderedByVolume()
        {
            IGetTopPallets inputPort = _serviceProvider.GetService<IGetTopPallets>() ?? throw new InvalidOperationException("Invalid service provider configure");
            IPalletListViewOutputPort outputPort = _serviceProvider.GetService<IPalletListViewOutputPort>() ?? throw new InvalidOperationException("Invalid service provider configure");
            
            outputPort.Present(inputPort.Handle(
                num: 3,
                topBy: nameof(PalletDto.ExpirationDate),
                (orderBy: nameof(PalletDto.Volume), descending: false)));
        }
    }
}
