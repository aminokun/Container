using System.Collections.Generic;

namespace Models
{
    public class Ship
    {
        public int Rows { get; }
        public int Columns { get; }
        public int Levels { get; }
        public Container[,,] CargoShip { get; }

        public Ship(int rows, int columns, int levels)
        {
            Rows = rows;
            Columns = columns;
            Levels = levels;
            CargoShip = new Container[Rows, Columns, Levels];

            for (int level = 0; level < Levels; level++)
            {
                for (int row = 0; row < Rows; row++)
                {
                    for (int column = 0; column < Columns; column++)
                    {
                        CargoShip[row, column, level] = null;  // Set to null initially
                    }
                }
            }
        }

        public void FillShip(Container[] containers)
        {
            int testCaseIndex = 0;

            for (int level = 0; level < Levels; level++)
            {
                for (int row = 0; row < Rows; row++)
                {
                    for (int column = 0; column < Columns; column++)
                    {
                        CargoShip[row, column, level] = containers[testCaseIndex];
                        testCaseIndex = (testCaseIndex + 1) % containers.Length;
                    }
                }
            }
        }


        public void DisplayShip()
        {
            Console.WriteLine(@"
               _____                      _____ _     _       
              / ____|                    / ____| |   (_)      
             | |     __ _ _ __ __ _  ___| (___ | |__  _ _ __  
             | |    / _` | '__/ _` |/ _ \\___ \| '_ \| | '_ \ 
             | |___| (_| | | | (_| | (_) ____) | | | | | |_) |
              \_____\__,_|_|  \__, |\___|_____/|_| |_|_| .__/ 
                               __/ |                   | |    
                              |___/                    |_|    
            ");

            Console.WriteLine("\nSorted Cargo Ship:");

            for (int level = 0; level < Levels; level++)
            {
                Console.WriteLine($"Level {level + 1}:");
                for (int row = 0; row < Rows; row++)
                {
                    for (int column = 0; column < Columns; column++)
                    {
                        Container container = CargoShip[row, column, level];
                        if (container != null)
                        {
                            Console.Write($"{container.ID} ({container.Type})\t");
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }

    }

}
