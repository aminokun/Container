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
            // Get cargo dimensions
            int rows = cargoShip.GetLength(0);
            int columns = cargoShip.GetLength(1);
            int levels = cargoShip.GetLength(2);

            // Flattening matrix into a list of containers 
            List<Container> flattenedCargoShip = cargoShip.Cast<Container>().ToList();

            // Find unique containers sorted by type
            List<Container> uniqueContainers = flattenedCargoShip
                .Distinct()
                .OrderBy(container => container.Type)
                .ToList();

            // Split containers by type
            var CooledContainers = uniqueContainers
                .Where(container => container.Type == ContainerType.Cooled)
                .ToList();

            var ValuableContainers = uniqueContainers
                .Where(container => container.Type == ContainerType.Valuable)
                .ToList();

            var NormalContainers = uniqueContainers
                .Where(container => container.Type == ContainerType.Normal)
                .ToList();

            // Calculate total cargo positions
            int totalPositions = rows * columns * levels;

            // Fill first rows with cooled containers
            int firstRowCounter = 0;
            int cooledIndex = 0;
            int normalIndex = 0;
            int valuableIndex = 0;

            for (int row = 0; row < rows; row++)
            {
                if (firstRowCounter >= columns)
                {
                    break;
                }

                // add cooled containers in this row until no more left
                while (CooledContainers.Count > 0 && firstRowCounter < columns)
                {
                    cargoShip[row, firstRowCounter, 0] = CooledContainers[cooledIndex];
                    cooledIndex++;
                    firstRowCounter++;
                    if (cooledIndex >= CooledContainers.Count)
                    {
                        CooledContainers.Clear();
                    }
                }
            }


            // Fill rest of the positions with normal containers, then valuable containers
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

                    // go back to the first column for the next row 
                    currentIndex = 0;

                }
            }

            // Check if there are any remaining valuable containers to be added 

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

                        // go back to the first column for the next row 
                        currentIndex = 0;

                    }
                }
            }
        }

    }
}