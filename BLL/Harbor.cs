using Models;

namespace BLL
{
    public class Harbor
    {
        public Ship CreateShip(int rows, int columns, int levels, Container[] containers)
        {
            Ship ship = new Ship(rows, columns, levels);
            ship.FillShip(containers);
            SortingAlgorithm.SortContainers(ship.CargoShip);
            return ship;
        }
    }
}
