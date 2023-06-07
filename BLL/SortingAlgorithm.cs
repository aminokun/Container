using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SortingAlgorithm
    {
        public static void SortContainers(Container[,,] cargoShip)
        {
            int rows = cargoShip.GetLength(0);
            int columns = cargoShip.GetLength(1);
            int levels = cargoShip.GetLength(2);

            List<Container> flattenedCargoShip = cargoShip.Cast<Container>().ToList();

            List<Container> uniqueContainers = flattenedCargoShip
                .Distinct()
                .OrderBy(container => container.Type)
                .ToList();

            var CooledContainers = uniqueContainers
                .Where(container => container.Type == ContainerType.Cooled)
                .ToList();

            var ValuableContainers = uniqueContainers
                .Where(container => container.Type == ContainerType.Valuable)
                .ToList();

            var NormalContainers = uniqueContainers
                .Where(container => container.Type == ContainerType.Normal)
                .ToList();

            int totalPositions = rows * columns * levels;

            int firstRowCounter = 0;
            int cooledIndex = 0;
            int normalIndex = 0;
            int valuableIndex = 0;
            int levelChanger = 0;


            for (int row = 0; row < rows; row++)
            {
                if (firstRowCounter >= columns)
                {
                    levelChanger++;
                    break;
                }

                while (CooledContainers.Count > 0 && firstRowCounter < columns)
                {
                    cargoShip[row, firstRowCounter, levelChanger] = CooledContainers[cooledIndex];
                    cooledIndex++;
                    firstRowCounter++;
                    if (cooledIndex >= CooledContainers.Count)
                    {
                        CooledContainers.Clear();
                    }
                }
            }


            int currentIndex = firstRowCounter;

            for (int level = 0; level < levels; level++)
            {
                for (int row = 0; row < rows; row++)
                {
                    for (int column = currentIndex; column < columns; column++)
                    {
                        if (NormalContainers.Count > 0)
                        {
                            cargoShip[row, column, level] = NormalContainers[normalIndex];
                            normalIndex++;
                            if (normalIndex >= NormalContainers.Count)
                            {
                                NormalContainers.Clear();
                            }
                        }
                        else if (ValuableContainers.Count > 0)
                        {
                            cargoShip[row, column, level] = ValuableContainers[valuableIndex];
                            valuableIndex++;
                            if (valuableIndex >= ValuableContainers.Count)
                            {
                                ValuableContainers.Clear();
                            }
                        }
                        else
                        {
                            cargoShip[row, column, level] = new Container("--", ContainerType.Empty);
                        }
                    }

                    currentIndex = 0;

                }
            }


            if (ValuableContainers.Count > 0)
            {
                for (int level = 0; level < levels; level++)
                {
                    for (int row = 0; row < rows; row++)
                    {
                        for (int column = currentIndex; column < columns; column++)
                        {
                            if (ValuableContainers.Count > 0)
                            {
                                cargoShip[row, column, level] = ValuableContainers[valuableIndex];
                                valuableIndex++;
                                if (valuableIndex >= ValuableContainers.Count)
                                {
                                    ValuableContainers.Clear();
                                }
                            }
                            else
                            {
                                cargoShip[row, column, level] = new Container("--", ContainerType.Empty);
                            }
                        }

                        currentIndex = 0;

                    }
                }
            }
        }

    }
}