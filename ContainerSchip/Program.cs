using Models;
using BLL.Test;
using BLL;

namespace ContainerSchip
{
    public class Program
    {
        static void Main(string[] args)
        {
            int rows = 4;
            int columns = 4;
            int levels = 3;

            Container[] testCases = TestCases.GetTestCases(1);

            Harbor harbor = new Harbor();
            Ship ship = harbor.CreateShip(rows, columns, levels, testCases);

            SortingAlgorithm.SortContainers(ship.CargoShip);
            ship.DisplayShip();
        }
    }
}
