using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ContainerSorter
    {
        public CargoShip Ship { get; set; }

        public ContainerSorter(CargoShip ship)
        {
            Ship = ship;
        }

        public void AllocateContainers(Dictionary<string, int> containerCounts)
        {

        }

        public bool IsAllocationValid()
        {
            return true;

        }

        public void VisualizeAllocation()
        {

        }

        private Container CreateContainer(string containerType)
        {
            return new Container(0, false, false);
        }
    }
}
