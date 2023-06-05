using System.Collections.Generic;

namespace Models
{
    public class CargoShip
    {
        public int MaxWeight { get; set; }
        public List<Container> Containers { get; set; }

        public CargoShip()
        {
            Containers = new List<Container>();
        }

        public void AddContainer(Container container)
        {
            Containers.Add(container);
        }

        public bool CanAddContainer(Container container)
        {
            return false;
        }

        public int GetContainerCount()
        {
            return Containers.Count;
        }

        public float GetWeightDistribution()
        {
            return 0;
        }
    }

}
