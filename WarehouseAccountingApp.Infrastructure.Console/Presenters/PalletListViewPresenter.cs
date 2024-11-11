using System.Text;
using WarehouseAccountingApp.UseCases.Dto;
using WarehouseAccountingApp.UseCases.UseCaseOutputPorts;

namespace WarehouseAccountingApp.Infrastructure.Console.Presenters
{
    public class PalletListViewPresenter : IPalletListViewOutputPort
    {
        public void Present(List<PalletDto> pallets)
        {
            System.Console.WriteLine("PALLETS" + Environment.NewLine);
            if (pallets.Count == 0)
                System.Console.WriteLine("NotFound");

            StringBuilder sb = new();
            for (int i = 0; i < pallets.Count; i++)
            {
                sb.Append($"Pallet {pallets[i].ID} | width: {pallets[i].Width}; height: {pallets[i].Height}; length: {pallets[i].Length}; ");
                sb.Append($"weight: {pallets[i].Weight}; volume: {pallets[i].Volume}; ");
                if (pallets[i].ExpirationDate is null)
                    sb.Append("expiration: -");
                else
                    sb.Append($"expiration: {pallets[i].ExpirationDate}");

                sb.Append(Environment.NewLine);
                for (int j = 0; j < pallets[i].Boxes.Count; j++)
                {
                    sb.Append($"- Box {pallets[i].Boxes[j].ID} | width: {pallets[i].Boxes[j].Width}; height: {pallets[i].Boxes[j].Height}; ");
                    sb.Append($"length: {pallets[i].Boxes[j].Length}; weight: {pallets[i].Boxes[j].Weight}; volume: {pallets[i].Boxes[j].Volume}; ");
                    if (pallets[i].Boxes[j].ProductionDate is null)
                        sb.Append("production: -; ");
                    else
                        sb.Append("$\"production: {pallets[i].Boxes[j].ProductionDate}; ");
                    sb.Append($"expiration: {pallets[i].Boxes[j].ExpirationDate}");
                    sb.Append(Environment.NewLine);
                }
                sb.Append(Environment.NewLine);
            }
            System.Console.WriteLine(sb.ToString());
        }
    }
}
