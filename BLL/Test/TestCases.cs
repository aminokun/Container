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
                        new Container("V", ContainerType.Valuable),
                        new Container("V", ContainerType.Valuable),
                        new Container("V", ContainerType.Valuable),
                        new Container("C", ContainerType.Cooled),
                        new Container("C", ContainerType.Cooled),
                        new Container("C", ContainerType.Cooled),
                        new Container("C", ContainerType.Cooled),
                        new Container("C", ContainerType.Cooled),
                        new Container("C", ContainerType.Cooled),
                        new Container("C", ContainerType.Cooled),
                        new Container("C", ContainerType.Cooled),
                        new Container("N", ContainerType.Normal),
                        new Container("N", ContainerType.Normal),
                        new Container("N", ContainerType.Normal),
                        new Container("N", ContainerType.Normal),
                        new Container("N", ContainerType.Normal),
                        new Container("N", ContainerType.Normal)

                    };
                    //Shuffle(testCases1);

                    return testCases1;
                case 2:
                    Container[] testCases2 = new Container[]
                    {
                        new Container("C", ContainerType.Cooled),
                        new Container("C", ContainerType.Cooled),
                        new Container("N", ContainerType.Normal),
                        new Container("N", ContainerType.Normal),
                        new Container("N", ContainerType.Normal),
                    };
                    //Shuffle(testCases2);

                    return testCases2;
                default:
                    throw new ArgumentException("Invalid test case number.");
            }
        }
        //private static void Shuffle<T>(T[] array)
        //{
        //    Random random = new Random();

        //    for (int i = array.Length - 1; i > 0; i--)
        //    {
        //        int j = random.Next(i + 1);
        //        T temp = array[i];
        //        array[i] = array[j];
        //        array[j] = temp;
        //    }
        //}
    }

}
