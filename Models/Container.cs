using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Container
    {
        public int Weight { get; set; }
        public bool IsValuable { get; set; }
        public bool IsCooled { get; set; }

        public Container(int weight, bool isValuable, bool isCooled)
        {
            Weight = weight;
            IsValuable = isValuable;
            IsCooled = isCooled;
        }
    }
}
