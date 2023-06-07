using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Test
{
    public class TestCases
    {
        public static Container[] GetTestCases(int number)
        {
            switch(number)
            {
                case 1:
                    Container[] testCases1 = new Container[]
                    {
                        new Container("V1", ContainerType.Valuable),
                        new Container("V2", ContainerType.Valuable),
                        new Container("V3", ContainerType.Valuable),
                        new Container("C1", ContainerType.Cooled),
                        new Container("C2", ContainerType.Cooled),
                        new Container("C3", ContainerType.Cooled),
                        new Container("C4", ContainerType.Cooled),
                        new Container("C5", ContainerType.Cooled),
                        new Container("C6", ContainerType.Cooled),
                        new Container("C7", ContainerType.Cooled),
                        new Container("C8", ContainerType.Cooled),
                        new Container("N1", ContainerType.Normal),
                        new Container("N2", ContainerType.Normal),
                        new Container("N3", ContainerType.Normal),
                        new Container("N4", ContainerType.Normal),
                        new Container("N5", ContainerType.Normal),
                        new Container("N6", ContainerType.Normal),
                        new Container("N7", ContainerType.Normal),
                        new Container("N8", ContainerType.Normal),
                        new Container("N9", ContainerType.Normal),
                        new Container("N10", ContainerType.Normal),
                        new Container("N11", ContainerType.Normal)
                    };
                    Shuffle(testCases1);

                    return testCases1;
                case 2:
                    Container[] testCases2 = new Container[]
                    {
                        new Container("C1", ContainerType.Cooled),
                        new Container("C2", ContainerType.Cooled),
                        new Container("N1", ContainerType.Normal),
                        new Container("N2", ContainerType.Normal),
                        new Container("N3", ContainerType.Normal),
                    };
                    Shuffle(testCases2);

                    return testCases2;
                default:
                    throw new ArgumentException("Invalid test case number.");
            }
        }
        private static void Shuffle<T>(T[] array)
        {
            Random random = new Random();

            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                T temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
    }

}
