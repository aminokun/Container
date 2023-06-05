using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ContainerLayer
    {
        public List<Container> Containers { get; set; }

        public ContainerLayer()
        {
            Containers = new List<Container>();
        }

        public void AddContainer(Container container)
        {
        }

        public Container GetContainerAtPosition(int position)
        {
            return Containers[position];
        }
    }

}
